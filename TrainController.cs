using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour {
	public float speed = 3f;	//基本速度
	float moveZ = 0f;			//実際の速度
	Rigidbody rb;				//rigidbody格納用

	void Start () {
		rb = GetComponent<Rigidbody>();		
	}
	
	void Update () {
		moveZ = Input.GetAxis("Horizontal") * speed;
	}

	void FixedUpdate(){
		//y方向にゼロを入れると落下速度がリセットされるので注意
		rb.velocity = new Vector3(0,rb.velocity.y,moveZ);
		rb.AddForce (Vector3.down * 50, ForceMode.Acceleration);
	}

}
