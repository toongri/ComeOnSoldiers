using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap_Materials : MonoBehaviour {


    [SerializeField] // 재료 갯수
    private Text[] _myText = new Text[4];
    public Text[] myText {  get { return _myText; } set { _myText = value; } }

    [SerializeField] // 만드는 시간
    private Text _myTime = null;
    public Text myTime { get { return _myTime; } set { _myTime = value; } }




}
