using System;
using UnityEngine;
using UnityEngine.AI;

public class RangeNPC : NPC
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform ProjectilePosition;

    protected override void AttackingUpdate()
    {
        if (playerDistance < attackDistance && IsPlayerInFOV())
        {
            agent.isStopped = true;
            if (Time.time - lastAttackTime > attackRate)
            {
                lastAttackTime = Time.time;

                GameObject bullet = Instantiate(projectile, ProjectilePosition.position, Quaternion.identity);
                bullet.GetComponent<EnemyProjectile>().damage = this.damage;

                animator.speed = 1;
                animator.SetTrigger("Attack");
            }
        }
        else
        {
            if (playerDistance < detectDistance)
            {
                agent.isStopped = false;
                NavMeshPath path = new NavMeshPath();
                if (agent.CalculatePath(CharacterManager.Instance.Player.transform.position, path))
                {
                    agent.SetDestination(CharacterManager.Instance.Player.transform.position);
                }
                else
                {
                    agent.SetDestination(transform.position);
                    agent.isStopped = true;
                    SetState(AIState.Wandering);
                }
            }
            else
            {
                agent.SetDestination(transform.position);
                agent.isStopped = true;
                SetState(AIState.Wandering);
            }
        }

    }


}