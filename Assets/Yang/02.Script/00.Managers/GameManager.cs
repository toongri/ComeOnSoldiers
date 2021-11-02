using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MATERIALS
{
   M1,
   M2,
   M3,
   M4,
   M5,
   M6,
   M7,
   M8,
   M9,
   M10,
   M11,
   M12
}


public class GameManager : MonoBehaviour
{
    
    

    private static GameManager _instance = null;
    public static GameManager Instance { get { return _instance; } }
    
    // 다른 매니저들
    public SaveData dataManager;

    // 선택한 챕터와 스테이지
    private int _Chapter = 0;
    public int Chapter { get { return _Chapter; } set { _Chapter = value; } }
    private int _Stage = 0;
    public int Stage { get { return _Stage; } set { _Stage = value; } }

    //자신이 깬 챕터와 스테이지 별 갯수, 0이면 안깬것.
    private int[,] _AChieve = new int[3, 9];
    public int[,] Achive { get { return _AChieve; } set { _AChieve = value; } }



    // 용사들
    [SerializeField]
    private Monster _warrior = null;
    [SerializeField]
    private Monster _dwarf = null;
    [SerializeField]
    private Monster _magician = null;

    //몬스터와 함정을 관리할 리스트
    private HashSet<Monster> _monsterList = new HashSet<Monster>();
    public HashSet<Monster> _MonsterList { get { return _monsterList; } set { _monsterList = value; } }


    //게임의 시작과 종료를 알려주는 변수
    private bool _bPlay = false;
    public bool bPlay { get { return _bPlay; } set { _bPlay = value; } }

    // 게임의 속도 2배 기능
    private int iPlay_Speed = 1;


    // 몬스터 생성을 위한 시간변수
    private float fCurrent_Time = 0f;
    [SerializeField]
    private float fMake_Time = 2f;

    // 스테이지에 누가나올지 정해져있는 리스트
    List<int> iStage = new List<int> { 1, 1, 2, 2, 3 };

    // 몬스터의 넘버, 몇번째 몬스터인지
    private int iNum = 0;

    // 메이킹 윈도우 창 
    private int _iCnt = 0;
    public int iCnt { get { return _iCnt; }  set { _iCnt = value; } }

    // 만들고 있는 함정 최대 수 
    private int _iMake_Max = 2;
    public int iMake_Max { get { return _iMake_Max; } set { _iMake_Max = value; } }


    // 만들고 있는 함정 수
    private int _iMake_Now = 0;
    public int iMake_Now { get { return _iMake_Now; } set { _iMake_Now = value; } }

    // 만들수 있는 함정 확인
    [SerializeField]
    private bool[] _bMake = { }; // <- 등로랑 갈호 지우면 안됨... 왤까..
    public bool[] bMake { get { return _bMake; } set { _bMake = value; } }


    // ***************************************************************************************************************//
    // 게임내 플레이어가 가지고 있는 돈, 아이템, 스킬, 등등
    [SerializeField]
    private int _Money = 0;
    public int Money {  get { return _Money; }  set { _Money = value; } }


    // 게임내 플레이어가 가지고 있는 재료
    [SerializeField]
    private int[] _myMaterials = new int[12];   // 이것도 상수가 아니라 변수로 바꿔야된다... const...
    public int[] myMaterials { get { return _myMaterials; }  set { myMaterials = value; } }
    // 플레이어가 재료를 해금했는가?
    [SerializeField]
    private bool[] _IsUnRockMaterial = new bool[15];
    public bool[] IsUnRockMaterial { get { return _IsUnRockMaterial; } set { _IsUnRockMaterial = value; } }

    // 플레이어가 함정을 해금했는가?
    [SerializeField]
    private bool[] _IsUnRockTrap = new bool[15];
    public bool[] IsUnRockTrap { get { return _IsUnRockTrap; } set { _IsUnRockTrap = value; } }

    // 플레이어 만들고 있는 함정 시간
    [SerializeField]
    private float[] _MakeTime = new float[10];
    public float[] MakTime { get { return _MakeTime; }  set { _MakeTime = value; } }


    // 플레이어가 보유한 스킬(모든)
    [SerializeField]
    private GameObject[] _AllSKill = new GameObject[10];
    public GameObject[] ALlSkill { get { return _AllSKill; } set { _AllSKill = value; } }

    // 플레이어가 선택한 스킬
    [SerializeField]
    private GameObject[] _SKill = new GameObject[3];
    public GameObject[] Skill { get { return _SKill; } set { _SKill = value; } }


    // ***************************************************************************************************************//


    // 이렇게 해도 될까.. 해당 아이템을 제작할때 클릭시 클릭한 아이템의 정보를 창에서 받게하기 위해..
    private MATERIALS[] _WantMaterial_Kind = new MATERIALS[3];
    public MATERIALS[] WantMaterial_Kind { get { return _WantMaterial_Kind; } set { _WantMaterial_Kind = value; } }
    private int[] _WantMaterial_Amount = new int[3];
    public int[] WantMaterial_Amount { get { return _WantMaterial_Amount; } set { _WantMaterial_Amount = value; } }
    private int _WantMoney = 0;
    public int WantMoney { get { return _WantMoney; } set { _WantMoney = value; } }

    private void Awake()
    {
        if( GameManager.Instance != null) // 씬을 다시 불러올떄 또 생성되는것 방지
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        if (_instance == null)
            _instance = this;
        
        if (dataManager == null)
        {
            var go = new GameObject();
            go.AddComponent<SaveData>();
            dataManager = go.GetComponent<SaveData>();
            go.name = "DataManager";
        }

        _bPlay = false;
    }

   
    // Use this for initialization
    void Start()
    {
        _bPlay = false;
    }

    // Update is called once per frame
    void Update()
    {


        //if (Input.GetKeyDown(KeyCode.Space))
        //    _bPlay = !_bPlay;
        
        if (_bPlay && Application.loadedLevelName == "Main") // Main씬에서만 돌아가게 한다.
        {
            //Debug.Log("돌아가는 중");
            //Debug.Log(_bPlay);
            //Debug.Log("시작!");
            // 몬스터 소환부분 => 게임중인 부분

            //fCurrent_Time += Time.deltaTime;
            //if (fCurrent_Time >= fMake_Time && iStage.Count != 0)
            //{
            //    fCurrent_Time = 0f;


            //    switch (iStage[0])
            //    {
            //        case 1:
            //            _monsterList.Add(GameObject.Instantiate(_warrior));
            //            break;
            //        case 2:
            //            _monsterList.Add(GameObject.Instantiate(_dwarf));
            //            break;
            //        case 3:
            //            _monsterList.Add(GameObject.Instantiate(_magician));
            //            break;
            //        default:
            //            break;
            //    }

            //    // 몬스터 넘버링
            //    //_monsterList[iNum].iMonster_Num = iNum;
            //    //iNum++;


            //    iStage.RemoveAt(0);
            //}

            Physics2D.IgnoreLayerCollision(9, 9, true);

            // 모든 객체의 업데이트 부분.
            foreach(var m in _monsterList)
            {
                m.GameUpdate();
            }

            
            //_monsterList.ForEach(x => x.GameUpdate());
        }
        else
        {
            //게임중이 아닐때 마우스로 설치하는 상태......어?! 게임도중 스피드 2배로 하는 것도 해줘야되는데.... 나중에 생각하자! 
            //_mouseMgr.GameUpdate();
        }

    }

    public void RemoveMonsterList(Monster _monster)
    {
        _monsterList.Remove(_monster);
    }



}
