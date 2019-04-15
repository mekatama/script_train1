using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {
	const int StageTipSize = 10;	//パーツの長さ
	int currentTipIndex;			//現在走行中のパーツIndex
	private int stageType;			//0:地面,1:上り坂,2:高架,3:下り坂

	public Transform character;		//移動するキャラの座標
	public GameObject[] stageTips;	//並べたいパーツを登録する配列
	public GameObject[] stageTipsUp;	//並べたいパーツを登録する配列
	public GameObject[] stageTipsHigh;	//並べたいパーツを登録する配列
	public GameObject[] stageTipsDown;	//並べたいパーツを登録する配列
	public int startTipIndex;		//自動生成開始Index
	public int preInstantiate;		//生成先読み個数
	public List<GameObject> generatedStageList = new List<GameObject>();	//生成済パーツ保存List

	void Start () {
//		stageType = 0;
		currentTipIndex = startTipIndex - 1;	//原点に配置しているパーツのIndexを0と定める
		UpdateStage(preInstantiate);			//初期ステージ更新
	}
	
	void Update () {
		//キャラの位置から、現在のパーツIndexを計算
		int charaPositionIndex = (int)(character.position.z / StageTipSize);
		//次のパーツに進入したら
		if(charaPositionIndex + preInstantiate > currentTipIndex){
			//ステージ更新処理
			UpdateStage(charaPositionIndex + preInstantiate);
		}
	}

	//指定のIndexまでのパーツを生成して管理
	void UpdateStage(int toTipIndex){
		//次のパーツに進入していないなら抜ける
		if(toTipIndex <= currentTipIndex){
			return;
		}

if(toTipIndex > 5){
		//0の時:0か1を生成
		//1の時:2を生成
		//2の時:2か3を生成
		//3の時:0を生成
		switch(stageType){
			case 0:
				stageType = Random.Range(0,2);		//ランダムで出現パーツを決める
				break;
			case 1:
				stageType = 2;
				break;
			case 2:
				stageType = Random.Range(2,4);		//ランダムで出現パーツを決める
				break;
			case 3:
				stageType = 0;
				break;
		}
		//Debug.Log("type:" + stageType);
}
		//次のパーツから指定のIndex(先読み分含む)までパーツを生成
		for(int i = currentTipIndex + 1; i <= toTipIndex; i++){
			if(stageType == 0){
				GameObject stageObject = GenerateStage(i);	//関数へ
				generatedStageList.Add(stageObject);		//管理用Listにパーツ追加
				Debug.Log("地面パーツ");
			}
			if(stageType == 1){
				GameObject stageObject = GenerateStageUp(i);	//関数へ
				generatedStageList.Add(stageObject);		//管理用Listにパーツ追加
				Debug.Log("上り坂パーツ");
			}
			if(stageType == 2){
				GameObject stageObject = GenerateStageHigh(i);	//関数へ
				generatedStageList.Add(stageObject);		//管理用Listにパーツ追加
				Debug.Log("高架パーツ");
			}
			if(stageType == 3){
				GameObject stageObject = GenerateStageDown(i);	//関数へ
				generatedStageList.Add(stageObject);		//管理用Listにパーツ追加
				Debug.Log("下り坂パーツ");
			}
		}

		//管理用List保持上限まで、古いパーツ削除
		while(generatedStageList.Count > preInstantiate + 2){
			DestroyOldestStage();						//関数へ
		}
		//次のパーツを現在のパーツとする
		currentTipIndex = toTipIndex;
	}

	//パーツ地面をランダム生成
	GameObject GenerateStage(int tipIndex){
		int nextStageTip = Random.Range(0, stageTips.Length);	//パーツ決定用ランダム値
		//パーツ生成
		GameObject stageObject = 	(GameObject)Instantiate(
										stageTips[nextStageTip],
										new Vector3(0, 0, tipIndex * StageTipSize),
										Quaternion.identity
									);
		return stageObject;										//戻り値、パーツobject
	}

	//パーツ上り坂をランダム生成
	GameObject GenerateStageUp(int tipIndex){
		int nextStageTip = Random.Range(0, stageTipsUp.Length);	//パーツ決定用ランダム値
		//パーツ生成
		GameObject stageObject = 	(GameObject)Instantiate(
										stageTipsUp[nextStageTip],
										new Vector3(0, 0, tipIndex * StageTipSize),
										Quaternion.identity
									);
		return stageObject;										//戻り値、パーツobject
	}

	//パーツ高架をランダム生成
	GameObject GenerateStageHigh(int tipIndex){
		int nextStageTip = Random.Range(0, stageTipsHigh.Length);	//パーツ決定用ランダム値
		//パーツ生成
		GameObject stageObject = 	(GameObject)Instantiate(
										stageTipsHigh[nextStageTip],
										new Vector3(0, 0, tipIndex * StageTipSize),
										Quaternion.identity
									);
		return stageObject;										//戻り値、パーツobject
	}

	//パーツ下り坂をランダム生成
	GameObject GenerateStageDown(int tipIndex){
		int nextStageTip = Random.Range(0, stageTipsDown.Length);	//パーツ決定用ランダム値
		//パーツ生成
		GameObject stageObject = 	(GameObject)Instantiate(
										stageTipsDown[nextStageTip],
										new Vector3(0, 0, tipIndex * StageTipSize),
										Quaternion.identity
									);
		return stageObject;										//戻り値、パーツobject
	}

	//古いパーツの削除
	void DestroyOldestStage(){
		GameObject oldStage = generatedStageList[0];	//一番最初に登録されたパーツを選択
		generatedStageList.RemoveAt(0);					//Listから削除
		Destroy(oldStage);
	}
}
