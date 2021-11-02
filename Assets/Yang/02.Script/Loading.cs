using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

    private float _fTIme = 0f;
    private float _fLastTime = 3f;
    private Color _Color;

    private Vector3 _vCamPos;

    public GameObject Door = null;
    public GameObject loadAction = null;

    public GameObject sfx;


    // Use this for initialization
    void Start () {

        sfx = GameObject.Find("GlbSfx");
        _Color = GetComponent<Image>().color;
        _vCamPos = Camera.main.transform.position = new Vector3(0, 1.5f, -10) ;
            Camera.main.GetComponent<CameraManager>().enabled = false;

    }

    // Update is called once per frame
    void Update () {
        _fTIme += Time.deltaTime;

        if( _fTIme >= _fLastTime)
        {
            _Color.a -= 0.5f * Time.deltaTime;
        }
        
        //sfx.GetComponent<GlbSfx>().King_laugh();

        if (_Color.a <= 0)
        {
            _vCamPos.y -= 1 * Time.deltaTime;

        }

        GetComponent<Image>().color = _Color;

        if(_vCamPos.y <= -1.5)
        {
            sfx.GetComponent<GlbSfx>().Trap_destroy();
            Door.GetComponent<Animator>().SetBool("IsOn", true);
            Camera.main.GetComponent<CameraManager>().enabled = true;
            GameObject.Instantiate(loadAction);
            this.gameObject.SetActive(false);
            
        }
        Camera.main.transform.position = _vCamPos;

    }
}
