using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Pet : Entity
{
    //플레이어가 일정거리 이상 넘어가면 플레이어를 쫒아간다.
    private bool isFollowing = false;

    private void Start()
    {
        SetState(AIState.Wandering);
    }

    protected override void Update()
    {
        playerDistance = Vector3.Distance(transform.position, CharacterManager.Instance.Player.transform.position);

        animator.SetBool("Moving", aiState != AIState.Idle);

        switch (aiState)
        {
            case AIState.Idle:
            case AIState.Wandering:
                PassiveUpdate();
                break;
            case AIState.Following:
                FollowingUpdate();
                break;
        }
    }

    protected override void PassiveUpdate()
    {
        if (aiState != AIState.Wandering) return;
        else if (aiState == AIState.Wandering && agent.remainingDistance < 0.1f)
        {
            SetState(AIState.Idle);
            Invoke("WanderToNewLocation", Random.Range(minWanderWaitTime, maxWanderWaitTime));
        }

        if (playerDistance > detectDistance)
        {
            SetState(AIState.Following);
        }
    }


    private void FollowingUpdate()
    {
        if(aiState != AIState.Following) return;
        else if(aiState == AIState.Following && agent.remainingDistance < 0.1f)
        {
            SetState(AIState.Idle);
            Invoke("WanderToNewLocation", Random.Range(minWanderWaitTime, maxWanderWaitTime));
            isFollowing = false;
            return;
        }

        if (!isFollowing)
        {
            Vector3 playerPos = CharacterManager.Instance.Player.transform.position;
            //플레이어에게 다가가서 Wander 혹은 Idle한다.
            NavMeshPath path = new NavMeshPath();

            if (agent.CalculatePath(playerPos, path))
            {
                agent.SetDestination(playerPos);
                isFollowing = true;
            }
            //플레이어에게 다가갈 수 없으면 순간이동한다.
            else
            {
                agent.transform.position = playerPos + (Random.onUnitSphere * minWanderDistance);
                SetState(AIState.Idle);
                Invoke("WanderToNewLocation", Random.Range(minWanderWaitTime, maxWanderWaitTime));
                isFollowing = false;
                return;
            }


        }
    }

    protected override Vector3 GetWanderLocation()
    {
        NavMeshHit hit;
        Vector3 playerPos = CharacterManager.Instance.Player.transform.position;

        NavMesh.SamplePosition(playerPos + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);

        int i = 0;

        while (Vector3.Distance(playerPos, hit.position) < detectDistance)
        {
            NavMesh.SamplePosition(playerPos + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);
            i++;
            if (i == 30) break;
        }

        return hit.position;
    }

}