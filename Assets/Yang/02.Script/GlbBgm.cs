using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlbBgm : MonoBehaviour {

    public AudioClip Lb;
    public AudioClip Mn;
    private bool isitplaying;
    private AudioSource audio;
    public Button btn;

    private void Awake()
    {
        GameObject check = GameObject.Find("GlbBgm");
        if (check != null && check != this.gameObject)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
        this.audio = this.gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        if (audio.isPlaying)
            btn.GetComponent<Image>().sprite = btn.GetComponent<ImageSwap>().Img[0];
        else
            btn.GetComponent<Image>().sprite = btn.GetComponent<ImageSwap>().Img[1];
    }
    void OnLevelWasLoaded(int level)
    {
        isitplaying = audio.isPlaying;
        if (level == 0)
        {
            audio.clip = Lb;
            if (isitplaying)
                audio.Play();
        }
    }
    public void StageOn()
    {
        isitplaying = audio.isPlaying;
        audio.clip = Mn;
        if (isitplaying)
            audio.Play();
    }


    public void BgmOnOff()
    {
        if (audio.isPlaying)
        {
            audio.Pause();
            btn.GetComponent<Image>().sprite = btn.GetComponent<ImageSwap>().Img[1];
        }
        else
        {
            audio.Play();
            btn.GetComponent<Image>().sprite = btn.GetComponent<ImageSwap>().Img[0];
        }
    }
}