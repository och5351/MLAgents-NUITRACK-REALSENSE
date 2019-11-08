using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimator : MonoBehaviour, Observer
{ 

    public Animator animator;

    //필요 변수    
    int waitCount = 0; // 휴식시간 타이머


    public void Notify(Observable o) {


        var fm = o as FaceManager;
        
        Debug.Log("메인애니메이터에서 받은 값 : " + fm.expressionSelectNumSend);

    }

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        
      
    }

    public void expression(bool inDisplay, int Expression)
    {
        if (inDisplay == true)
        {                        
            if (waitCount == 250) // 14초x5초
            {
                if(Expression == 0)
                    animator.Play("WAIT01", -1, 0);
                }
                else if (Expression == 2)
                {
                    animator.Play("WAIT02", -1, 0);
                }
                else if (Expression == 3)
                {
                    animator.Play("WAIT03", -1, 0);
                }
                else if (Expression == 4)
                {
                    animator.Play("WAIT04", -1, 0);
                }
                else if (Expression == 5)
                {
                    animator.Play("WAIT00", -1, 0);
                }
                else if (Expression == 6)
                {
                    //animator.Play("REFLESH00", -1, 0);
                }
                waitCount = 0;
            }
        }
       
   



    // Update is called once per frame
    void Update()
    {

        //waitCount++;
        //expression();
        
       



        
    }
}
