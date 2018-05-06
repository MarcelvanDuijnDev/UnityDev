using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine2D_PlayerController : MonoBehaviour 
{
    [Header("Player Stats")]
    [SerializeField]private float speed;
    [SerializeField]private float jumpHight;

    private Rigidbody2D rb2d;

	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
	}
}
