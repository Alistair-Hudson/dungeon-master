using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float aimlessRange = 5f;
    [SerializeField] int cost = 100;
    //[SerializeField] float damage = 50f;


    HeroAI[] heros;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    Vector3 aimlessDestination;
    //bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GetComponentInParent<MinionSpawner>().IncreasePopulationCount();
        GetComponentInParent<MinionSpawner>().DecreaseGold(cost);
    }

    private void OnDestroy()
    {
        try
        {
            GetComponentInParent<MinionSpawner>().DecreasePopulationCount();
        }catch(Exception e)
        {
            Debug.Log(e.GetBaseException());
        }
    }

    // Update is called once per frame
    void Update()
    {
        heros = FindObjectsOfType<HeroAI>();
        
        foreach (HeroAI hero in heros)
        {
            distanceToTarget = Vector3.Distance(hero.transform.position, transform.position);
            if (chaseRange >= distanceToTarget)
            {
                EngageHero(hero);
                return;
            }

        }

        MoveAimlessly();

    }

    private void MoveAimlessly()
    {
        if (aimlessDestination != null)
        {
            float distanceToDest = Vector3.Distance(aimlessDestination, transform.position);
            if (distanceToDest >= navMeshAgent.stoppingDistance)
            {
                navMeshAgent.SetDestination(aimlessDestination);
                return;
            }
        }
        aimlessDestination = new Vector3(UnityEngine.Random.Range(transform.position.x - aimlessRange, transform.position.x + aimlessRange),
                                            0,
                                            UnityEngine.Random.Range(transform.position.z - aimlessRange, transform.position.z + aimlessRange));
    }

    //public void OnHit()
    //{
    //    isProvoked = true;
    //}

    private void EngageHero(HeroAI hero)
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            MoveToHero(hero);
        }


        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            FaceHero(hero);
            AttackHero(hero);
        }
    }

    private void AttackHero(HeroAI hero)
    {
        GetComponent<Animator>().SetTrigger("TriggerAttack");

    }

    //void HitTarget()
    //{
    //    target.GetComponent<PlayerHealth>().TakeDamage(damage);
    //}

    void FaceHero(HeroAI hero)
    {
        Vector3 direction = (hero.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void MoveToHero(HeroAI hero)
    {
        //GetComponent<Animator>().SetTrigger("TriggerMove");
        navMeshAgent.SetDestination(hero.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public int GetCost()
    {
        return cost;
    }
}
