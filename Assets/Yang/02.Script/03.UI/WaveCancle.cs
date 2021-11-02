using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCancle : MonoBehaviour {

    [SerializeField]
    private GameObject _Wave = null;

    public void OnCancle()
    {
        _Wave.SetActive(false);
    }
}
