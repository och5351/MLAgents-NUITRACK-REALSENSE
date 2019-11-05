using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimator : MonoBehaviour
{ 

    public Animator animator;

    //필요 변수
    bool firstMeet = true;
    bool breakTime = true;
    int waitCount = 0; // 휴식시간 타이머
    int die;     

    public int dieTrowing(int sn, int fn) // 주사위 새로 던지기 함수
    {
        int r = Random.Range(sn, fn+1);

        return r;

    }

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (FaceManager.inDisplay == false)
        {
            firstMeet = true;
            
            waitCount++;
            if (waitCount == 250) // 14초x5초
            {
                die = dieTrowing(1, 6);
                if (die == 1)
                {
                    animator.Play("WAIT01", -1, 0);
                }
                else if (die == 2)
                {
                    animator.Play("WAIT02", -1, 0);
                }
                else if (die == 3)
                {
                    animator.Play("WAIT03", -1, 0);
                }
                else if (die == 4)
                {
                    animator.Play("WAIT04", -1, 0);
                }
                else if (die == 5)
                {
                    animator.Play("WAIT00", -1, 0);
                }
                else if (die == 6)
                {
                    animator.Play("REFLESH00", -1, 0);
                }
                waitCount = 0;
            }
        }
        else
        {
            if (firstMeet == true)
            {
                animator.Play("HANDUP00_R", -1, 0);
                firstMeet = false;
            }
        }



        
    }
}
