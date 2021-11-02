using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum TRAP_TYPE
{
    TRAP_NONE= 0,
    TRAP_1,
    TRAP_2,
    TRAP_3,
    TRAP_4,
    TRAP_5,
    TRAP_6,
    TRAP_7,
    TRAP_8,
    TRAP_9,
    TRAP_10,
    TRAP_11,
    TRAP_12,
}


public class Trap_Item : MonoBehaviour {

    //함정 종류
    [SerializeField]
    protected TRAP_TYPE myTrap_Type;
    public TRAP_TYPE Trap_Type { get { return myTrap_Type; } set { myTrap_Type = value; } }

    // 함정을 만들기위한 재료종류
    [SerializeField]
    protected MATERIALS[] _NeedMaterial_Kind = new MATERIALS[3];
    public MATERIALS[] NeedMaterial_Kind { get { return _NeedMaterial_Kind; } set { _NeedMaterial_Kind = value; } }
    [SerializeField]
    protected int[] _NeedMaterial_Amount = new int[3];
    public int[] NeedMaterial_Amount { get { return _NeedMaterial_Amount; } set { _NeedMaterial_Amount = value; } }
    [SerializeField]
    protected int _NeedMoney;
    public int NeedMoney { get { return _NeedMoney; } set { _NeedMoney = value; } }

    //함정을 만드는 시간
    [SerializeField]
    private float _MakingTime = 0;

    // 함정 디폴트 값
    [SerializeField]
    protected Trap_Default _Default_Trap = null;
    public Trap_Default Default_Trap { get { return _Default_Trap; } set { _Default_Trap = value; } }




    void Start () {

      
    }

    private void PrintMaterials(TRAP_TYPE myTrap_Type)
    {
        int i = (int)myTrap_Type -1;
        _Default_Trap.Trap_Windows[i].SetActive(true);

        _Default_Trap.Trap_Windows[i].GetComponent<Trap_Materials>().myText[0].text
            = GameManager.Instance.myMaterials[(int)NeedMaterial_Kind[0]] + " / " + _NeedMaterial_Amount[0];

        _Default_Trap.Trap_Windows[i].GetComponent<Trap_Materials>().myText[1].text
            = GameManager.Instance.myMaterials[(int)NeedMaterial_Kind[1]] + " / " + _NeedMaterial_Amount[1];

        _Default_Trap.Trap_Windows[i].GetComponent<Trap_Materials>().myText[2].text
            = GameManager.Instance.myMaterials[(int)NeedMaterial_Kind[2]] + " / " + _NeedMaterial_Amount[2];

        _Default_Trap.Trap_Windows[i].GetComponent<Trap_Materials>().myText[3].text
            = GameManager.Instance.Money + " / " + _NeedMoney;
        GameManager.Instance.iCnt = i;

        // 만드는 시간 전해주기
        _Default_Trap.Trap_Windows[i].GetComponent<Trap_Materials>().myTime.text = _MakingTime.ToString() ;
    }



    public void OnTrapButtonSelect()
    {



            if (GameManager.Instance.bMake[(int)myTrap_Type - 1]) // 함정이 오픈되어 있나? 
            {
             //  필요한 재료의 종류를 알려준다.
                 GameManager.Instance.WantMaterial_Kind[0] = NeedMaterial_Kind[0];
                 GameManager.Instance.WantMaterial_Kind[1] = NeedMaterial_Kind[1];
                 GameManager.Instance.WantMaterial_Kind[2] = NeedMaterial_Kind[2];


             //  재료당 필요한 양을 알려준다.
                GameManager.Instance.WantMaterial_Amount[0] = _NeedMaterial_Amount[0];
                GameManager.Instance.WantMaterial_Amount[1] = _NeedMaterial_Amount[1];
                GameManager.Instance.WantMaterial_Amount[2] = _NeedMaterial_Amount[2];
                GameManager.Instance.WantMoney = _NeedMoney;


                PrintMaterials(myTrap_Type);

        }
        else  // 잠겨있나?
            {

            }

        
    }

}



