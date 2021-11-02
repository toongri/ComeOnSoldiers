using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    
    public enum MONSTERTYPE
    {
        NONE,
        Top,
        Bot,
        All
    }

    public enum MONSTERNAME
    {
        NONE,
        WARRIOR,
        DWARF,
        MAGICIAN,
        ARCHER,
        SHIELD,
        BOSS1
    }

    public MONSTERTYPE monsterType = MONSTERTYPE.NONE;
    public MONSTERNAME monsterName = MONSTERNAME.NONE;

    private BoxCollider2D box2d;
    private CircleCollider2D circle2d;

    [Tooltip("시야")]
    public float sightRange;
    [Tooltip("체력")]
    public int hp = 0;
    [Tooltip("방어력")]
    public int armor = -1;
    [Tooltip("이동속도")]
    public float speed = 0;
    [Tooltip("공격력")]
    public int damage = 0;
    [Tooltip("공격 쿨타임")]
    public float attackCooltime = 1;
    [Tooltip("방향 1 = 오른쪽 / -1 = 왼쪽")]
    public int isRight = 1;

    [HideInInspector]
    public float cooltime;
    [HideInInspector]
    public bool isAttacking = false;

    //애니메이터
    public Animator animator;

    //몬스터의 상태    => 현재까지 안쓰니 무시
    public float iState=0; // 0 : Idle, 1: Attack

    // 몬스터의 넘버, 몇번째 몬스터인지
    public int iMonster_Num=99;


    private Coroutine myCoroutine = null;

    GameObject sfx;

    // Use this for initialization
    void Start () {


        sfx = GameObject.Find("GlbSfx");
        box2d = GetComponent<BoxCollider2D>();
        circle2d = GetComponentInChildren<CircleCollider2D>();

        if(circle2d == null)
        {
            var sightObject = new GameObject();
            sightObject.transform.SetParent(this.transform);
            var circle = sightObject.AddComponent<CircleCollider2D>();
            circle2d = circle;
            sightObject.AddComponent<Monster_Sight>();
        }

        circle2d.radius = sightRange;

        cooltime = attackCooltime;
        
        
        
        
        
        ///////////////////////////////////////
        animator = GetComponent<Animator>();
        //c2d = GetComponent<Collider2D>(); // Collider2D에 대한 권한 부여
        //m_at = M_Attack;
        ///////////////////////////////////////
    }

    // Update is called once per frame
    virtual public void GameUpdate () {

        if(!isAttacking)
            transform.Translate(Vector2.right * speed * Time.deltaTime * isRight);
        
        if(cooltime >= 0)
        {
            cooltime -= Time.deltaTime;
        }
        
        
        
    }

    public void Hit(int _dmg)
    {

        if (armor > 0 && _dmg <= armor)
        {
            armor -= _dmg;
        }
        else if (armor > 0 && _dmg > armor)
        {
            int diff = _dmg - armor;
            armor -= _dmg;
            hp -= diff;
        }
        else if (armor <= 0)
        {
            hp -= _dmg;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Trap"))
        {
            var trapScale = collision.GetComponent<TrapScale>();
            var trap = collision.GetComponent<Trap>();
            var type = trapScale.type;

            if (type.ToString() != monsterType.ToString() && trap.hp > 0)
            {
                Debug.Log("맞음");
                //trap.SetAnim();
                if (trap.attacked == false)
                {
                    trap.attacked = true;
                    myCoroutine = StartCoroutine(MonsterHit(trap.delay, trap));
                    //StartCoroutine(MonsterHit(trap.delay, trap));

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Trap"))
        {
            var trap = collision.GetComponent<Trap>();

            if (myCoroutine != null)
            {
                StopCoroutine(myCoroutine);
                Debug.Log("탈출했다");

            }
        }
    }

    public IEnumerator MonsterHit(float _delay, Trap _trap)
    {
        yield return new WaitForSeconds(_delay);

        _trap.SetAnim();
        Hit(_trap.damage);
        if (hp <= 0)
        {
            Debug.Log("죽음");
            animator.SetInteger("State", 1);
            GameManager.Instance.RemoveMonsterList(this);
            sfx.GetComponent<GlbSfx>().Die();
            yield return new WaitForSeconds(1.5f);
            Destroy(this.gameObject);
        }
    }

    public IEnumerator MonsterBombHit(int damage)
    {

        Hit(damage);
        if (hp <= 0)
        {
            Debug.Log("죽음");
            animator.SetInteger("State", 1);
            GameManager.Instance.RemoveMonsterList(this);
            sfx.GetComponent<GlbSfx>().Die();
            yield return new WaitForSeconds(1.5f);
            Destroy(this.gameObject);
        }
    }

    public IEnumerator CheckAnimating(string _name)
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(_name))
        {
            Debug.Log("전환중");
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8f)
        {
            Debug.Log("플레이중");
            yield return null;
        }

        Debug.Log("플레이끝");
        isAttacking = false;
    }



}