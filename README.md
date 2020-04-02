


MLAgents-NUITRACK-REALSENSE
===

 > ## Intro

   ML-Agents and NUITRACK detect target's emotion. And reaction to target.

   Some sick people want shared there's feeling with anythings. Sometimes. But it's not easy. So I want they are sharing feels with A.I.

   This project is first step my hope.

 > ## Using

   NUITRACK SDK(Face-tracking).

   INTEL REALSENS(d435i).

   ML-Agents(Unity3D).

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

## Description
This project have a 2 brain. One is Player brain in Unity's ML-Agents. Another is Learning brain.

This brain waiting at inputting 2 observing values. (one is emotion. Another is my intentions(It just sending with key code(free Nuitrack has a limit 3 minutes. So I can't progress Learning with NuitrackSDK.). but it will be changing)) 

Anyway new brain(Learning Brain) imitate player brain's decision with imitation Learning.

In this case, Imitation Learning, player brain is teacher brain and the new brain, Learning brain(In Unity's ML-Agents brain), be student brain. So student brain decide following teacher brain decision.

## License
NuitrackSDK : Copyright © 2018 Tsukasa SUGIURA Distributed under the MIT License.

Unity ML-Agents : Apache License 2.0
