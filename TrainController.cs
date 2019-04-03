using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour {
	public float speed = 3f;	//
	float moveZ = 0f;			//
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();		
	}
	
	void Update () {
		moveZ = Input.GetAxis("Horizontal") * speed;
//		Vector3 direction = new Vector3(0,0,moveZ);
	}

	void FixedUpdate(){
		rb.velocity = new Vector3(0,0,moveZ);
	}

}
