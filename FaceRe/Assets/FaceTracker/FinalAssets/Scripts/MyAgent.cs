using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class MyAgent : Agent
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //표정 문자화
    int angry = 0;
    int surprise = 1;
    int natural = 2;
    int happy = 3;
    int empty = 4;


    int oldPreEmotionNum = 4;
    int preEmotionNum = 4;
    int emotionNum = 4;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            emotionNum = 0;
            RequestDecision();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            emotionNum = 1;
            RequestDecision();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            emotionNum = 2;
            RequestDecision();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            emotionNum = 3;
            RequestDecision();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            emotionNum = 4;
            RequestDecision();
        }
    }

    public override void CollectObservations()
    {
        if (emotionNum == 0)
        {
            AddVectorObs(oldPreEmotionNum);
            AddVectorObs(preEmotionNum);
            AddVectorObs(emotionNum);
            Debug.Log("화남");
            RequestAction();
        }
        else if (emotionNum == 1)
        {
            AddVectorObs(oldPreEmotionNum);
            AddVectorObs(preEmotionNum);
            AddVectorObs(emotionNum);
            Debug.Log("놀람");
            RequestAction();
        }
        else if (emotionNum == 2)
        {
            AddVectorObs(oldPreEmotionNum);
            AddVectorObs(preEmotionNum);
            AddVectorObs(emotionNum);
            Debug.Log("자연스러움");
            RequestAction();
        }
        else if (emotionNum == 3)
        {
            AddVectorObs(oldPreEmotionNum);
            AddVectorObs(preEmotionNum);
            AddVectorObs(emotionNum);
            Debug.Log("웃음");
            RequestAction();
        }
        else if (emotionNum == 4) // 휴식
        {
            AddVectorObs(oldPreEmotionNum);
            AddVectorObs(preEmotionNum);
            AddVectorObs(emotionNum);
            Debug.Log("화면에 없음");
            RequestAction();
        }

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

    public override void AgentAction(float[] vectorAction, string textAction)
    {
       

        int expressionSelectNum = Mathf.FloorToInt(vectorAction[0]);

        if (expressionSelectNum == 0)
        {
            Debug.Log("인공지능의 선택 값 : 좌절");
        }
        else if (expressionSelectNum == 1)
        {
            Debug.Log("인공지능의 선택 값 : 의기소침 앉기");
        }
        else if (expressionSelectNum == 2)
        {
            Debug.Log("인공지능의 선택 값 : 작은 하트");
        }
        else if (expressionSelectNum == 3)
        {
            Debug.Log("인공지능의 선택 값 : 머리 긁적이기");
        }
        else if (expressionSelectNum == 4)
        {
            Debug.Log("인공지능의 선택 값 : 뒤로 넘억지기");
        }
        else if (expressionSelectNum == 5)
        {
            Debug.Log("인공지능의 선택 값 : 필승");
        }
        else if (expressionSelectNum == 6)
        {
            Debug.Log("인공지능의 선택 값 : 부끄러워 하기");
        }
        else if (expressionSelectNum == 7)
        {
            Debug.Log("인공지능의 선택 값 : 한 바퀴 돌아차기");
        }
        else if (expressionSelectNum == 8)
        {
            Debug.Log("인공지능의 선택 값 : 만세");
        }
        else if (expressionSelectNum == 9)
        {
            Debug.Log("인공지능의 선택 값 : 손인사");
        }
        else if (expressionSelectNum == 10)
        {
            Debug.Log("인공지능의 선택 값 : 앉아서 쉬기");
        }
        else if(expressionSelectNum == 11)
        {
            Debug.Log("인공지능의 선택 값 : 스트레칭");
        }
        else if(expressionSelectNum == 12)
        {
            Debug.Log("인공지능의 선택 값 : 흔들흔들");
        }

        AddReward(-0.001f);

        //화면에 없을 때
        if (emotionNum == empty)
        {
            if (preEmotionNum != empty && expressionSelectNum == 11) // 사람이 가자마자 스트레칭
            {
                AddReward(0.05f);
            }else if(preEmotionNum != empty && expressionSelectNum != 11) //사람이 가자마자 스트레칭 안 했을때
                AddReward(-0.06f);

            if(expressionSelectNum < 10) // 쉬는 동작이 아닐 때
            {
                AddReward(-0.06f);
            }else if(oldPreEmotionNum == empty && preEmotionNum == empty && expressionSelectNum == 10) // 앉아서 쉬면
            {
                AddReward(0.05f);
            }else if(oldPreEmotionNum != empty && preEmotionNum == empty && expressionSelectNum == 11)
            {
                AddReward(0.001f);
            }else if(oldPreEmotionNum != empty && preEmotionNum == empty && expressionSelectNum == 12)
            {
                AddReward(0.02f);
            }
        }
        else //화면에 나타났을 때
        {
            //개인적으로 만든 상점(휴식시 취해야 할 행동)
            if(preEmotionNum == empty && expressionSelectNum == 9)
            {
                AddReward(0.05f);
            }
            else if(preEmotionNum == empty && emotionNum == angry && expressionSelectNum == 4)
            {
                AddReward(0.05f);
            }
            else
            {
                AddReward(-0.05f);
            }

            if(oldPreEmotionNum == happy && preEmotionNum == happy && emotionNum == happy) // 웃음 -> 웃음 -> 웃음
            {
                AddReward(0.06f);
            }
            else if(oldPreEmotionNum == happy && preEmotionNum == happy && emotionNum == natural) // 웃음 -> 웃음 -> 자연스러움
            {
                AddReward(0.03f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == happy && emotionNum == surprise) // 웃음 -> 웃음 -> 놀람
            {
                AddReward(-0.005f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == happy && emotionNum == angry) // 웃음 -> 웃음 -> 화남
            {
                AddReward(-0.05f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == natural && emotionNum == happy) // 웃음 -> 자연스러움 -> 웃음
            {
                AddReward(0.05f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == natural && emotionNum == natural) // 웃음 -> 자연스러움 -> 자연스러움
            {
                AddReward(0.003f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == natural && emotionNum == surprise) // 웃음 -> 자연스러움 -> 놀람
            {
                AddReward(-0.01f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == natural && emotionNum == angry) // 웃음 -> 자연스러움 -> 화남
            {
                AddReward(-0.03f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == surprise && emotionNum == happy) // 웃음 -> 놀람 -> 행복
            {
                AddReward(0.03f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == surprise && emotionNum == natural) // 웃음 -> 놀람 -> 자연스러움
            {
                AddReward(0.01f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == surprise && emotionNum == surprise) // 웃음 -> 놀람 -> 놀람
            {
                AddReward(-0.008f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == surprise && emotionNum == angry) // 웃음 -> 놀람 -> 화남
            {
                AddReward(-0.05f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == angry && emotionNum == happy) // 웃음 ->화남 -> 웃음
            {
                AddReward(0.01f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == angry && emotionNum == natural) // 웃음 -> 화남 -> 자연스러움
            {
                AddReward(0.002f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == angry && emotionNum == surprise) // 웃음 -> 화남 -> 놀람
            {
                AddReward(-0.001f);
            }
            else if (oldPreEmotionNum == happy && preEmotionNum == angry && emotionNum == angry) //웃음 -> 화남 -> 화남
            {
                AddReward(-0.06f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == happy && emotionNum == happy) // 자연스러움 -> 웃음 -> 웃음
            {
                AddReward(0.05f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == happy && emotionNum == natural) // 자연스러움 -> 웃음 -> 자연스러움
            {
                AddReward(0.04f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == happy && emotionNum == surprise) // 자연스러움 -> 웃음 -> 놀람
            {
                AddReward(-0.005f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == happy && emotionNum == angry) // 자연스러움 -> 웃음 -> 화남
            {
                AddReward(-0.05f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == natural && emotionNum == happy) // 자연스러웁 -> 자연스러움 -> 웃음
            {
                AddReward(0.03f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == natural && emotionNum == natural) // 자연스러움 -> 자연스러움 -> 자연스러움
            {
                AddReward(-0.001f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == natural && emotionNum == surprise) // 자연스러움 -> 자연스러움 -> 놀람
            {
                AddReward(-0.002f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == natural && emotionNum == angry) // 자연스러움 -> 자연스러움 -> 화남
            {
                AddReward(-0.06f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == surprise && emotionNum == happy) // 자연스러움 -> 놀람 -> 행복
            {
                AddReward(0.02f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == surprise && emotionNum == natural) // 자연스러움 -> 놀람 -> 자연스러움
            {
                AddReward(0.001f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == surprise && emotionNum == surprise) //자연스러움 -> 놀람 -> 놀람
            {
                AddReward(-0.01f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == surprise && emotionNum == angry) // 자연스러움 -> 놀람 -> 화남
            {
                AddReward(-0.065f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == angry && emotionNum == happy) // 자연스러움 -> 화남 -> 웃음
            {
                AddReward(0.005f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == angry && emotionNum == natural) // 자연스러움 -> 화남 -> 자연스러움
            {
                AddReward(0.002f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == angry && emotionNum == surprise) // 자연스러움 -> 화남 -> 놀람
            {
                AddReward(-0.002f);
            }
            else if (oldPreEmotionNum == natural && preEmotionNum == angry && emotionNum == angry) // 자연스러움 -> 화남 -> 화남
            {
                AddReward(-0.07f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == happy && emotionNum == happy) // 놀람 -> 웃음 -> 웃음
            {
                AddReward(0.04f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == happy && emotionNum == natural) // 놀람 -> 웃음 -> 자연스러움
            {
                AddReward(0.03f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == happy && emotionNum == surprise) // 놀람 -> 웃음 -> 놀람
            {
                AddReward(-0.007f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == happy && emotionNum == angry) // 놀람 -> 웃음 -> 화남
            {
                AddReward(-0.06f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == natural && emotionNum == happy) // 놀람 -> 자연스러움 -> 웃음
            {
                AddReward(0.02f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == natural && emotionNum == natural) // 놀람 -> 자연스러움 -> 자연스러움
            {
                AddReward(-0.003f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == natural && emotionNum == surprise) // 놀람 -> 자연스러움 -> 놀람
            {
                AddReward(-0.015f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == natural && emotionNum == angry) // 놀람 -> 자연스러움 -> 화남
            {
                AddReward(-0.08f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == surprise && emotionNum == happy) // 놀람 -> 놀람 -> 웃음
            {
                AddReward(0.01f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == surprise && emotionNum == natural) // 놀람 -> 놀람 -> 자연스러움
            {
                AddReward(-0.001f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == surprise && emotionNum == surprise) // 놀람 -> 놀람 -> 놀람
            {
                AddReward(-0.015f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == surprise && emotionNum == angry) // 놀람 -> 놀람 -> 화남
            {
                AddReward(-0.07f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == angry && emotionNum == happy) // 놀람 -> 화남 -> 웃음
            {
                AddReward(0.003f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == angry && emotionNum == natural) // 놀람 -> 화남 -> 자연스러움
            {
                AddReward(0.003f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == angry && emotionNum == surprise) // 놀람 -> 화남 -> 놀람
            {
                AddReward(-0.004f);
            }
            else if (oldPreEmotionNum == surprise && preEmotionNum == angry && emotionNum == angry) // 놀람 -> 화남 -> 화남
            {
                AddReward(-0.08f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == happy && emotionNum == happy) // 화남 -> 웃음 -> 웃음
            {
                AddReward(0.04f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == happy && emotionNum == natural) // 화남 -> 웃음 -> 자연스러움
            {
                AddReward(0.02f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == happy && emotionNum == surprise) //화남 -> 웃음 -> 놀람
            {
                AddReward(-0.01f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == happy && emotionNum == angry) // 화남 -> 웃음 -> 화남
            {
                AddReward(-0.07f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == natural && emotionNum == happy) // 화남 -> 자연스러움 -> 웃음
            {
                AddReward(0.01f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == natural && emotionNum == natural) // 화남 -> 자연스러움 -> 자연스러움
            {
                AddReward(-0.02f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == natural && emotionNum == surprise) // 화남 -> 자연스러움 -> 놀람
            {
                AddReward(-0.01f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == natural && emotionNum == angry) // 화남 -> 자연스러움 -> 화남
            {
                AddReward(-0.1f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == surprise && emotionNum == happy) // 화남 -> 놀람 -> 웃음
            {
                AddReward(0.005f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == surprise && emotionNum == natural) // 화남 -> 놀람 -> 자연스러움
            {
                AddReward(-0.015f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == surprise && emotionNum == surprise) // 화남 -> 놀람 -> 놀람
            {
                AddReward(-0.02f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == surprise && emotionNum == angry) // 화남 -> 놀람 -> 화남
            {
                AddReward(-0.075f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == angry && emotionNum == happy) // 화남 -> 화남 -> 웃음
            {
                AddReward(0.001f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == angry && emotionNum == natural) //화남 -> 화남 -> 자연스러움
            {
                AddReward(-0.004f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == angry && emotionNum == surprise) //화남 -> 화남 -> 놀람
            {
                AddReward(-0.06f);
            }
            else if (oldPreEmotionNum == angry && preEmotionNum == angry && emotionNum == angry) //화남 -> 화남 -> 화남
            {
                AddReward(-0.1f);
            }

        }

        oldPreEmotionNum = preEmotionNum;
        preEmotionNum = emotionNum;

        Monitor.Log(name, GetCumulativeReward(), transform);

    }
}
