using UnityEngine;
using System.Collections;

public class TitleSceneBehaviour : MonoBehaviour {

	/**
	 * インスタンス生成された時のみ実行されるメソッド
	 */
	void Awake () {
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
		this.transform.Rotate ( 0, ( Input.GetAxis ("Horizontal") * 1 ), 0 );
		this.transform.Rotate ( ( Input.GetAxis ("Vertical") * 1 ), 0, 0 );
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
