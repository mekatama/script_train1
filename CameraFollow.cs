using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	Vector3 diff;
	public GameObject target;	//追従するオブジェクト
	public float followSpeed;	//追従スピード
	GameObject player;			//検索したオブジェクト入れる用

	void Start () {
		diff = target.transform.position - transform.position;
//		player = GameObject.FindWithTag ("Player");					//Playerタグのオブジェクトを探す
	}
	
//	void LateUpdate () {
	void Update () {
		//pcって仮の変数にPlayerのコンポーネントを入れる
//		Player pc = player.GetComponent<Player>();
		//カメラ追従
//		if(pc.cameraFollowStop == false){			//追従フラグを見ている
			transform.position = Vector3.Lerp(
				transform.position,
				target.transform.position - diff,
				Time.deltaTime * followSpeed
			);
//		}
	}
}
