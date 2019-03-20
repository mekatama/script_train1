using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo {
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor;
	public bool steering;
}

public class CarController : MonoBehaviour {
	public List<AxleInfo> axleInfos; 
	public float maxMotorTorque;
	public float maxSteeringAngle;
	 
	// 対応する視覚的なホイールを見つけます
	// Transform を正しく適用します
	public void ApplyLocalPositionToVisuals(WheelCollider collider)
	{
		//Wheelコライダーの子要素がない場合は処理終了。
		if (collider.transform.childCount == 0) {
			return;
		}
	 
		//タイヤビジュアルを取得
		Transform visualWheel = collider.transform.GetChild(0);
	 
		//コライダーの位置と回転を取得。
		Vector3 position;
		Quaternion rotation;
		collider.GetWorldPose(out position, out rotation);
	 
		//タイヤビジュアルに、コライダーの値を設定。
		//単純な車の場合、Z軸を90f回転させる必要がある
		visualWheel.transform.position = position;
		visualWheel.transform.rotation = rotation * Quaternion.Euler (0f, 0f, 90f);
	}
	 
	public void FixedUpdate()
	{
		float motor = maxMotorTorque * Input.GetAxis("Vertical");
//		float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
	 
		foreach (AxleInfo axleInfo in axleInfos) {
//			if (axleInfo.steering) {
//				axleInfo.leftWheel.steerAngle = steering;
//				axleInfo.rightWheel.steerAngle = steering;
//			}
			if (axleInfo.motor) {
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}
			ApplyLocalPositionToVisuals(axleInfo.leftWheel);
			ApplyLocalPositionToVisuals(axleInfo.rightWheel);
		}
	}
}
