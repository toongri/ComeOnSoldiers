using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default_Map : MonoBehaviour {


    [SerializeField]
    private Sprite[] _StageImg = new Sprite[3];
    public Sprite[] StageImg { get { return _StageImg; } set { _StageImg = value; } }



    [SerializeField]
    private Sprite[] _StarImg = new Sprite[4];
    public Sprite[] StarImg { get { return _StarImg; } set { _StarImg = value; } }



}
