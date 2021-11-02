using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven_Explain : MonoBehaviour {


    [SerializeField]
    private GameObject Explain_Window = null;


    public void Exit()
    {
        Explain_Window.SetActive(false);
    }


}
