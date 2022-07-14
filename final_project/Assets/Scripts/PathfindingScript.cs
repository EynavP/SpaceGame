using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathfindingScript : MonoBehaviour
{
    public Transform target;
    [SerializeField] float turnSpeed = 5f;
    float damage = 1f;
    NavMeshAgent agent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        FaceTarget();
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        agent.SetDestination(target.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            animator.SetTrigger("Attack");
            AttackTarget();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void AttackTarget()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        //Debug.Log(name + " has seekes and destroying" + target.name);
    }
}
