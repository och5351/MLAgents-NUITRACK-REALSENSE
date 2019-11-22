using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class MainAnimator : MonoBehaviour
{
   
    public Animator anim;
    public GameObject obj;

    //필요 변수    
    int waitCount = 0; // 휴식시간 타이머
    bool selectFlag = false;
    int act = 8;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();        
    }
    


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
       
    }

    void breakTime()
    {    
        int i = Random.Range(0,3);
        if (anim.GetCurrentAnimatorStateInfo(0)
        .normalizedTime >= 1 && act == 8)
        {
            if (i == 0 && act == 8)
            {
                anim.SetInteger("act", act);
            }
            else if(i==1 && act == 8)
            {
                anim.SetInteger("act", act);
            }
            else if(i==2 && act == 8)
            {
                anim.SetInteger("act", act);
            }            
        }

    }

    // Update is called once per frame
    void Update()
    {
        waitCount++;
        if (waitCount == 150)
        {
            expression();
            waitCount = 0;
        }        
    }
}
