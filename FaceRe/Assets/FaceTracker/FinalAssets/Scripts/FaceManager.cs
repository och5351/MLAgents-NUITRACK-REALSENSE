using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using System.Collections;

public enum Gender
{
    any,
    male,
    female
}

public enum AgeType
{
    any,
    kid,
    young,
    adult,
    senior
}

public enum EmotionType
{
    any,
    happy,
    surprise,
    neutral,
    angry
}

public class FaceManager : Agent
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject faceController;
    [SerializeField] SkeletonController skeletonController;

    List<FaceController> faceControllers = new List<FaceController>();
    Instances[] faces;
    FaceInfo faceInfo;

    //표정 변화값 변수    
    public GameObject anim;
    int oldPreEmotionNum = 4;
    int preEmotionNum = 4;
    int emotionNum = 4;
    int expressionSelectNum = 8;
    Stack<int> emotionStack = new Stack<int>();
    Stack<int> restStack = new Stack<int>();

    //표정 문자화
    int angry = 0;
    int surprise = 1;
    int netural = 2;
    int happy = 3;
    int empty = 4;


    void Start()
    {
        anim.GetComponent<MainAnimator>().expression(11);
        for (int i = 0; i < skeletonController.skeletonCount; i++)
        {
            faceControllers.Add(Instantiate(faceController, canvas.transform).GetComponent<FaceController>());
        }       
    }
   
    void Update()
    {
        string json = nuitrack.Nuitrack.GetInstancesJson();
        faceInfo = JsonUtility.FromJson<FaceInfo>(json.Replace("\"\"", "[]"));

        faces = faceInfo.Instances;
        for (int i = 0; i < faceControllers.Count; i++)
        {
            if (faces != null && i < faces.Length)
            {              
   
                int id;
                Face currentFace = faces[i].face;
                // Pass the face to FaceController
                faceControllers[i].SetFace(currentFace);
                faceControllers[i].gameObject.SetActive(true);
              
                restStack.Clear();
                //표정스택에 등록 1.화남//2.놀람//3.자연스러움//4.웃음
                if (faceControllers[i].emotions == EmotionType.angry)
                {
                    emotionStack.Push(0);
                }
                else if (faceControllers[i].emotions == EmotionType.surprise)
                {
                    emotionStack.Push(1);
                }
                else if (faceControllers[i].emotions == EmotionType.neutral)
                {
                    emotionStack.Push(2);
                }
                else if (faceControllers[i].emotions == EmotionType.happy)
                {
                    emotionStack.Push(3);
                }

                if (emotionStack.Count == 250)
                {
                    int[] emoAvg = { 0, 0, 0, 0 };
                    int temp = 0;
                    for (int j = 0; j < emotionStack.Count; j++)
                    {
                        temp = emotionStack.Pop();
                        if (temp == 0)
                        {
                            emoAvg[0]++;
                        }
                        else if (temp == 1)
                        {
                            emoAvg[1]++;
                        }
                        else if (temp == 2)
                        {
                            emoAvg[2]++;
                        }
                        else if (temp == 3)
                        {
                            emoAvg[3]++;
                        }
                    }
                    temp = 0;
                    int count = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (temp <= emoAvg[j])
                        {
                            temp = emoAvg[j];
                            count = j;
                        }
                    }
                    emotionNum = count;
                    RequestDecision();
                }



                // IDs of faces and skeletons are the same
                id = faces[i].id;

                nuitrack.Skeleton skeleton = null;
                if (NuitrackManager.SkeletonData != null)
                    skeleton = NuitrackManager.SkeletonData.GetSkeletonByID(id);

                if (skeleton != null)
                {
                    nuitrack.Joint head = skeleton.GetJoint(nuitrack.JointType.Head);

                    faceControllers[i].transform.position = new Vector2(head.Proj.X * Screen.width, Screen.height - head.Proj.Y * Screen.height);
                    //stretch the face to fit the rectangle
                    if (currentFace.rectangle != null)
                        faceControllers[i].transform.localScale = new Vector2(currentFace.rectangle.width * Screen.width, currentFace.rectangle.height * Screen.height);
                }
                
            }
            else
            {
                restStack.Push(4);               
                //emotionNum = 4;
                
                if(restStack.Count == 250 && preEmotionNum != 4)
                {
                    emotionNum = 4;
                    restStack.Clear();
                    RequestDecision();
                   
                }else if(preEmotionNum == 4 && restStack.Count > 600){
                    emotionNum = 4;
                    restStack.Clear();
                    RequestDecision();
                }
                //RequestDecision();
                faceControllers[i].gameObject.SetActive(false);                
            }
            if(faces == null)
            {               
                emotionNum = 4;
                RequestDecision();
            }
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
        expressionSelectNum = Mathf.FloorToInt(vectorAction[0]);        

        Debug.Log("emotionNum : " + emotionNum);
        Debug.Log("preEmtionNum : " + preEmotionNum);

        if (expressionSelectNum == 0)
        {
            Debug.Log("인공지능의 선택 값 : 울기");

            anim.GetComponent<MainAnimator>().expression(0);
        }
        else if (expressionSelectNum == 1)
        {
            Debug.Log("인공지능의 선택 값 : 주저 앉기");
            anim.GetComponent<MainAnimator>().expression(1);
        }
        else if (expressionSelectNum == 2)
        {
            Debug.Log("인공지능의 선택 값 : 두손 빌기");
            anim.GetComponent<MainAnimator>().expression(2);
        }
        else if (expressionSelectNum == 3)
        {
            Debug.Log("인공지능의 선택 값 : 머리 긁적이기");
            anim.GetComponent<MainAnimator>().expression(3);
        }
        else if (expressionSelectNum == 4)
        {
            Debug.Log("인공지능의 선택 값 : 놀라서 양팔들기");
            anim.GetComponent<MainAnimator>().expression(4);
        }
        else if (expressionSelectNum == 5)
        {
            Debug.Log("인공지능의 선택 값 : 하트 그리기");
            anim.GetComponent<MainAnimator>().expression(5);
        }
        else if (expressionSelectNum == 6)
        {
            Debug.Log("인공지능의 선택 값 : 부끄러워 다리 베베꼬기");
            anim.GetComponent<MainAnimator>().expression(6);
        }
        else if (expressionSelectNum == 7)
        {
            Debug.Log("인공지능의 선택 값 : 박수 치기");
            anim.GetComponent<MainAnimator>().expression(7);
        }
        else if (expressionSelectNum == 8)
        {
            Debug.Log("인공지능의 선택 값 : 쉬기");
            anim.GetComponent<MainAnimator>().expression(8);
        }
        else if (expressionSelectNum == 9)
        {
            Debug.Log("인공지능의 선택 값 : 춤추기");
            anim.GetComponent<MainAnimator>().expression(9);
        }
        else if (expressionSelectNum == 10)
        {
            Debug.Log("인공지능의 선택 값 : 손인사");
            anim.GetComponent<MainAnimator>().expression(10);
        }

        //화면에 비쳤을 때 쉬고 있으면
        if (emotionNum == 4)
        {
            AddReward(-0.031f);           

            if (expressionSelectNum == 8)
            {
                AddReward(0.1f);
            }
            else
                AddReward(-0.06f);

            preEmotionNum = 4;
        }
        else //화면에 있을 때
        {
            if (preEmotionNum == 4 && emotionNum != 4 && expressionSelectNum == 10) //처음 봤을 때 인사 하면
            {
                AddReward(0.02f);
            }
            else if (preEmotionNum != 4 && expressionSelectNum == 10)
            {
                AddReward(-0.02f);
            }


            //웃음 -> 웃음 -> 웃음
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
    }
   
}