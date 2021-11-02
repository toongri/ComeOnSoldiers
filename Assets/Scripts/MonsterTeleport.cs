using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTeleport : MonoBehaviour
{
    public Transform teleportPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.transform.position = teleportPosition.position;
            collision.GetComponent<Monster>().isRight *= -1;
            var pos = collision.gameObject.transform.localScale;
            pos.x *= -1;
            collision.gameObject.transform.localScale = pos;
        }
    }
}
