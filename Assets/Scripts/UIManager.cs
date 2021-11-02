using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool invenState = false;

    public GameObject inven;

    public void InvenOnOff()
    {
        invenState = !invenState;
        inven.SetActive(invenState);
    }
}
