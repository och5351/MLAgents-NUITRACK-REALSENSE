# MLAgents-NUITRACK-REALSENSE
 ## Intro

ML-Agents and NUITRACK detect target's emotion. and reaction to target 

Some sick people want shared there's feeling with anythings. sometimes.
But it's not easy.
So I want sharing feels with A.I. 

This project is first step my hope.

## Used
 NUITRACK SDK(Face-track).
 
 INTEL REALSENS(d435i).
 
 ML-Agents(Unity3D).
 
## Progress
Success Connecting RealSense with Unity3D.

Success detecting target's emotions with applying NuitrackSDK.

Success Connecting NuitrackSDK with ML-Agents. (Inheriting Agent Class in FaceManager class in NuitrackSDK).

Currently training AI(Using Imitation Learning) and I plan to connect Unity-chan, a 3d model.


## Scene Location
Assets\FaceTracker\FinalAssets\FaceTracking.unity

## Discription

This project have a 2 brain.
One is Player brain in Unity's ML-Agents

This brain waiting inputing 2 observing values. (one is emotion. another is my intentions(It's just sending with keycode))
First free Nuitrack has a limit 3 minuites. so I can't progress Learning with NuitrackSDK. 

Anyway imitation Learning new brain(Learning Brain) with player brain.

In this case, Imitation Learning, player brain is teacher brain and the new brain, Learninig brain(In Unity's ML-Agents brain), be student brain. so student brain decise following teacher brain decision. 


## License

- NuitrackSDK : 
Copyright © 2018 Tsukasa SUGIURA
Distributed under the MIT License.

 - Unity ML-Agents : 
Apache License 2.0
