using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlbSfx : MonoBehaviour {

    private AudioSource audio;
    public AudioClip boss1_die;
    public AudioClip boss1_atk;
    public AudioClip[] atk = new AudioClip[4];
    public AudioClip bombexplosion;
    public AudioClip bombfuse;
    public AudioClip[] die = new AudioClip[3];
    public AudioClip door_shaking;
    public AudioClip hit;
    public AudioClip king_die;
    public AudioClip king_laugh;
    public AudioClip magician_atk;
    public AudioClip open;
    public AudioClip reactive;
    public AudioClip spike;
    public AudioClip trap_destroy;

    public Button btn;

    private bool playing = true;
    private void Awake()
    {
        GameObject check = GameObject.Find("GlbSfx");
        if (check != null && check != this.gameObject)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
        this.audio = this.gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        if (playing)
            btn.GetComponent<Image>().sprite = btn.GetComponent<ImageSwap>().Img[0];
        else
            btn.GetComponent<Image>().sprite = btn.GetComponent<ImageSwap>().Img[1];
    }
    public void SfxOnOff()
    {
        if (playing)
        {
            playing = false;
            btn.GetComponent<Image>().sprite = btn.GetComponent<ImageSwap>().Img[1];
        }
        else
        {
            playing = true;
            btn.GetComponent<Image>().sprite = btn.GetComponent<ImageSwap>().Img[0];
        }
    }

    public void Atk()
    {
        if(playing)
        {
            int i = UnityEngine.Random.Range(0, 3);
            audio.PlayOneShot(atk[i]);
        }
    }
    public void Die()
    {
        if (playing)
        {
            int i = UnityEngine.Random.Range(0, 2);
            audio.PlayOneShot(die[i]);
        }
    }
    public void Boss1_die()
    {
        if (playing)
            audio.PlayOneShot(boss1_die);
    }
    public void Boss1_atk()
    {
        if (playing)
            audio.PlayOneShot(boss1_atk);
    }
    public void Bombexplosion()
    {
        if (playing)
            audio.PlayOneShot(bombexplosion);
    }
    public void Bombfuse()
    {
        if (playing)
            audio.PlayOneShot(bombfuse);
    }
    public void Door_shaking()
    {
        if (playing)
            audio.PlayOneShot(door_shaking);
    }
    public void Hit()
    {
        if (playing)
            audio.PlayOneShot(hit);
        Debug.Log("소리가났다");
    }
    public void King_die()
    {
        if (playing)
            audio.PlayOneShot(king_die);
    }
    public void King_laugh()
    {
        if (playing)
            audio.PlayOneShot(king_laugh);
    }
    public void Open()
    {
        if (playing)
            audio.PlayOneShot(open);
    }
    public void Reactive()
    {
        if (playing)
            audio.PlayOneShot(reactive);
    }
    public void Spike()
    {
        if (playing)
            audio.PlayOneShot(spike);
    }
    public void Trap_destroy()
    {
        if (playing)
            audio.PlayOneShot(trap_destroy);
    }
}
