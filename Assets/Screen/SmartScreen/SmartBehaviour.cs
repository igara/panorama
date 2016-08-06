using UnityEngine;
using System.Collections;

public class SmartBehaviour : MonoBehaviour {

	/**
	 * @var GameObject main_camera カメラ
	 */
	private GameObject main_camera;

	private Gyroscope gyro;

	private Quaternion quaternionMulti;
	private Quaternion quaternionMap;

	/**
	 * インスタンス生成された時のみ実行されるメソッド
	 */
	void Awake () {
		#if UNITY_IPHONE || UNITY_ANDROID
			gyro = Input.gyro;
			gyro.enabled = true;
			main_camera = GameObject.Find ("MainCamera");
		#endif
		#if UNITY_IPHONE
			main_camera.transform.eulerAngles = new Vector3(90,90,0);
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				quaternionMulti = new Quaternion(0f,0,0.7071f,0.7071f);
			} else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
				quaternionMulti = new Quaternion(0,0,-0.7071f,0.7071f);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				quaternionMulti = new Quaternion(0,0,1,0);
			} else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
				quaternionMulti = new Quaternion(0,0,0,1);
			}
		#endif
		#if UNITY_ANDROID
		main_camera.transform.eulerAngles = new Vector3(-90,0,0);
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				quaternionMulti = new Quaternion(0f,0,0.7071f,-0.7071f);
			} else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
				quaternionMulti = new Quaternion(0,0,-0.7071f,-0.7071f);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				quaternionMulti = new Quaternion(0,0,0,1);
			} else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
				quaternionMulti = new Quaternion(0,0,1,0);
			}
		#endif
	}

	/**
	 * Awakeの後で
	 * 最初のフレームのアップデート前に実行されるメソッド
	 */
	void Start () {
	}

	/**
	 * フレーム毎に一度実行されるメソッド
	 */
	void Update () {
		#if UNITY_IPHONE
			quaternionMap = gyro.attitude;
		#endif
		#if UNITY_ANDROID
			quaternionMap = new Quaternion(gyro.attitude.w,gyro.attitude.x,gyro.attitude.y,gyro.attitude.z);
		#endif
		main_camera.transform.localRotation = quaternionMap * quaternionMulti;

	}

	/**
	 * GUIイベントに応じて、フレームごとに複数回呼び出されるメソッド
	 */
	void OnGUI () {
	}

	/**
	 * Behaviour が有効/アクティブになったときに呼び出される 
	 */
	void OnEnable() {
	}

	/**
	 * Behaviour が無効/非アクティブになったときに呼び出される 
	 */
	void OnDisable() {
	}
}
