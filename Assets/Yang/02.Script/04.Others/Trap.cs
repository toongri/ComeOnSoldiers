using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    //public float dly = 0;

    [Tooltip("함정 HP")]
    public int hp;
    [Tooltip("함정 공격력")]
    public int damage;
    [Tooltip("함정 공격이 먹히는 시간")]
    public float delay;

    [HideInInspector]
    public bool attacked = false;


    //public int T_Attack;
    //public float T_Dly;

    [SerializeField]
    protected Animator anim = null;

    private SpriteRenderer spriteRenderer;

    public GameObject sfx;

    private void Start()
    {
        sfx = GameObject.Find("GlbSfx");
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void SetAnim()
    {
        Debug.Log("함정 공격");
        anim.SetTrigger("Attack");
        StartCoroutine(TempDisable());
    }

    public void SetAnimDestroy()
    {
        Debug.Log("함정 파괴");
        anim.SetTrigger("Destroy");
        StartCoroutine(TempDestroy());
    }

    private IEnumerator TempDisable()
    {
        yield return new WaitForSeconds(1f);
        Disabled();
    }

    private IEnumerator TempDestroy()
    {
        sfx.GetComponent<GlbSfx>().Trap_destroy();
        yield return new WaitForSeconds(1f);
        Destoried();
    }

    public void Disabled()
    {
        spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
    }

    public void Destoried()
    {
        Destroy(gameObject);
    }

    public void Activation()
    {
        attacked = false;
        spriteRenderer.color = new Color(1f, 1f, 1f);
    }
}