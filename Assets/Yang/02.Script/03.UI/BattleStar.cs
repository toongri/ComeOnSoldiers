using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStar : MonoBehaviour {


    //별 이미지 가진 것
    [SerializeField]
    private Sprite[] _Star = new Sprite[3];
    public Sprite[] Stat { get { return _Star; } set { _Star = value; } }






}
