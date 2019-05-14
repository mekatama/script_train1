using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour {
	GameObject gameController;	//検索したオブジェクト入れる用

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//speedで車輪の回転速度を変化
		switch(gc.speedType){
			case 0:
				transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime);
				break;
			case 1:
				transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
				break;
			case 2:
				transform.Rotate(new Vector3(180, 0, 0) * Time.deltaTime);
				break;
		}
	}
}
