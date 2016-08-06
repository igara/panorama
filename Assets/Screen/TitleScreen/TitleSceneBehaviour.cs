using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleSceneBehaviour : MonoBehaviour {

	/**
	 * @var Vector3 vector カメラの座標
	 */
	private Vector3 vector;

	/**
	 * @var GameObject plane 床
	 */
	private GameObject plane;

	/**
	 * @var GameObject main_camera カメラ
	 */
	private GameObject main_camera;

	/**
	 * インスタンス生成された時のみ実行されるメソッド
	 */
	void Awake () {
		vector = new Vector3(0, 1.5f, 0);
		transform.position = vector;
		plane = GameObject.Find("Plane");
		main_camera = GameObject.Find ("MainCamera");
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
		// ↑↓キーで上下の角度を変更する
		main_camera.transform.Rotate (Input.GetAxis ("Vertical") * 1, 0, 0);
		// ←→キーで床を回転する
		plane.transform.Rotate (0, Input.GetAxis ("Horizontal") * 1, 0);
		if (Input.GetAxis ("Mouse Y") != 0) {
			// カメラの高さをマウスの上下で変更する
			vector.y = vector.y + Input.GetAxis ("Mouse Y") * 1;
		}
		main_camera.transform.position = vector;
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

	/**
	 * Swichボタンを押下した時
	 */
	public void OnSwichButton() {
		// SmartScene画面に遷移させる
		SceneManager.LoadScene("Screen/SmartScreen/SmartScene");
	}
}
