using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class TrapManager : MonoBehaviour, IPointerDownHandler
{
    private GameObject dragObject = null;
    private GameObject touchedObject = null;
    private GameObject lastTrap = null;

    public GameObject[] trapObject;

    private List<SpriteGrid> spriteLists = new List<SpriteGrid>();

    private bool touch = false;

    private void Start()
    {
        spriteLists = GameObject.FindObjectsOfType<SpriteGrid>().ToList();
    }

    //마우스 클릭시 함정 생성
    public IEnumerator CreateTrap(int _idx)
    {
        dragObject = trapObject[_idx];

        yield return new WaitUntil(() => dragObject != null);

        var trap = dragObject.GetComponent<TrapScale>();
        foreach (var spriteGrid in spriteLists)
        {
            spriteGrid.GridSpritesOn(trap.type);
        }

        yield return new WaitForSeconds(0.1f);
        touch = true;
    }

    public void Update()
    {
        if (dragObject != null && touch == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var idx = 0;
                var diff = float.MaxValue;
                for (int i = 0; i < spriteLists.Count; i++)
                {
                    float dis = Vector2.Distance(spriteLists[i].transform.position, mousePos);
                    if (dis <= diff)
                    {
                        diff = dis;
                        idx = i;
                    }
                }

                var scale = dragObject.GetComponent<TrapScale>();
                spriteLists[idx].GetComponent<SpriteGrid>().CheckPosition(mousePos, dragObject, scale.width, scale.height, scale.type);
                lastTrap = dragObject;
                dragObject = null;
                touch = false;
                touchedObject.GetComponent<Image>().color = new Color(1, 1, 1);
                touchedObject = null;
                foreach (var spriteGrid in spriteLists)
                {
                    spriteGrid.GridSpritesOff();
                }
            }
        }
    }

    //마우스 클릭 시 함수
    public void OnPointerDown(PointerEventData _data)
    {
        if(dragObject == null)
        {
            var siblingIndex = _data.pointerCurrentRaycast.gameObject.transform.GetSiblingIndex();
            if (_data.pointerCurrentRaycast.gameObject == transform.GetChild(siblingIndex).gameObject)
            {
                StartCoroutine(CreateTrap(siblingIndex));
                touchedObject = transform.GetChild(siblingIndex).gameObject;
                touchedObject.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f);
            }
        }
    }

    public void ResetTraps()
    {
        var allTraps = GameObject.FindGameObjectWithTag("TrapParent").GetComponentsInChildren<Transform>();

        for(int i = 1; i < allTraps.Length; i++)
        {
            Destroy(allTraps[i].gameObject);
        }
        
        //TODO : 재화 되돌리기 추가
    }

    public void RestoreTrap()
    {
        if(lastTrap != null)
        {
            Destroy(lastTrap.gameObject);
            lastTrap = null;
            //TODO : 재화 되돌리기 추가
        }
    }
}
