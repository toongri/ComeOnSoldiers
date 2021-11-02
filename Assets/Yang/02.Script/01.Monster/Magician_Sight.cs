using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician_Sight : MonoBehaviour {

    //private Magician parent;
    //private Trap trap;
    //private void Start()
    //{
    //    parent = gameObject.GetComponentInParent(typeof(Magician)) as Magician;
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if ((collision.tag == "T_Trap" || collision.tag == "B_Trap") && parent.M_Attack > 0)
    //    {
    //        trap = collision.transform.GetComponent<Trap>();

    //        Vector3 vec1 = parent.transform.position;
    //        Vector3 vec2 = trap.transform.position;
    //        if (parent.vec * vec1.x < parent.vec * vec2.x && (vec1.y - vec2.y) <= 1)
    //        {
    //            parent.iState = 1;
    //            parent.animator.SetInteger("Condi", 1);
    //            //trap.hp -= parent.M_Attack;
    //            if (trap.hp <= 0)
    //                trap.tag = "trapoff";
    //            parent.m_ct = parent.M_Cooltime;
    //        }

    //    }
    //}
}
