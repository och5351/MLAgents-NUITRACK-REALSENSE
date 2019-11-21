using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class MainAnimator : MonoBehaviour
{
   
    public Animator anim;
    /*
    private AnimatorStateInfo currentState;
    private AnimatorStateInfo previousState;
    public bool _random = false;                //  랜덤 판정 스타트 스위치
    public float _threshold = 0.5f;             //  랜덤 판정의 한계
    public float _interval = 10f;
    */
    public GameObject obj;

    //필요 변수    
    int waitCount = 0; // 휴식시간 타이머
    bool selectFlag = false;
    int act;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //currentState = anim.GetCurrentAnimatorStateInfo(0);
        //previousState = currentState;
        //Debug.Log("현재 애니메이션 길이 : " + currentState.length);
    }
    /*
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int sitDownState = Animator.StringToHash("Base Layer.sitDown");
    static int begState = Animator.StringToHash("Base Layer.Beg");
    static int scratchHeadState = Animator.StringToHash("Base Layer.ScratchHead");
    static int fallDownState = Animator.StringToHash("Base Layer.FallDown");
    static int completeState = Animator.StringToHash("Base Layer.Complete");
    static int ashameState = Animator.StringToHash("Base Layer.Asahme");
    static int waitSitDownState = Animator.StringToHash("Base Layer.WaitSitDown");
    static int powerSpiningState = Animator.StringToHash("Base Layer.PowerSpining");
    static int spiningState = Animator.StringToHash("Base Layer.Spining");
    static int stretchedState = Animator.StringToHash("Base Layer.Stretched");
    static int happyHandsUpState = Animator.StringToHash("Base Layer.HappyHandsUp");
    static int runHelloState = Animator.StringToHash("Base Layer.RunHello");
    */


    public void CheckAnimationState()
    {
        /*
        if (!anim.GetCurrentAnimatorStateInfo(0)
        .IsName(actName))
        {
            //전환 중일 때 실행되는 부분
           
            yield return null;
        }
        */
        if(anim.GetCurrentAnimatorStateInfo(0)
        .normalizedTime >= 1)
        {
            
        }
        else
        {
            Debug.Log("행동 중이므로 행동지령을 받지 않습니다.");
        }
        /*
        while (anim.GetCurrentAnimatorStateInfo(0)
        .normalizedTime < 1)
        {
            //애니메이션 재생 중 실행되는 부분
            yield return null;
        }
        */
        //애니메이션 완료 후 실행되는 부분

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
        anim.SetInteger("act", act);
        Debug.Log("행동 : " + act);
        /*
        if (act == 0)
        {
            anim.Play("Defeat", -1, 0);
        }
        else if (act == 1)
        {
            anim.Play("SitDown", -1, 0);
        }
        else if (act == 2)
        {
            anim.Play("Beg", -1, 0);
        }
        else if (act == 3)
        {
            anim.Play("ScratchHead", -1, 0);
        }
        else if (act == 4)
        {
            anim.Play("FallDown", -1, 0);
        }
        else if (act == 5)
        {
            anim.Play("Complete", -1, 0);
        }
        else if (act == 6)
        {
            anim.Play("Ashame", -1, 0);
        }
        else if (act == 7)
        {
            //anim.Play("", -1, 0);
        }
        else if (act == 8)
        {
            anim.Play("WaitSitDown", -1, 0);
            breakTime();
        }
        else if (act == 9)
        {
            anim.Play("HappyHandsUp", -1, 0);
        }
        else if (act == 10)
        {
            anim.Play("RunHello", -1, 0);//손인사
        }*/
    }

    void breakTime()
    {    
        int i = Random.Range(0,3);
        if (anim.GetCurrentAnimatorStateInfo(0)
        .normalizedTime >= 1 && act == 8)
        {
            if (i == 0 && act == 8)
            {
                anim.Play("Spinig", -1, 0);
            }else if(i==1 && act == 8)
            {
                anim.Play("PowerSpining", -1, 0);
            }else if(i==2 && act == 8)
            {
                anim.Play("WaitSitdown", -1, 0);
            }            
        }
        else
        {
            Debug.Log("행동 중이므로 행동지령을 받지 않습니다.");
            
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
