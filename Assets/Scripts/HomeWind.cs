using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWind : MonoBehaviour
{
    public float resetPos = -7.5f;
    public float startPos = 7.5f;
    public float speed;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.transform.position = WindPos();
    }

    private void FixedUpdate()
    {
        if(this.transform.position.x <= resetPos)
        {
            this.transform.position = WindPos();
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private Vector2 WindPos()
    {
        float randomX = Random.Range(0, 0.5f);
        float randomY = Random.Range(-2.0f, 7.25f);
        float randomSpeed = Random.Range(1f, 2f);
        int layer = Random.Range(-2, 0);
        speed = randomSpeed;
        spriteRenderer.sortingOrder = layer;
        return new Vector2(startPos + randomX, randomY);
    }
}
