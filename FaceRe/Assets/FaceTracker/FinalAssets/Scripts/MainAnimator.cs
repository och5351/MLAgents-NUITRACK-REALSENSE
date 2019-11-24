using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class MainAnimator : MonoBehaviour
{
   
    public Animator anim;
        
    public GameObject speech;

    //필요 변수    
    int waitCount = 0; // 휴식시간 타이머
    bool selectFlag = false;
    int restAct = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();        
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

    public void expression(int act)
    {        
       if(act == 8)
        {
            breakTime(act);
        }else
            anim.SetInteger("act", act);
        
        
        Debug.Log("행동 : " + act);
       
    }

    void breakTime(int act)
    {    

        /*
         * 휴식 모션 연계 너무 빠름
         * count 변수 선언으로 수정 요망(waitsitdown이 더 길게)
         */
        
        int i = Random.Range(0,3);
       
       
        if (i == 0 && act == 8)
        {
            anim.SetInteger("act", act);
            anim.SetInteger("restAct", i);
            speech.SetActive(true);
            speechFunc("에고고.. 쉬어볼까? ");
            
        }
        else if(i==1 && act == 8)
        {
            anim.SetInteger("act", act);
            anim.SetInteger("restAct", i);
            speech.SetActive(true);
            speechFunc("나 혼자 흔들흔들~");
           
        }
        else if(i==2 && act == 8)
        {
            anim.SetInteger("act", act);
            anim.SetInteger("restAct", i);
            speech.SetActive(true);
            speechFunc("아이코~~ 삭신이야~~");
            
        }            
        

    }




    public void speechFunc(string text)
    {
       
        speech.GetComponent<SpeechBubbleCtrl>().setText(text);
    }

    // Update is called once per frame
    void Update()
    {
      
           
    }
}
