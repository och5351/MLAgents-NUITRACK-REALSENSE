using UnityEngine;
using System.Collections;

namespace UnityChan
{
//
// ↑↓キーでループアニメーションを切り替えるスクリプト（ランダム切り替え付き）Ver.3
// 2014/04/03 N.Kobayashi
//

// Require these components when using this script
	[RequireComponent(typeof(Animator))]

	public class IdleChanger : MonoBehaviour
	{
	
		private Animator anim;                      // Animatorへの参照 참조
        private AnimatorStateInfo currentState;     // 現在のステート状態を保存する参照 현재 상태 상태를 저장하는 참조
        private AnimatorStateInfo previousState;    // ひとつ前のステート状態を保存する参照 하나 전의 상태 상태를 저장하는 참조
        public bool _random = false;                // ランダム判定スタートスイッチ 랜덤 판정 스타트 스위치
        public float _threshold = 0.5f;             // ランダム判定の閾値 랜덤 판정의 한계
        public float _interval = 10f;               // ランダム判定のインターバル 랜덤 판정의 간격
        //private float _seed = 0.0f;					// ランダム判定用シード 랜덤 판정 용 시드



        // Use this for initialization
        void Start ()
		{
			// 各参照の初期化
			anim = GetComponent<Animator> ();
			currentState = anim.GetCurrentAnimatorStateInfo (0);
			previousState = currentState;
            Debug.Log("현재 애니메이션 길이 : " + currentState.length);
            // ランダム判定用関数をスタートする 랜덤 판정 용 함수를 시작하는
            StartCoroutine ("RandomChange");
		}
	
		// Update is called once per frame
		void  Update ()
		{
			// ↑キー/スペースが押されたら、ステートを次に送る処理
			if (Input.GetKeyDown ("up") || Input.GetButton ("Jump")) {
				// ブーリアンNextをtrueにする
				anim.SetBool ("Next", true);
			}
		
			// ↓キーが押されたら、ステートを前に戻す処理
			if (Input.GetKeyDown ("down")) {
				// ブーリアンBackをtrueにする
				anim.SetBool ("Back", true);
			}
		
			// "Next"フラグがtrueの時の処理
			if (anim.GetBool ("Next")) {
				// 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
				currentState = anim.GetCurrentAnimatorStateInfo (0);
				if (previousState.nameHash != currentState.nameHash) {
					anim.SetBool ("Next", false);
					previousState = currentState;
                    Debug.Log("현재 애니메이션 길이 : " + currentState.length);
                }
			}
		
			// "Back"フラグがtrueの時の処理
			if (anim.GetBool ("Back")) {
				// 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
				currentState = anim.GetCurrentAnimatorStateInfo (0);
				if (previousState.nameHash != currentState.nameHash) {
					anim.SetBool ("Back", false);
					previousState = currentState;
                    Debug.Log("현재 애니메이션 길이 : " + currentState.length);
                }
			}
		}

		void OnGUI ()
		{
			GUI.Box (new Rect (Screen.width - 110, 10, 100, 90), "Change Motion");
			if (GUI.Button (new Rect (Screen.width - 100, 40, 80, 20), "Next"))
				anim.SetBool ("Next", true);
			if (GUI.Button (new Rect (Screen.width - 100, 70, 80, 20), "Back"))
				anim.SetBool ("Back", true);
		}


        // ランダム判定用関数 랜덤 판정 용 함수
        IEnumerator RandomChange ()
		{
            // 無限ループ開始 무한 루프 시작
            while (true) {
                //ランダム判定スイッチオンの場合 랜덤 판정 스위치 온의 경우
                if (_random) {
                    // ランダムシードを取り出し、その大きさによってフラグ設定をする 랜덤 시드를 꺼내 그 크기에 따라 플래그 설정을
                    float _seed = Random.Range (0.0f, 1.0f);
					if (_seed < _threshold) {
						anim.SetBool ("Back", true);
					} else if (_seed >= _threshold) {
						anim.SetBool ("Next", true);
					}
				}
                // 次の判定までインターバルを置く 다음의 판정까지 간격을 둔다
                yield return new WaitForSeconds (_interval);
			}

		}

	}
}
