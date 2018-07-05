using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public float brakeSpeed;

	private Rigidbody rb;
	private int count;
	private bool win;

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
		win = false;
	}
		
    void FixedUpdate ()
    {
		if (win) {
			rb.AddForce (-brakeSpeed * rb.velocity);
		}
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVerticle = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVerticle);
		if (!win) {
			rb.AddForce (movement * speed);
			if (Input.GetKey (KeyCode.Space)) {
				rb.AddForce (-brakeSpeed * rb.velocity);
			}
		}

    }

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag("Pickup")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You win!";
			win = true;
		}
	}
}