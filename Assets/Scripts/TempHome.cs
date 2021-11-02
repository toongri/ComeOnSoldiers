using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHome : MonoBehaviour
{
    public GameObject[] temps;

    public float delay;

	// Use this for initialization
	void Start () {
        StartCoroutine(Create());
	}
	

    private IEnumerator Create()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            int randomIndex = Random.Range(0, temps.Length);

            Instantiate(temps[randomIndex], new Vector2(-7, -4.8f), Quaternion.identity);
        }
    }
}
