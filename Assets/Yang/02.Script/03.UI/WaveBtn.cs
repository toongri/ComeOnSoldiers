using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBtn : MonoBehaviour {


    [SerializeField]
    private GameObject _Wave = null;

    public void OnWave()
    {
        _Wave.SetActive(true);
    }
}
