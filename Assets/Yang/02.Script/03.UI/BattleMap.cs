using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMap : MonoBehaviour {


    [SerializeField]
    private GameObject _Map = null;

    public void OnCanCle()
    {
        _Map.SetActive(false);

    }

}
