using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven_Material : MonoBehaviour
{

    [SerializeField]  // 몇번쨰 재료인가.
    private int _Material_num = 0;
    public int Material_num { get { return _Material_num; } set { _Material_num = value; } }
    [SerializeField] // 설명창
    private GameObject Explain_window = null;

    //[SerializeField]
    //private Sprite[] _Img = new Sprite[2];
    //public Sprite[] Img { get { return _Img; } set { _Img = value; } }


    [SerializeField]
    private Sprite _Img = null;
    public Sprite Img { get { return _Img; } set { _Img = value; } }


    //

    public void Explain()
    {
        if (GameManager.Instance.IsUnRockMaterial[_Material_num]) // 해금되어 있으면 실행한다.
        {
            // 창 띄어주기
            Explain_window.SetActive(true);
        }
    }
}
