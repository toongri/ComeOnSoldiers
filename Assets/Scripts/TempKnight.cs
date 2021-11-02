using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempKnight : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int speed;

    private bool temp;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (!temp)
        {

            rb2d.AddForce(Vector2.right * speed * Time.deltaTime);
        }

        if (transform.position.x < -20)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Test")
        {
            temp = true;
            rb2d.velocity = new Vector2(0, 0);

            int xForce = Random.Range(80000, 120000);
            int yForce = Random.Range(40000, 70000);
            rb2d.AddForce(Vector2.left * xForce * Time.deltaTime);
            rb2d.AddForce(Vector2.up * yForce * Time.deltaTime);

        }
    }
}
