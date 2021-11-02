using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public enum IVENVIEW
{
    INVEN_MATERIAL = 0,
    INVEN_TRAP,
    INVEN_OTHER,
    INVEN_CASH
}

// https://youtu.be/iMwczcKmqvQ



public class ButtonManager : MonoBehaviour {

    //// 함정을 가진 오브젝트
    //private Trap_Item _TItem = null;
    //public Trap_Item TItem {  get { return _TItem; } set { _TItem = value; } }

    // 인벤토리 메뉴중 어느것을 눌렀는가.
    [SerializeField]
    private Button[] InvenBtn = new Button[4];
    [SerializeField]
    private GameObject[] InvenView = new GameObject[4];
    int InvenViewCnt = 0;


    // 함정제작 추가창
    [SerializeField]
    private GameObject Make_Plus = null;
    // 디폴트 함정 <- 이미지를 가져오기 위해
    [SerializeField]
    private Trap_Default Default_Trap = null;


    // 서브메뉴 창

    [SerializeField]
    private GameObject SkillView = null;


    //**************************************************************************************************************************




    //**************************************************************************************************************************

        //우측하단 메뉴바
        // 스킬창
        public void OnSkillView()
    {
        SkillView.SetActive(true);
    }






    //**************************************************************************************************************************
    // 인벤토리 창 내에서 뷰 
    public void OnMaterialView()
    {
        InvenView[InvenViewCnt].SetActive(false);
        //InvenBtn[InvenViewCnt].GetComponent<Image>().sprite = InvenBtn[InvenViewCnt].GetComponent<ImageSwap>().Img[1];
        InvenBtn[InvenViewCnt].transform.SetSiblingIndex(0);
        InvenViewCnt = (int)IVENVIEW.INVEN_MATERIAL;
        InvenView[InvenViewCnt].SetActive(true);
       // InvenBtn[InvenViewCnt].GetComponent<Image>().sprite = InvenBtn[InvenViewCnt].GetComponent<ImageSwap>().Img[0];
        InvenBtn[InvenViewCnt].transform.SetSiblingIndex(2);

    }
    public void OnTrapView()
    {
        InvenView[InvenViewCnt].SetActive(false);
        //InvenBtn[InvenViewCnt].GetComponent<Image>().sprite = InvenBtn[InvenViewCnt].GetComponent<ImageSwap>().Img[1];
        InvenBtn[InvenViewCnt].transform.SetSiblingIndex(0);
        InvenViewCnt = (int)IVENVIEW.INVEN_TRAP;
        InvenView[InvenViewCnt].SetActive(true);
      //  InvenBtn[InvenViewCnt].GetComponent<Image>().sprite = InvenBtn[InvenViewCnt].GetComponent<ImageSwap>().Img[0];
        InvenBtn[InvenViewCnt].transform.SetSiblingIndex(2);

    }
    public void OnOtherView()
    {
        InvenView[InvenViewCnt].SetActive(false);
        InvenBtn[InvenViewCnt].GetComponent<Image>().sprite = InvenBtn[InvenViewCnt].GetComponent<ImageSwap>().Img[1];
        InvenViewCnt = (int)IVENVIEW.INVEN_OTHER;
        InvenView[InvenViewCnt].SetActive(true);
        InvenBtn[InvenViewCnt].GetComponent<Image>().sprite = InvenBtn[InvenViewCnt].GetComponent<ImageSwap>().Img[0];
    }
    public void OnCashView()
    {
        InvenView[InvenViewCnt].SetActive(false);
        InvenBtn[InvenViewCnt].GetComponent<Image>().sprite = InvenBtn[InvenViewCnt].GetComponent<ImageSwap>().Img[1];
        InvenViewCnt = (int)IVENVIEW.INVEN_CASH;
        InvenView[InvenViewCnt].SetActive(true);
        InvenBtn[InvenViewCnt].GetComponent<Image>().sprite = InvenBtn[InvenViewCnt].GetComponent<ImageSwap>().Img[0];
    }
    //**************************************************************************************************************************


    //**************************************************************************************************************************
    // 제작창

    public void OnClick_Out_Making()  // 제작창 나가기
    {
        Default_Trap.Trap_Windows[GameManager.Instance.iCnt].SetActive(false);
    }

    public void OnClick_Add() // 만들고 있는 리스트에 추가해주기 // 제작하기
    {



        if (GameManager.Instance.iMake_Now < GameManager.Instance.iMake_Max)   // 만들수 있는 공간이 남아있는가?
        {
            //GameManager.Instance.iCnt
            //GameManager.Instance.iMake_Now++;
           
            // 만들수 있는 조건이 되는가?
            if (GameManager.Instance.myMaterials[(int)GameManager.Instance.WantMaterial_Kind[0]] >= GameManager.Instance.WantMaterial_Amount[0]
            &&  GameManager.Instance.myMaterials[(int)GameManager.Instance.WantMaterial_Kind[1]] >= GameManager.Instance.WantMaterial_Amount[1]
            &&  GameManager.Instance.myMaterials[(int)GameManager.Instance.WantMaterial_Kind[2]] >= GameManager.Instance.WantMaterial_Amount[2]
            &&  GameManager.Instance.Money >= GameManager.Instance.WantMoney )  
            {
                // 제장되는 비용 빼는 부분
                GameManager.Instance.myMaterials[(int)GameManager.Instance.WantMaterial_Kind[0]] -= GameManager.Instance.WantMaterial_Amount[0];
                GameManager.Instance.myMaterials[(int)GameManager.Instance.WantMaterial_Kind[1]] -= GameManager.Instance.WantMaterial_Amount[1];
                GameManager.Instance.myMaterials[(int)GameManager.Instance.WantMaterial_Kind[2]] -= GameManager.Instance.WantMaterial_Amount[2];
                GameManager.Instance.Money -= GameManager.Instance.WantMoney;



                // 만들고 있는 창에 그림교체
                Make_Plus.transform.GetChild(GameManager.Instance.iMake_Now).transform.GetChild(1).gameObject.SetActive(true);
                Make_Plus.transform.GetChild(GameManager.Instance.iMake_Now).transform.GetChild(1).gameObject.GetComponent<Image>().sprite
                                    = Default_Trap._myTrap_Img[GameManager.Instance.iCnt];


                // 제작에 필요한 정보창 꺼주기
                Default_Trap.Trap_Windows[GameManager.Instance.iCnt].SetActive(false);

                // 현재 제작중인 함정수 +1 해주기
                GameManager.Instance.iMake_Now++;
            }
            else // 만들수 없는 경우 ( 자원이 부족하여)
            {

            }




        }
        else // 가득 찼다고 말해주는 창 띄우기
        {

        }
    }

    public void OnClick_Plus()  // 만들수있는 리스트 늘려주기
    {
        Debug.Log(GameManager.Instance.iMake_Max);
        if (GameManager.Instance.iMake_Max < 10)  // 최대 10개로 지정했기때문!  숫자가 아닌 변수로 해줘야 하지만 const 안되네..? 뭐지? public으로 했는데 흠..
        {
            Make_Plus.transform.GetChild(GameManager.Instance.iMake_Max++).gameObject.SetActive(true);
        }

        if (GameManager.Instance.iMake_Max >= 10)
        {
            Make_Plus.transform.GetChild(GameManager.Instance.iMake_Max).gameObject.SetActive(false);
        }
    }
    //**************************************************************************************************************************

}
