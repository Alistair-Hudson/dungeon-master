using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroAI : MonoBehaviour
{
    [SerializeField] float fightRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    //[SerializeField] float damage = 50f;


    Transform target;
    NavMeshAgent navMeshAgent;
    MonsterAI[] monsters;
    float distanceToTarget = Mathf.Infinity;
    //bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Goal>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        monsters = FindObjectsOfType<MonsterAI>();

        foreach (MonsterAI monster in monsters)
        {
            distanceToTarget = Vector3.Distance(monster.transform.position, transform.position);
            if (fightRange >= distanceToTarget)
            {
                EngageTarget(monster);
                return;
            }
        }

        MoveToGoal();
    }

    //public void OnHit()
    //{
    //    isProvoked = true;
    //}

    private void EngageTarget(MonsterAI monster)
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            MoveToMonster(monster);
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            FaceMonster(monster);
            AttackMonster(monster);
        }
    }

    private void MoveToMonster(MonsterAI monster)
    {
        navMeshAgent.SetDestination(monster.transform.position);
    }

    private void AttackMonster(MonsterAI monster)
    {
        GetComponent<Animator>().SetTrigger("TriggerAttack");

    }

    //void HitTarget()
    //{
    //    target.GetComponent<PlayerHealth>().TakeDamage(damage);
    //}

    void FaceMonster(MonsterAI monster)
    {
        Vector3 direction = (monster.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void MoveToGoal()
    {
        //GetComponent<Animator>().SetTrigger("TriggerMove");
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fightRange);
    }
}
