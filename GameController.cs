using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public int speedType;		//speed制御
	public int count;			//light変化用count
	public GameObject Light0;	//light0
	public GameObject Light1;	//light1
	private int isLight;		//0:全点灯,1:ひとつ消灯,2:ふたつ消灯

	//ゲームステート
	enum State{
		GameStart,	//
		Play,		//
		Clear,		//
	}
	State state;

	void Start () {
		isLight = 0;	//初期化
		GameStart();	//初期ステート		
	}

	void LateUpdate () {
		//ステートの制御
		switch(state){
			case State.GameStart:
//				Debug.Log("game start");
				Play();		//ステート移動		
				break;
			//
			case State.Play:
//				Debug.Log("play");
				//finish判定
//				if(isGameOver){
//					Clear();	//ステート移動
//				}
				break;
			//
			case State.Clear:
//				Debug.Log("clear");
				break;
		}
	}

	void Update () {
		count += 1;
		//Lights制御
		if(count % 50 == 0){
			switch(isLight){
				case 0:
					isLight = 1;
					Light0.SetActive(false);	//light0 off
					Debug.Log("yuugata");
					break;
				case 1:
					isLight = 2;
					Light1.SetActive(false);	//light1 off
					Debug.Log("yoru");
					break;
				case 2:
					isLight = 0;
					Light0.SetActive(true);		//light0 on
					Light1.SetActive(true);		//light1 on
					Debug.Log("hiru");
					break;
			}
		}
	}

	void GameStart(){
		state = State.GameStart;
	}
	void Play(){
		state = State.Play;
	}
	void Clear(){
		state = State.Clear;
	}

	//停止用のbutton制御関数
	public void ButtonOn_Front0(){
		speedType = 0;
		Debug.Log("speedType:" + speedType);
		//SEをその場で鳴らす
//		AudioSource.PlayClipAtPoint( audioClipPowerup, transform.position);	//SE再生(Destroy対策用)
	}

	//微速前進用のbutton制御関数
	public void ButtonOn_Front1(){
		speedType = 1;
		Debug.Log("speedType:" + speedType);
		//SEをその場で鳴らす
//		AudioSource.PlayClipAtPoint( audioClipPowerup, transform.position);	//SE再生(Destroy対策用)
	}

	//前進用のbutton制御関数
	public void ButtonOn_Front2(){
		speedType = 2;
		Debug.Log("speedType:" + speedType);
		//SEをその場で鳴らす
//		AudioSource.PlayClipAtPoint( audioClipPowerup, transform.position);	//SE再生(Destroy対策用)
	}

	//return用の制御関数
	public void ButtonClicked_Return(){
		SceneManager.LoadScene("title");	//シーンのロード
	}
}
