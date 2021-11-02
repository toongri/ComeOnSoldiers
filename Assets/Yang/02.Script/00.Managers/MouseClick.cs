using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MouseClick : MonoBehaviour
{

    [SerializeField]
    private Sprite[] img;

    
    [SerializeField]
    private GameObject Stage_bt = null;

    [SerializeField]
    private GameObject Info_View = null;
    [SerializeField]
    private GameObject Stage = null;
    [SerializeField]
    private GameObject Traps = null;


    private float Dist = 0f;
    private Vector3 MouseStart;
    private Vector3 derp;


    //  켜는 창
    [SerializeField]
    private Trap_Default Default_Windows = null;

    

    // 디폴트 함정 <- 이미지를 가져오기 위해
    [SerializeField]
    private Trap_Default Default_Trap = null;

    // 텍스트
    [SerializeField]
    private Trap_Materials[] _Material_text;
    public Trap_Materials[] Material_text { get { return _Material_text; }  set { _Material_text = value; } }


    // 웨이브 창
    [SerializeField]
    private GameObject _Wave = null;

    // 시작과 함정창
    [SerializeField]
    private GameObject _BottomMenu = null;


    // 연출씬
    [SerializeField]
    private GameObject Loading = null;


    [SerializeField]
    private GameObject skillview = null;



    private void Start()
    {
        Dist = Camera.main.transform.position.z;
    }

    // Update is called once per frame
    public void GameUpdate()
    {




        //if (!EventSystem.current.IsPointerOverGameObject() /*&& GameManager.Instance._bTrapping == false*/)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        MouseStart = new Vector3(0, Input.mousePosition.y, Dist);
        //        MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
        //        MouseStart.z = Camera.main.transform.position.z;
        //        Debug.Log(MouseStart.ToString());
        //    }
        //    else if (Input.GetMouseButton(0))
        //    {
        //        var MouseMove = new Vector3(0, Input.mousePosition.y, Dist);
        //        MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
        //        MouseMove.z = Camera.main.transform.position.z;
        //        var Diff = (MouseMove - MouseStart);
        //        Camera.main.transform.position = Camera.main.transform.position - Diff;
        //    }
        //}

    }



    public void OnClick_Make()
    {
        if (!GameManager.Instance.bPlay)
        {
            Camera.main.transform.position = new Vector3(-20, 0, -17);
            Info_View.SetActive(false);
            Debug.Log("제작실로 이동");
        }

    }

    public void OnClick_Stage()
    {
        if (!GameManager.Instance.bPlay)
        {
            Camera.main.transform.position = new Vector3(0, 0, -17);

        }
    }

    public void OnClick_Book()
    {
        if (!GameManager.Instance.bPlay)
        {
            Camera.main.transform.position = new Vector3(20, 0, -17);
            Info_View.SetActive(false);

        }

    }

    public void OnClick_Store()
    {
        if (!GameManager.Instance.bPlay)
        {
            Camera.main.transform.position = new Vector3(40, 0, -17);
            Info_View.SetActive(false);

        }

    }

    public void OnClick_Start()
    {
        if (!GameManager.Instance.bPlay)
        {
            GameManager.Instance.bPlay = true;
            Stage.transform.position = new Vector3(0, 2.8f, 0);
            Traps.transform.position = new Vector3(0, 0, 0);
            Info_View.SetActive(false);

        }
    }

    

    public void OnClick_Out_Making()
    {
        Default_Windows.Trap_Windows[GameManager.Instance.iCnt].SetActive(false);
    }


    //public void OnClick_Add()
    //{
    //    if(GameManager.Instance.iMake_Now <= GameManager.Instance.iMake_Max)
    //    {
    //        //GameManager.Instance.iCnt
    //        //GameManager.Instance.iMake_Now++;

    //        Make_Plus.transform.GetChild(GameManager.Instance.iMake_Now).gameObject.GetComponent<Image>().sprite
    //                                = Default_Trap._myTrap_Img[GameManager.Instance.iCnt];
    //        Default_Trap.Trap_Windows[GameManager.Instance.iCnt].SetActive(false);
    //        GameManager.Instance.iMake_Now++;
    //    }
    //    else // 가득 찼다고 말해주는 창 띄우기
    //    {

    //    }
    //}

    //public void OnClick_Plus()
    //{
    //    Debug.Log(GameManager.Instance.iMake_Max);
    //    if(GameManager.Instance.iMake_Max < 10)
    //    {
    //        Make_Plus.transform.GetChild(GameManager.Instance.iMake_Max++).gameObject.SetActive(true);
    //    }

    //    if (GameManager.Instance.iMake_Max >= 10)
    //    {
    //        Make_Plus.transform.GetChild(GameManager.Instance.iMake_Max).gameObject.SetActive(false);
    //    }
    //}

    public void OnGameStart()
    {
        GameObject.Find("GlbSfx").GetComponent<GlbSfx>().Open();
        GameManager.Instance.bPlay = true;
        _Wave.SetActive(false);
        _BottomMenu.SetActive(false);

        Loading.SetActive(true);

        skillview.SetActive(true);
    GameObject.Find("GlbBgm").GetComponent<GlbBgm>().StageOn();
        //StartCoroutine(GameObject.Find("CheckWave").GetComponent<CheckWave>().WaveStart(4f));


    }

    public void OnGameStop()
    {
        GameManager.Instance.bPlay = false;
    }

 
    public void OnHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void OnReplay()
    {
        SceneManager.LoadScene("Main");
    }
}
