using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //[SerializeField] float chaseRange = 5f;
    //[SerializeField] float turnSpeed = 5f;
    //[SerializeField] float damage = 50f;


    Transform target;
    NavMeshAgent navMeshAgent;
    //float distanceToTarget = Mathf.Infinity;
    //bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        target = FindObjectOfType<Goal>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //distanceToTarget = Vector3.Distance(target.position, transform.position);
        //if (isProvoked)
        //{
        //    EngageTarget();
        //}
        //else if (chaseRange >= distanceToTarget)
        //{
        //    isProvoked = true;
        //}
        MoveToGoal();
    }

    //public void OnHit()
    //{
    //    isProvoked = true;
    //}

    //private void EngageTarget()
    //{
    //    if (distanceToTarget >= navMeshAgent.stoppingDistance)
    //    {
    //        ChaseTarget();
    //    }


    //    if (distanceToTarget <= navMeshAgent.stoppingDistance)
    //    {
    //        FaceTarget();
    //        AttackTarget();
    //    }
    //}

    //private void AttackTarget()
    //{
    //    GetComponent<Animator>().SetTrigger("TriggerAttack");

    //}

    //void HitTarget()
    //{
    //    target.GetComponent<PlayerHealth>().TakeDamage(damage);
    //}

    //void FaceTarget()
    //{
    //    Vector3 direction = (target.position - transform.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    //}

    private void MoveToGoal()
    {
        //GetComponent<Animator>().SetTrigger("TriggerMove");
        navMeshAgent.SetDestination(target.position);
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, chaseRange);
    //}
}
