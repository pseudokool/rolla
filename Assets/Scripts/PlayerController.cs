using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public GUIText countText;
	public GUIText winText;

	private Rigidbody rb;
	private int count;
	
	void Start ()
	{
		Debug.Log ("$$");

		rb = GetComponent<Rigidbody>();
		speed = 10;
		count = 0;
		countText.text = "Score: " + count.ToString();
	}
	
	void FixedUpdate ()
	{
		//Debug.Log ("H: " + Input.GetAxis("Horizontal"));
		//Debug.Log ("V: " + Input.GetAxis("Vertical"));

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveHorizontal_a = AndroidInput. ("Horizontal");

		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if( other.gameObject.CompareTag("PickUp") )
		{
			other.gameObject.SetActive(false);
			count++;

			Debug.Log ("S: " + count.ToString());

			countText.text = "Score: " + count.ToString();

			if( count>=5 ) { winText.text = "You Win!"; }
		}
	}
}