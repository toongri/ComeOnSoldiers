using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven_Trap : MonoBehaviour {

    [SerializeField]  // 몇번쨰 함정인가.
    private int _Trap_num = 0;
    public int Trap_num { get { return _Trap_num; } set { _Trap_num = value; } }

    [SerializeField] // 만들어지는 시간
    private float _MakingTime = 0;
    public float MakingTime { get { return _MakingTime; } set { _MakingTime = value; } }

    [SerializeField] // 설명창
    private GameObject Explain_window = null;

    [SerializeField]
    private Sprite _Img = null;
    public Sprite Img { get { return _Img; } set { _Img = value; } }

    private void start()
    {
        //// 시작할때 함정이 해금되어있는가에 따른 확인
        //for (int i = 0; i < 15; i++)
        //{
        //    if (GameManager.Instance.IsUnRockMaterial[i])
        //        GetComponent<Image>().sprite = GetComponent<Inven_Material>().Img[1];
        //    else
        //        GetComponent<Image>().sprite = GetComponent<Inven_Material>().Img[0];


        //}
    }
    public void Explain()
    {
        if (GameManager.Instance.IsUnRockMaterial[_Trap_num]) // 해금되어 있으면 실행한다.
        {
            // 창 띄어주기
            Explain_window.SetActive(true);
        }
    }
}
