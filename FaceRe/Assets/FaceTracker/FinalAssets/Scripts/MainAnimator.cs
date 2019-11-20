using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class MainAnimator : MonoBehaviour
{ 

    public Animator anim;
    private AnimatorStateInfo currentState;
    private AnimatorStateInfo previousState;
    public bool _random = false;                // ランダム判定スタートスイッチ 랜덤 판정 스타트 스위치
    public float _threshold = 0.5f;             // ランダム判定の閾値 랜덤 판정의 한계
    public float _interval = 10f;
    public GameObject obj;

    //필요 변수    
    int waitCount = 0; // 휴식시간 타이머
    bool selectFlag;
    int act;
    
    // Start is called before the first frame update
    void Start()
    {        
        anim = GetComponent<Animator>();
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        previousState = currentState;
        Debug.Log("현재 애니메이션 길이 : " + currentState.length);
        // ランダム判定用関数をスタートする 랜덤 판정 용 함수를 시작하는
        StartCoroutine("RandomChange");
    }

    /*
    IEnumerator CheckAnimationState()
    {

        if (!anim.GetCurrentAnimatorStateInfo(0)
        .IsName("원하는 애니메이션 이름"))
        {
            //전환 중일 때 실행되는 부분
            yield return null;
        }

        while (anim.GetCurrentAnimatorStateInfo(0)
        .normalizedTime < exitTime)
        {
            //애니메이션 재생 중 실행되는 부분
            yield return null;
        }

        //애니메이션 완료 후 실행되는 부분

    }
    */
    IEnumerator RandomChange()
    {
        // 無限ループ開始
        while (true)
        {
            //ランダム判定スイッチオンの場合
            if (_random)
            {
                // ランダムシードを取り出し、その大きさによってフラグ設定をする 랜덤 시드를 꺼내 그 크기에 따라 플래그 설정을
                float _seed = Random.Range(0.0f, 1.0f);
                if (_seed < _threshold)
                {
                    anim.SetBool("Back", true);
                }
                else if (_seed >= _threshold)
                {
                    anim.SetBool("Next", true);
                }
            }
            // 次の判定までインターバルを置く
            yield return new WaitForSeconds(_interval);
        }

    }

    /*
        0. 울기
        1. 주저 앉기
        2. 두 손 빌기
        3. 머리 긁적이기
        4. 놀라서 양팔들기
        5. 하트 그리기
        6. 부끄러워 다리 베베꼬기
        7. 박수치기
        8. 쉬기
        9. 춤추기
        10. 손인사
    */
    public void expression()
    {
        act = obj.GetComponent<FaceManager>().getEx();
        Debug.Log("행동 : " + "" + act);
        if (act == 0)
        {
            anim.Play("LOSE00 0", -1, 0);
        }
        else if (act == 1)
        {
            anim.Play("LOSE00 0", -1, 0);
        }
        else if (act == 2)
        {
           
        }
        else if (act == 3)
        {
            anim.Play("WAIT04", -1, 0);
        }
        else if (act == 4)
        {
            anim.Play("WAIT00", -1, 0);
        }
        else if (act == 5)
        {
            anim.Play("REFLESH00", -1, 0);
        }
        else if (act == 6)
        {
            //anim.Play("REFLESH00", -1, 0);
        }
        else if (act == 7)
        {
            //anim.Play("REFLESH00", -1, 0);
        }
        else if (act == 8)
        {
            //anim.Play("REFLESH00", -1, 0);
        }
        else if (act == 9)
        {
            //anim.Play("REFLESH00", -1, 0);
        }
        else if (act == 10)
        {
            anim.Play("WAIT03", -1, 0);//손인사
        }
    }

    // Update is called once per frame
    void Update()
    {
        waitCount++;
        if (waitCount == 240)
        {
            expression();
            waitCount = 0;
        }        
    }
}
