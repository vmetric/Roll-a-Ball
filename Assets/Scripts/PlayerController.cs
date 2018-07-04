﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
		
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVerticle = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVerticle);

		rb.AddForce (movement * speed);
    }
}