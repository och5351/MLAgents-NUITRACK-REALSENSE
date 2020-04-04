MLAgents-NUITRACK-REALSENSE
===

 > ## Intro

    ML-Agents and NUITRACK detect target's emotion. And reaction to target.
    Some sick people want shared there's feeling with anythings. Sometimes. But it's not easy. So I want they are sharing feels with A.I.
    This project is first step my hope.

 > ## Dubuging view
<p align="center">
<img src="https://user-images.githubusercontent.com/45858414/78201066-a134da00-74cb-11ea-8d82-1a9d26a8d9a8.png">
</p>

 > ## Using

    NUITRACK SDK(Face-tracking).

    INTEL REALSENS(d435i).

    ML-Agents(Unity3D).
    
    Unity-Chan 3D http://unity-chan.com 

 > ## Progress

    Success, Connecting RealSense with Unity3D.

    Success, detecting target's emotions with applying NuitrackSDK.

    Success, Connecting NuitrackSDK with ML-Agents. (Inheriting Agent Class in FaceManager class in NuitrackSDK).

    Success, Connecting Unity-chan with Brain. --19.11.22

    Success, model speak as script. (Only when rest time (I will more insert script)) --19.11.24

    Success, making model's motions smooth. -- 19.11.25

    Currently, training AI(Using Imitation Learning(Add a observation to existing ones. so increase number of cases of emotional change)).

 > ## Scene Location

    Assets\FaceTracker\FinalAssets\FaceTracking.unity

Description
---   

 > ## Detail
    
    This project have a 2 brain. One is Player brain in Unity's ML-Agents. Another is Learning brain.

    This brain waiting at inputting 2 observing values. (One is emotion. another is my intentions(It just sending with key code(free Nuitrack has a limit 3 minutes. So I can't progress Learning with NuitrackSDK.). but it will be changing)) 

    Anyway new brain(Learning Brain) imitate player brain's decision with imitation Learning.

    In this case, Imitation Learning, player brain is teacher brain and the new brain, Learning brain(In Unity's ML-Agents brain), be student brain. So student brain decide following teacher brain decision.
    
 > ## Action
       
                1. Frustration             2. Depression               3. Beg             4. Scratching head
<p align="center">
<img src="https://user-images.githubusercontent.com/45858414/78201915-d6dac280-74cd-11ea-9328-4f3b90a3805e.PNG" width="20%" height="300">
<img src="https://user-images.githubusercontent.com/45858414/78201999-14d7e680-74ce-11ea-9f6b-08fa973a71b2.PNG" width="20%" height="300">
<img src="https://user-images.githubusercontent.com/45858414/78202000-14d7e680-74ce-11ea-97cf-235e1fa371df.PNG" width="20%" height="300">
<img src="https://user-images.githubusercontent.com/45858414/78202001-15707d00-74ce-11ea-9686-b119859e7c78.PNG" width="20%" height="300">
 </p>

                5. Fall back               6. salute                   7. Ashamed          8. One turn kick
<p align="center">
<img src="https://user-images.githubusercontent.com/45858414/78202003-15707d00-74ce-11ea-8dad-454e911e1897.PNG" width="20%" height="300">
<img src="https://user-images.githubusercontent.com/45858414/78202004-16091380-74ce-11ea-80c3-29ddceb7a28f.PNG" width="20%" height="300">
<img src="https://user-images.githubusercontent.com/45858414/78202006-16091380-74ce-11ea-9291-74168b300b75.PNG" width="20%" height="300">
<img src="https://user-images.githubusercontent.com/45858414/78202007-16a1aa00-74ce-11ea-928d-f7d9517ae5d5.PNG" width="20%" height="300">
</p>

          9. hurray                  10. Hand greeting           11. Sit and rest    12. stretching    13. Little shake body
<p align="center">
<img src="https://user-images.githubusercontent.com/45858414/78202008-16a1aa00-74ce-11ea-9f1c-2529f80a37db.PNG" width="20%" height="300">
<img src="https://user-images.githubusercontent.com/45858414/78202010-173a4080-74ce-11ea-9628-a6e233d25623.PNG" width="20%" height="300">
<img src="https://user-images.githubusercontent.com/45858414/78202011-173a4080-74ce-11ea-9178-300aaf340b69.PNG" width="20%" height="300">
<img src="https://user-images.githubusercontent.com/45858414/78202012-17d2d700-74ce-11ea-808d-cadbc1720fa4.PNG" width="20%" height="300">
<img src="(https://user-images.githubusercontent.com/45858414/78201994-13a6b980-74ce-11ea-85e9-f0ed226945df.PNG" width="20%" height="300">
</p>
  
 > ## License

    NuitrackSDK : Copyright © 2018 Tsukasa SUGIURA Distributed under the MIT License.

    Unity ML-Agents : Apache License 2.0
