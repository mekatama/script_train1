using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {
	const int StageTipSize = 10;	//パーツの長さ
	int currentTipIndex;			//

	public Transform character;		//移動するキャラの座標
	public GameObject[] stageTips;	//並べたいパーツを登録する配列
	public int startTipIndex;		//自動生成開始Index
	public int preInstantiate;		//生成先読み個数
	public List<GameObject> generatedStageList = new List<GameObject>();	//生成済パーツ保存List

	void Start () {
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

		//次のパーツから指定のIndex(先読み分含む)までパーツを生成
		for(int i = currentTipIndex + 1; i <= toTipIndex; i++){
			GameObject stageObject = GenerateStage(i);	//関数へ
			generatedStageList.Add(stageObject);		//管理用Listにパーツ追加
		}

		//管理用List保持上限まで、古いパーツ削除
		while(generatedStageList.Count > preInstantiate + 2){
			DestroyOldestStage();						//関数へ
		}
		//次のパーツを現在のパーツとする
		currentTipIndex = toTipIndex;
	}

	//パーツをランダム生成
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

	//古いパーツの削除
	void DestroyOldestStage(){
		GameObject oldStage = generatedStageList[0];	//一番最初に登録されたパーツを選択
		generatedStageList.RemoveAt(0);					//Listから削除
		Destroy(oldStage);
	}
}
