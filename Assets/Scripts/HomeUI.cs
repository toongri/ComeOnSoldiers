using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum HOMEVIEW
{
    INVENTORY_VIEW = 0,
    MAKING_VIEW,
    STORE_VIEW
}

public class HomeUI : MonoBehaviour
{
    private bool menuOn = false;
    private bool stageOn = false;

    public GameObject menuObject;
    public GameObject stageObject;


    // 홈 메뉴중 어느것을 눌렀는가.  인벤토리 제작 상점 순 // 홈은 씬을 새로 불러오는 방식으로 하기때문에 따로 넣지 않았다.
    [SerializeField]
    private GameObject[] HomeView = new GameObject[3];
    int HomeViewCnt = 0;


    //인벤토리 내 해금시킨것들 이미지 바꿔주는 것
    [SerializeField]
    private GameObject[] InvenItem = new GameObject[4];
    private int[,] iCnt = new int[2, 15];

    // 챕터 누르면 스테이지 맵 나오는 부분
    [SerializeField]
    private GameObject _Map = null;
    [SerializeField]
    private GameObject _DefaultMap = null;
    public GameObject DefaultMap {  get { return _DefaultMap; }  set { _DefaultMap = value; } }


    // 게임내 유아이
    public void OnInventory()
    {
        if (HomeViewCnt == (int)HOMEVIEW.INVENTORY_VIEW)
        {
            if (HomeView[HomeViewCnt].activeSelf)
            {
                HomeView[HomeViewCnt].SetActive(false);
            }
            else
            {
                HomeView[HomeViewCnt].SetActive(true);
            }
        }
        else
        {
            HomeView[HomeViewCnt].SetActive(false);
            HomeViewCnt = (int)HOMEVIEW.INVENTORY_VIEW;
            HomeView[HomeViewCnt].SetActive(true);
        }

        if (HomeView[HomeViewCnt].activeSelf)
        {
            // 그림 바꿔주기
            for (int i = 0; i < 15; i++)
            {
                // 재료 그림 바꿔주기
                if (GameManager.Instance.IsUnRockMaterial[i])
                {

                    InvenItem[0].GetComponentsInChildren<Button>()[i].transform.GetChild(1).gameObject.SetActive(true);
                    // 그림 바꿔주기
                    //InvenItem[0].GetComponentsInChildren<Button>()[i].GetComponentInChildren<Image>().sprite = InvenItem[0].GetComponentsInChildren<Inven_Material>()[i].Img[1];
                    InvenItem[0].GetComponentsInChildren<Button>()[i].transform.GetChild(1).GetComponent<Image>().sprite = InvenItem[0].GetComponentsInChildren<Inven_Material>()[i].Img;
                    // 갯수 알려주기
                    InvenItem[0].GetComponentsInChildren<Text>()[i].text = GameManager.Instance.myMaterials[i] + " / 99";
                }

                // 함정 그림 바꿔주기
                if (GameManager.Instance.IsUnRockTrap[i])
                {

                    InvenItem[1].GetComponentsInChildren<Button>()[i].transform.GetChild(0).gameObject.SetActive(true);
                    // 그림 바꿔주기
                    //InvenItem[0].GetComponentsInChildren<Button>()[i].GetComponentInChildren<Image>().sprite = InvenItem[0].GetComponentsInChildren<Inven_Material>()[i].Img[1];
                    InvenItem[1].GetComponentsInChildren<Button>()[i].transform.GetChild(0).GetComponent<Image>().sprite = InvenItem[1].GetComponentsInChildren<Inven_Trap>()[i].Img;
                    // 갯수 알려주기
                    InvenItem[1].GetComponentsInChildren<Text>()[i].text = GameManager.Instance.myMaterials[i] + " / 99";
                }


            }
        }



    }
    public void OnMaking()
    {

        if (HomeViewCnt == (int)HOMEVIEW.MAKING_VIEW)
        {
            if(HomeView[HomeViewCnt].activeSelf)
            {
                HomeView[HomeViewCnt].SetActive(false);
            }
            else
            {
                HomeView[HomeViewCnt].SetActive(true);
            }
        }
        else
        {
            HomeView[HomeViewCnt].SetActive(false);
            HomeViewCnt = (int)HOMEVIEW.MAKING_VIEW;
            HomeView[HomeViewCnt].SetActive(true);
        }
    }
    public void OnStore()
    {
        if (HomeViewCnt == (int)HOMEVIEW.STORE_VIEW)
        {
            if (HomeView[HomeViewCnt].activeSelf)
            {
                HomeView[HomeViewCnt].SetActive(false);
            }
            else
            {
                HomeView[HomeViewCnt].SetActive(true);
            }
        }
        else
        {
            HomeView[HomeViewCnt].SetActive(false);
            HomeViewCnt = (int)HOMEVIEW.STORE_VIEW;
            HomeView[HomeViewCnt].SetActive(true);
        }
    }


    public void SetStage()
    {
        stageOn = !stageOn;
        stageObject.SetActive(stageOn);
    }

    public void SetMenu()
    {
        menuOn = !menuOn;
        menuObject.SetActive(menuOn);
    }

    public void SceneLoad(string _name)
    {
        SceneManager.LoadScene(_name);
    }

    public void BattleScene(int num)
    {
        /// 임시......
        /// 
        GameManager.Instance.Achive[0, 0] = 1;
        GameManager.Instance.Achive[0, 1] = 1;
        GameManager.Instance.Achive[0, 2] = 1;
        GameManager.Instance.Achive[0, 3] = 1;
        GameManager.Instance.Achive[0, 4] = 1;



        GameManager.Instance.Chapter = num;
        _Map.SetActive(true);
        // 챕터간판
        _Map.transform.GetChild(0).GetChild(0).GetComponentInChildren<Image>().sprite = _DefaultMap.GetComponent<Default_Map>().StageImg[num - 1];
        // 스테이지 오픈된것 확인


        for (int i = 7; i < 10; i++)
        {
            if(_Map.transform.GetChild(0).GetChild(i).gameObject.activeSelf == true )
                _Map.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }


        //for (int i = 0; i < 9; i++)
        //{

        //    if (GameManager.Instance.Achive[num - 1, i] != 0) // 해당 스테이지를 클리어 했을경우
        //    {
        //        _Map.GetComponentsInChildren<Button>()[i].gameObject.SetActive(true);
        //        _Map.GetComponentsInChildren<Button>()[i].transform.GetChild(0).GetComponent<Image>().sprite
        //            = _DefaultMap.GetComponent<Default_Map>().StarImg[GameManager.Instance.Achive[num - 1, i] - 1];


        //    }
        //    else
        //    {
              
        //        _Map.transform.GetChild(0).GetChild(i+1).gameObject.SetActive(true);

        //        //break;
        //    }


        //}



    }


}
