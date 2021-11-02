using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
[DisallowMultipleComponent]
public class SpriteGrid : MonoBehaviour
{
    private Sprite sprite;
    private Bounds bounds;
    private Vector2 min;
    private Vector2 max;

    public int axisX;
    public int axisY;

    [HideInInspector]
    public bool[,] grid;

    public string blockingGridName;

    public Sprite square;

    private List<GameObject> gridObjectsList = new List<GameObject>();
    public GameObject TrapParent;

    private void Start()
    {
        grid = new bool[axisX, axisY];
        TrapParent = GameObject.Find("Traps");

        //SpriteRenderer의 Sprite를 가져옴
        sprite = GetComponent<SpriteRenderer>().sprite;
        //Sprite의 Bounds를 가져옴
        bounds = sprite.bounds;

        //min, max에 Bounds의 최소, 최대를 가져옴
        min = bounds.min;
        max = bounds.max;

        //x, y에 bounds 각 축 크기를 나눈 만큼을 저장함
        //size를 쓰는 이유는 영역의 전체 크기를 가져오기 위해서, max를 쓸 경우 중점에서 최대를 가져오기 때문에 크기가 반밖에 적용이 안됨
        var x = bounds.size.x / axisX;
        var y = bounds.size.y / axisY;

        //각 축으로 나눈 수 만큼 for 반복문을 돌림
        for (int i = 0; i < axisY; i++) {
            for (int j = 0; j < axisX; j++) {

                //입구쪽 막기 위한 작업
                if(blockingGridName == i + "," + j)
                {
                    min.x += x;
                    continue;
                }

                //새로운 게임 오브젝트 생성
                var newgo = new GameObject();
                newgo.name = i + "," + j;
                newgo.transform.localScale = new Vector2(x, y);
                //새로운 게임 오브젝트에 BoxCollider 추가
                var newbox2d = newgo.AddComponent<BoxCollider2D>();
                var sprite = newgo.AddComponent<SpriteRenderer>();
                sprite.sprite = square;
                sprite.color = new Color(0, 0, 0, 0.2f);
                //박스 콜라이더 크기를 일정 크기로 설정
                //newbox2d.size = new Vector2(x, y);
                newbox2d.isTrigger = true;
                newbox2d.size = new Vector2(1, 1);
                //새로운 게임 오브젝트를 하위 오브젝트로 추가
                newgo.transform.SetParent(this.transform);
                //새로운 게임 오브젝트의 위치를 부모 위치의 기준으로 정렬해서 맞춰줌
                newgo.transform.localPosition = new Vector3(min.x + (x * 0.5f), min.y + (y * 0.5f), -0.1f);
                gridObjectsList.Add(newgo);
                newgo.SetActive(false);
                min.x += x;
            }
            min.y += y;
            min.x = bounds.min.x;
        }
    }

    //놓은 마우스 위치와 가장 가까운 오브젝트 찾기
    public void CheckPosition(Vector2 _mousePos, GameObject _trap, int _width, int _height, TrapScale.Type _type)
    {
        var idx = 0;
        var diff = float.MaxValue;

        for(int i = 0; i < gridObjectsList.Count; i++) {
            float dis = Vector2.Distance(_mousePos, gridObjectsList[i].transform.position);
            if(dis <= diff) {
                diff = dis;
                idx = i;
            }
        }

        var startPos = gridObjectsList[idx].name;
        if (CanEquip(startPos, _width, _height)) {
            var trapObject = Instantiate(_trap, gridObjectsList[idx].transform.position, Quaternion.identity);

            if (_type == TrapScale.Type.Top)
            {
                var spriteBounds = trapObject.GetComponent<SpriteRenderer>().bounds;
                var collider = gridObjectsList[idx].GetComponent<BoxCollider2D>();
                var y = Mathf.Abs(collider.bounds.max.y - spriteBounds.max.y);
                trapObject.transform.position = new Vector2(trapObject.transform.position.x, (trapObject.transform.position.y + y));
            }
            else if (_type == TrapScale.Type.Bot)
            {
                var spriteBounds = trapObject.GetComponent<SpriteRenderer>().bounds;
                var collider = gridObjectsList[idx].GetComponent<BoxCollider2D>();
                var y = Mathf.Abs(collider.bounds.max.y - spriteBounds.max.y);
                trapObject.transform.position = new Vector2(trapObject.transform.position.x, (trapObject.transform.position.y - y));
            }

            trapObject.name = _trap.name;
            trapObject.transform.SetParent(TrapParent.transform);
        }
    }

    //설치가 가능한지 여부 판단
    public bool CanEquip(string _startGrid, int _width, int _height)//, TrapScale.Type _type)
    {
        //TODO : 왜 x, y가 바뀌여 나타나는지 의문..
        var startPos = _startGrid.Split(',');
        int x = int.Parse(startPos[0]);
        int y = int.Parse(startPos[1]);

        //switch (_type) {
        //case TrapScale.Type.Top:
        //    if (x != (axisY - 1))
        //        return false;
        //    break;
        //case TrapScale.Type.Mid:
        //    if (x == (axisY - 1) || x == 0)
        //        return false;
        //    break;
        //case TrapScale.Type.Bot:
        //    if (x != 0)
        //        return false;
        //    break;
        //}

        for (int i = x; i < (x + _width); i++) {
            for(int j = y; j > (y - _height); j--) {
                if(grid[j,i] == true) {
                    Debug.Log("이미 설치된 곳");
                    return false;
                } else {
                    grid[j, i] = true;
                    Debug.Log("Grid X : " + i + " Y : " + j + "설치");
                }
            }
        }

        Debug.Log("설치 완료");
        return true;
    }

    public void GridSpritesOn(TrapScale.Type _type)
    {
        foreach(var gridObject in gridObjectsList) {
            gridObject.SetActive(true);
        }

        for (int i = 0; i < axisX; i++) {
            for (int j = 0; j < axisY; j++) {

                if (blockingGridName == j + "," + i)
                {
                    continue;
                }

                switch (_type) {
                case TrapScale.Type.Top:
                    if(j == (axisY - 1)) {
                        transform.Find(j + "," + i).GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.2f);
                    }
                    break;
                case TrapScale.Type.Mid:
                    if(j != (axisY - 1) && j != 0) {
                        transform.Find(j + "," + i).GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.2f);
                    }
                    break;
                case TrapScale.Type.Bot:
                    if(j == 0) {
                        transform.Find(j + "," + i).GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.2f);
                    }
                    break;
                }

                if (grid[i, j] == true) {
                    transform.Find(j + "," + i).GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.2f);
                }
            }
        }
    }

    public void GridSpritesOff()
    {
        foreach (var gridObject in gridObjectsList) {
            gridObject.SetActive(false);
        }
    }
}
