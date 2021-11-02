using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImsiButton : MonoBehaviour
{
    [SerializeField]
    private GameObject Btn;
    [SerializeField]
    private GameObject Crd;
    [SerializeField]
    private GameObject App_off;
    public void Yulgi()
    {
        Btn.SetActive(true);
    }

    public void Dadgi()
    {
        Btn.SetActive(false);
    }
    public void Crd_Yulgi()
    {
        Crd.SetActive(true);
    }

    public void Crd_Dadgi()
    {
        Crd.SetActive(false);
    }
    public void App_off_Yulgi()
    {
        App_off.SetActive(true);
    }

    public void App_off_Dadgi()
    {
        App_off.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}