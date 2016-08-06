using UnityEngine;
using System.Collections;
using Service.ScreenAutorotateSetting;

public class SmartBehaviour : MonoBehaviour {

	/**
	 * @var ScreenAutorotateSetting screenAutorotateSetting 画面の回転制御
	 */
	private ScreenAutorotateSetting screenAutorotateSetting = new ScreenAutorotateSetting();

	/**
	 * @var GameObject main_camera カメラ
	 */
	private GameObject main_camera;

	/**
	 * インスタンス生成された時のみ実行されるメソッド
	 */
	void Awake () {
		#if UNITY_IPHONE || UNITY_ANDROID
			// ジャイロセンサを有効
			Input.gyro.enabled = true;
			// コンパスを有効
			Input.compass.enabled = true;
			// MainCameraという名前のGameObjectを取得
			main_camera = GameObject.Find ("MainCamera");
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
		#if UNITY_ANDROID || UNITY_IPHONE
			// ジャイロの角度を適応させる
			main_camera.transform.localRotation = Quaternion.Euler (90, 0, -180) * Input.gyro.attitude * Quaternion.Euler(0, 0, 180);
		#endif
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
		// 画面の回転を許可しない
		screenAutorotateSetting.setAutorotateSwichFalse();
		// immersiveモードを解除
		Screen.fullScreen = false;
	}

	/**
	 * Behaviour が無効/非アクティブになったときに呼び出される 
	 */
	void OnDisable() {
		// 画面の回転を許可する
		screenAutorotateSetting.setAutorotateSwichTrue();
	}
}
