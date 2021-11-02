using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private Animator Anim = null;
    [SerializeField]
    private GameObject _Explosion = null;

    private int _Damage = 100;
    public int Damage { get { return _Damage; } set { _Damage = value; } }

	// Use this for initialization
	void Start () {
        Debug.Log("만들어짐");
        Anim = GetComponent<Animator>();
        StartCoroutine(BombActive());
    }

    private IEnumerator BombActive()
    {
        Anim.SetTrigger("Active");
        yield return new WaitForSeconds(3);
        _Explosion.transform.position = this.transform.position;

        Instantiate(_Explosion);
        _Explosion.GetComponent<Explosion>().Damage = _Damage;
        Destroy(gameObject);
    }

    

}
