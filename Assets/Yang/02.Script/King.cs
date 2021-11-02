using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {

    [SerializeField]
    private Animator Anim = null;

    private GameObject sfx;

    [SerializeField]
    private GameObject ResultView = null;

    [SerializeField]
    private GameObject WinView = null;
    [SerializeField]
    private GameObject LoseView = null;

    private float _fTime = 0f;

    public bool loading = true;
    private void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.SetInteger("State", 0);
        sfx = GameObject.Find("GlbSfx");
    }

    private void Update()
    {
        //if (GameManager.Instance._MonsterList.Count >= 1)
        //{
        //    loading = false;
        //}
        //    if (GameManager.Instance._MonsterList.Count == 0 && loading == false)
        //{
            
        //        Debug.Log("승리");
        //        StartCoroutine(Win());
            
        //}
    }

    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(10f);
        loading = false;
    }
    private IEnumerator Win()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.bPlay = false;
        GameManager.Instance.Achive[GameManager.Instance.Chapter, GameManager.Instance.Stage] = 1;
        WinView.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            sfx.GetComponent<GlbSfx>().King_die();
            Debug.Log("마왕아 죽어라~~!");
            GameManager.Instance.bPlay = false;
            Anim.SetInteger("State", 2);
            StartCoroutine(LastAnim());
        }
    }

    private IEnumerator LastAnim()
    {
        yield return new WaitForSeconds(2f);
        ResultView.SetActive(true);
        LoseView.SetActive(true);
    }
}
