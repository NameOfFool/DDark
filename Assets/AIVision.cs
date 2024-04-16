using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AIVision : MonoBehaviour
{
    Rigidbody2D rb;
    public float MaxSpeed;
    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameObject player =  GameObject.FindGameObjectWithTag("Player");
	float xStep = Mathf.Sign(transform.position.x - player.transform.position.x);
	float yStep = Mathf.Sign(transform.position.y - player.transform.position.y);
	rb.velocity = new Vector2(-MaxSpeed*xStep, -MaxSpeed*yStep);
    }
}
