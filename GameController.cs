using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public int speedType;		//speed制御

	//ゲームステート
	enum State{
		GameStart,	//
		Play,		//
		Clear,		//
	}
	State state;

	void Start () {
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
