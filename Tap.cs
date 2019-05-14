using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cameraにMainCameraタグをアサイン忘れるな
//もしくはcameraをpublic経由でアサインする
public class Tap : MonoBehaviour {
	GameObject structure;			//tapしたオブジェクト入れる用
	private bool isTap = false;		//一回だけ処理
	public AudioClip audioClipTap;	//tap SE

	void Update () {
//		Debug.Log("isTap" + isTap);
		structure = null;

		//タップした判定
 		if(Input.GetMouseButtonDown(0)){
			Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit)){
				structure = hit.collider.gameObject;
			}

			//Structureをtapしたら
			if(structure.tag == "Structure"){
				//タッチに反応
				if(isTap == false){
					//ちょっとだけ拡大させる
					transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
					isTap = true;
					//SEをその場で鳴らす
					AudioSource.PlayClipAtPoint( audioClipTap, transform.position);
					//0.1秒後に呼び出す
					Invoke("ScaleReset", 0.1f);
				}
			}
		}
	}
	//時間差でスケールを戻す用
	void ScaleReset(){
		//元のスケールに戻す
		transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		isTap = false;
	}
}
