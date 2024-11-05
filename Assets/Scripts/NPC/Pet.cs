using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Pet : Entity
{
    //�÷��̾ �����Ÿ� �̻� �Ѿ�� �÷��̾ �i�ư���.

    protected override void Update()
    {
        base.Update();

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
        if (aiState == AIState.Wandering && agent.remainingDistance < 0.1f)
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
        Vector3 playerPos = CharacterManager.Instance.Player.transform.position;

        //�÷��̾�� �ٰ����� Wander Ȥ�� Idle�Ѵ�.
        
        //�÷��̾�� �ٰ��� �� ������ �����̵��Ѵ�.

        agent.SetDestination(playerPos + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)));
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