using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class BallAgent : Agent
{
    private Rigidbody ballRigidbody; //볼의 리지드바디

    public Transform pivotTransform; //위치의 기준점

    public Transform target; //아이템의 목표

    public float moveForce = 10f; //이동 힘

    private bool targetEaten = false; //목표를 먹었는지

    private bool dead = false; //사망상태


    void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody>();
    }

    void ResetTarget()
    {
        targetEaten = false;
        Vector3 randomPos = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));
        target.position = randomPos + pivotTransform.position;
    }

    public override void AgentReset()
    {

        Vector3 randomPos = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));
        transform.position = randomPos + pivotTransform.position;

        dead = false;
        ballRigidbody.velocity = Vector3.zero;

        ResetTarget();
    }

    public override void CollectObservations()
    {
        Vector3 distanceToTarget = target.position - transform.position;

        //-5 +5 -> -1 ~ +1
        AddVectorObs(Mathf.Clamp(distanceToTarget.x / 5f, -1f, 1f));
        AddVectorObs(Mathf.Clamp(distanceToTarget.z / 5f, -1f, 1f));

        Vector3 relativePos = transform.position - pivotTransform.position;

        //-5 +5
        AddVectorObs(Mathf.Clamp(relativePos.x / 5f, -1f, 1f));
        AddVectorObs(Mathf.Clamp(relativePos.z / 5f, -1f, 1f));

        //-10 +10 -> -1 ~ +1
        //-3 -> -0.3, 2.5 -> 0.25
        AddVectorObs(Mathf.Clamp(ballRigidbody.velocity.x / 10f, -1f, 1f));
        AddVectorObs(Mathf.Clamp(ballRigidbody.velocity.z / 10f, -1f, 1f));

    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        AddReward(-0.001f);

        float horizontalInput = vectorAction[0];
        float verticalInput = vectorAction[1];

        ballRigidbody.AddForce(horizontalInput * moveForce, 0f, verticalInput * moveForce);

        if (targetEaten)
        {
            AddReward(1.0f);
            ResetTarget();
        }
        else if (dead)
        {
            AddReward(-1.0f);
            Done();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dead"))
        {
            dead = true;

        }
        else if (other.CompareTag("goal"))
        {
            targetEaten = true;
        }
    }

}
