using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultSkill : MonoBehaviour {


    [SerializeField]
    private GameObject SkillView = null;
   

    [SerializeField]
    private GameObject Skill_1 = null;
    [SerializeField]
    private GameObject Skill_2 = null;
    [SerializeField]
    private GameObject Skill_3 = null;

    [SerializeField]
    private Image SkillImg1;

    private bool bCool = true;

    private GameObject UsingSkill = null;
    private Vector3 vPos;

    private Color _color;
    private void Start()
    {
        _color = Skill_1.GetComponent<Image>().color;

        // 스킬 뭐선택됐는지 표현하는 코드 작성
    }

    public void OnSkill_1()
    {
        if(bCool)
        {

        UsingSkill = GameManager.Instance.Skill[0];
        Debug.Log(UsingSkill);
        StartCoroutine(PositionSkill());
        StartCoroutine(CoolTime(10f));
            bCool = false;
        }
    }

    public void OnSkill_2()
    {
       //Skill_2 = GameManager.Instance.Skill[1];
       //Instantiate(Skill_2);

    }

    public void OnSkill_3()
    {
        //Skill_3 = GameManager.Instance.Skill[2];
        //Instantiate(Skill_3);

    }
    //쿨타임
    IEnumerator CoolTime(float cool)
    {

        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            SkillImg1.fillAmount = (1.0f / cool);
            if (cool <= 1.0f)
                bCool = true;
            yield return new WaitForFixedUpdate();
        }
    }



    // 좌표설정 스킬

    private IEnumerator PositionSkill()
    {
        Skill_1.SetActive(false);
        Skill_2.SetActive(false);
        Skill_3.SetActive(false);

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                vPos  =Camera.main.ScreenToWorldPoint( Input.mousePosition);
                break;
            }
            else if (Input.touchCount > 0)
            {
                vPos =Input.GetTouch(0).position;
                break;
            }
            yield return null;
        }
        vPos.z = 0;
        UsingSkill.transform.position = vPos ;

        Instantiate(UsingSkill);

        Skill_1.SetActive(true);
        Skill_2.SetActive(true);
        Skill_3.SetActive(true);
         yield return new WaitForSeconds(0f);

    }
}
