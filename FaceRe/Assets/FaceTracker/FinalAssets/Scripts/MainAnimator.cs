using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimator : MonoBehaviour
{ 

    public Animator animator;
    public GameObject obj;

    //필요 변수    
    int waitCount = 0; // 휴식시간 타이머
    bool selectFlag;
    int act;
    
    // Start is called before the first frame update
    void Start()
    {        
        animator = GetComponent<Animator>();
              
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
            animator.Play("LOSE00 0", -1, 0);
        }
        else if (act == 1)
        {
            animator.Play("DAMAGED01", -1, 0);
        }
        else if (act == 2)
        {
            animator.Play("WAIT03", -1, 0);
        }
        else if (act == 3)
        {
            animator.Play("WAIT04", -1, 0);
        }
        else if (act == 4)
        {
            animator.Play("WAIT00", -1, 0);
        }
        else if (act == 5)
        {
            animator.Play("REFLESH00", -1, 0);
        }
        else if (act == 6)
        {
            //animator.Play("REFLESH00", -1, 0);
        }
        else if (act == 7)
        {
            //animator.Play("REFLESH00", -1, 0);
        }
        else if (act == 8)
        {
            //animator.Play("REFLESH00", -1, 0);
        }
        else if (act == 9)
        {
            //animator.Play("REFLESH00", -1, 0);
        }
        else if (act == 10)
        {
            //animator.Play("REFLESH00", -1, 0);
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
