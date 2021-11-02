using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStage : MonoBehaviour {

    [SerializeField]
    private int _Stage = 0;


    public void OnStageClick()
    {
        GameManager.Instance.Stage = _Stage;
        SceneManager.LoadScene("Main");
    }

}
