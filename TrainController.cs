using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour {
	public float speed = 3f;	//基本速度
	float moveZ = 0f;			//実際の速度
	Rigidbody rb;				//rigidbody格納用
	GameObject gameController;	//検索したオブジェクト入れる用

	void Start () {
		rb = GetComponent<Rigidbody>();								//rigidbody格納
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//ボタン入力でspeed制御
		moveZ = speed * gc.speedType;
	}

	void FixedUpdate(){
		//y方向にゼロを入れると落下速度がリセットされるので注意
		rb.velocity = new Vector3(0,rb.velocity.y,moveZ);
		rb.AddForce (Vector3.down * 50, ForceMode.Acceleration);
	}
}