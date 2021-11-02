using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour {

    private InfoManager _instance = null;
    public InfoManager Instance { get { return _instance; } }

    // 메이킹 윈도우 창 
    private int _iCnt = 0;
    public int iCnt { get { return _iCnt; } set { _iCnt = value; } }

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

    // 게임내 재료
    private MATERIALS _myMaterials;
    public MATERIALS myMaterials { get { return _myMaterials; } set { myMaterials = value; } }


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
