using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Skill {

    [SerializeField]
    private int  _Damage = 0;
    public int  Damage { get { return _Damage; } set { _Damage = value; } }
    // Use this for initialization

    private void Start()
    {
            StartCoroutine(Explosioned());

    }

    private IEnumerator Explosioned()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            StartCoroutine(collision.GetComponent<Monster>().MonsterBombHit(_Damage));
        }
    }

}
