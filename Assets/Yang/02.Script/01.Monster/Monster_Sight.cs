using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Sight : MonoBehaviour {

    private Monster monster;

    GameObject sfx;
    private void Start()
    {
        monster = GetComponentInParent<Monster>();
        sfx = GameObject.Find("GlbSfx");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            var trapScale = collision.GetComponent<TrapScale>();
            var trap = collision.GetComponent<Trap>();
            var type = trapScale.type;

            if (trap.hp <= 0 || trap.attacked == true)
            {
                return;
            }

            if(type == TrapScale.Type.Top)
            {
                if(monster.transform.position.y >= trap.transform.position.y)
                {
                    return;
                }
            }

            if ((type.ToString() == monster.monsterType.ToString() && monster.cooltime < 0) || monster.monsterType == Monster.MONSTERTYPE.All)
            {
                monster.cooltime = monster.attackCooltime;

                string triggerName = null;

                if (monster.armor > 0)
                {
                    triggerName = "Attack2";
                    monster.animator.SetTrigger(triggerName);
                }
                else
                {
                    triggerName = "Attack";
                    monster.animator.SetTrigger(triggerName);
                }

                monster.isAttacking = true;
                StartCoroutine(monster.CheckAnimating(triggerName));

                Debug.Log(" trap.hp " + trap.hp);
                Debug.Log(" monster.damage " + monster.damage);

                StartCoroutine(AtkSound(monster));
                StartCoroutine(HitSound(monster));

                trap.hp -= monster.damage;
                if (trap.hp <= 0)
                {
                Debug.Log(" 발동하는가 ");

                    trap.SetAnimDestroy();
                }

            }


        }
    }

    private IEnumerator AtkSound( Monster monster)
    {
        float _delay = 0;
        switch(monster.monsterName)
        {
            case Monster.MONSTERNAME.WARRIOR:
                _delay = 0;
                break;
            case Monster.MONSTERNAME.MAGICIAN:
                _delay = 0;
                break;
            case Monster.MONSTERNAME.ARCHER:
                _delay = 0.5f;
                break;
            case Monster.MONSTERNAME.DWARF:
                _delay = 0;
                break;
            case Monster.MONSTERNAME.SHIELD:
                _delay = 0;
                break;
            case Monster.MONSTERNAME.BOSS1:
                _delay = 0;
                break;
        }
        yield return new WaitForSeconds(_delay);


        sfx.GetComponent<GlbSfx>().Atk(); // 기합소리
    }

    private IEnumerator HitSound(Monster monster)
    {
        float _delay = 0;
        switch (monster.monsterName)
        {
            case Monster.MONSTERNAME.WARRIOR:
                _delay = 0;
                break;
            case Monster.MONSTERNAME.MAGICIAN:
                _delay = 0;
                break;
            case Monster.MONSTERNAME.ARCHER:
                _delay = 0.5f;
                break;
            case Monster.MONSTERNAME.DWARF:
                _delay = 1;
                break;
            case Monster.MONSTERNAME.SHIELD:
                _delay = 0;
                break;
            case Monster.MONSTERNAME.BOSS1:
                _delay = 0;
                break;
        }
        yield return new WaitForSeconds(_delay);


        sfx.GetComponent<GlbSfx>().Hit(); // 휘두르는 소리
    }
}
