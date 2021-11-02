using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap_Default : Trap_Item
{


    //함정 이미지
    [SerializeField]
    public Sprite[] _myTrap_Img;
    public Sprite[] Trap_Img { get { return _myTrap_Img; } set { _myTrap_Img = value; } }


    // 함정 선택시 만드는 창
    [SerializeField]
    private GameObject[] _myTrap_Windows;
    public GameObject[] Trap_Windows { get { return _myTrap_Windows; } set { _myTrap_Windows = value; } }



    
}
