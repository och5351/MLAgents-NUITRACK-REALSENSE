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


    public static bool inDisplay = false;
    int preEmotionNum = 2;
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
            AddVectorObs(preEmotionNum);
            AddVectorObs(0);
            Debug.Log("화남");
            RequestAction();
        }
        else if (emotionNum == 1)
        {
            AddVectorObs(preEmotionNum);
            AddVectorObs(1);
            Debug.Log("놀람");
            RequestAction();
        }
        else if (emotionNum == 2)
        {
            AddVectorObs(preEmotionNum);
            AddVectorObs(2);
            Debug.Log("자연스러움");
            RequestAction();
        }
        else if (emotionNum == 3)
        {
            AddVectorObs(preEmotionNum);
            AddVectorObs(3);
            Debug.Log("웃음");
            RequestAction();
        }
        else if (emotionNum == 4) // 휴식
        {
            AddVectorObs(preEmotionNum);
            AddVectorObs(4);
            Debug.Log("화면에 없음");
            RequestAction();
        }

    }
    public override void AgentAction(float[] vectorAction, string textAction)
    {
       

        int expressionSelectNum = Mathf.FloorToInt(vectorAction[0]);

        if (expressionSelectNum == 0)
        {
            Debug.Log("인공지능의 선택 값 : 울기");
        }
        else if (expressionSelectNum == 1)
        {
            Debug.Log("인공지능의 선택 값 : 주저 앉기");
        }
        else if (expressionSelectNum == 2)
        {
            Debug.Log("인공지능의 선택 값 : 두손 빌기");
        }
        else if (expressionSelectNum == 3)
        {
            Debug.Log("인공지능의 선택 값 : 머리 긁적이기");
        }
        else if (expressionSelectNum == 4)
        {
            Debug.Log("인공지능의 선택 값 : 놀라서 양팔들기");
        }
        else if (expressionSelectNum == 5)
        {
            Debug.Log("인공지능의 선택 값 : 하트 그리기");
        }
        else if (expressionSelectNum == 6)
        {
            Debug.Log("인공지능의 선택 값 : 부끄러워 다리 베베꼬기");
        }
        else if (expressionSelectNum == 7)
        {
            Debug.Log("인공지능의 선택 값 : 박수 치기");
        }
        else if (expressionSelectNum == 8)
        {
            Debug.Log("인공지능의 선택 값 : 쉬기");
        }
        else if (expressionSelectNum == 9)
        {
            Debug.Log("인공지능의 선택 값 : 춤추기");
        }
        else if (expressionSelectNum == 10)
        {
            Debug.Log("인공지능의 선택 값 : 손인사");
        }

        //화면에 비쳤을 때 쉬고 있으면
        if (emotionNum == 4)
        {
            AddReward(-0.031f);

            if (expressionSelectNum == 8)
            {
                AddReward(0.1f);
            }else
                AddReward(-0.06f);
        }
        else
        {
            if(preEmotionNum == 4 && emotionNum != 4 && expressionSelectNum ==10)
            {
                AddReward(0.02f);
            }else if(preEmotionNum != 4 && expressionSelectNum == 10)
            {
                AddReward(-0.02f);
            }


            //웃음에서 웃음으로 갈 때    0.04f
            if (preEmotionNum == 3 && emotionNum == 3)
            {
                AddReward(0.06f);
                preEmotionNum = 3;
            }

            //웃음에서 자연스러움으로 갈 때  -0.001f
            else if (preEmotionNum == 3 && emotionNum == 2)
            {
                AddReward(-0.001f);
                preEmotionNum = 2;
            }

            //웃음에서 놀람으로 갈 때  -0.01f
            else if (preEmotionNum == 3 && emotionNum == 1)
            {
                AddReward(-0.01f);
                preEmotionNum = 1;
            }

            //웃음에서 화남으로 갈 때  -0.05f
            else if (preEmotionNum == 3 && emotionNum == 0)
            {
                AddReward(-0.05f);
                preEmotionNum = 0;
            }

            //자연스러움에서 자연스러움으로 갈 때  0.001f
            else if (preEmotionNum == 2 && emotionNum == 2)
            {
                AddReward(0.001f);
                preEmotionNum = 2;
            }

            //자연스러움에서 웃음으로 갈 때     0.04f
            else if (preEmotionNum == 2 && emotionNum == 3)
            {
                AddReward(0.04f);
                preEmotionNum = 3;
            }

            //자연스러움에서 놀람으로 갈 때    -0.01f
            else if (preEmotionNum == 2 && emotionNum == 1)
            {
                AddReward(-0.01f);
                preEmotionNum = 1;
            }

            //자연스러움에서 화남으로 갈 때     -0.1f
            else if (preEmotionNum == 2 && emotionNum == 0)
            {
                AddReward(-0.05f);
                preEmotionNum = 0;
            }

            //놀람에서 놀람으로 갈 때   -0.005
            else if (preEmotionNum == 1 && emotionNum == 1)
            {
                AddReward(-0.005f);
                preEmotionNum = 1;
            }

            //놀람에서 웃음으로 갈 때     0.05
            else if (preEmotionNum == 1 && emotionNum == 3)
            {
                AddReward(0.05f);
                preEmotionNum = 3;
            }

            //놀람에서 자연스러움으로 갈 때    0.01
            else if (preEmotionNum == 1 && emotionNum == 2)
            {
                AddReward(0.01f);
                preEmotionNum = 2;
            }

            //놀람에서 화남으로 갈 때    -0.05
            else if (preEmotionNum == 1 && emotionNum == 0)
            {
                AddReward(-0.05f);
                preEmotionNum = 0;
            }

            //화남에서 화남으로 갈 때    -0.1
            else if (preEmotionNum == 0 && emotionNum == 0)
            {
                AddReward(-0.1f);
                preEmotionNum = 0;
            }

            //화남에서 웃음으로 갈 때    0.06
            else if (preEmotionNum == 0 && emotionNum == 3)
            {
                AddReward(0.06f);
                preEmotionNum = 3;
            }

            //화남에서 자연스러움으로 갈 때   0.01
            else if (preEmotionNum == 0 && emotionNum == 2)
            {
                AddReward(0.01f);
                preEmotionNum = 2;
            }

            //화남에서 놀람으로 갈 때    0.005
            else if (preEmotionNum == 0 && emotionNum == 1)
            {
                AddReward(0.005f);
                preEmotionNum = 1;
            }
        }
       

        Monitor.Log(name, GetCumulativeReward(), transform);

    }
}
