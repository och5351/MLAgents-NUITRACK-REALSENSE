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
    int ashamedAct = 0;
    int helloCount = 5; 

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        speech.SetActive(false);

    }

    /*
     * 0 : 좌절
     * 1 : 의기소침 앉기
     * 2 : 작은 하트
     * 3 : 머리 긁적이기
     * 4 : 뒤로 넘어지기
     * 5 : 필승
     * 6 : 부끄러워 하기
     * 7 : 한바퀴돌아차기
     * 8 : 만세
     * 9 : 손인사
     * 10 : 앉아서 쉬기
     * 11 : 스트레칭
     * 12 : 흔들흔들 
    */

    public void expression(int act)
    {
        if (act == 6)
        {
            
            //ashame();
        }
        else if(act == 9)
        {
            runHello(act);
        }
        else if (act == 11)
        {
           
            ashamedAct = 0;
            breakTime(act);
        }
        else
        {
            helloCount = 5;
            ashamedAct = 0;
            anim.SetInteger("act", act);
        }
        
        Debug.Log("행동 : " + act);
       
    }


    void runHello(int act)
    {
        if(helloCount == 5)
        {
            anim.SetInteger("act", act);
            anim.SetInteger("restAct", helloCount);
            helloCount = 6;
        }

    }


    void ashame()
    {
        
        if(ashamedAct == 0)
        {
            anim.SetInteger("restAct", ashamedAct);
            ashamedAct++;
        }else if (ashamedAct == 1)
        {
            anim.SetInteger("restAct", ashamedAct);
            ashamedAct++;
        }else
            anim.SetInteger("restAct", ashamedAct);
            ashamedAct=0;

    }


    void breakTime(int act)
    {    

        /*
         * 휴식 모션 연계 너무 빠름
         * count 변수 선언으로 수정 요망(waitsitdown이 더 길게)
         */
        
        //int i = Random.Range(0,3);
       
       
       // if (i == 0 && act == 8)
        //{
            anim.SetInteger("act", act);
           
            //speech.SetActive(true);
            //speechFunc("에고고.. 쉬어볼까? ");
            
       // }
       /*
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
        */      
        

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
