using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    Animator animator;
    float damage = 1f;
    private bool flag = true;
    public bool isDied = false;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool isPatroling = true;
    public Transform[] waypoints;
    public float speed = 2;
    int currentWayPoint = 0;
    Vector3 target1, moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.forward * 5, Color.green);
        Debug.DrawRay(transform.position, Vector3.right * 5, Color.green);
        Debug.DrawRay(transform.position, Vector3.left * 5, Color.green);
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isPatroling)
        {
            Patrol();
        }
        if (isProvoked)
        {
            EngageTraget();
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hit, 5) || Physics.Raycast(transform.position, Vector3.right, out hit, 5) || Physics.Raycast(transform.position, Vector3.left, out hit, 5))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                isPatroling = false;
                isProvoked = true;
            }
        }
    }

    private void Patrol()
    {
        target1 = waypoints[currentWayPoint].position;
        moveDirection = target1 - transform.position;
        if (moveDirection.magnitude < 1)
        {
            currentWayPoint = ++currentWayPoint % waypoints.Length;
            StartCoroutine(Stay());
        }
        transform.LookAt(target1);
        GetComponent<Rigidbody>().velocity = moveDirection.normalized * speed;
    }
    IEnumerator Stay()
    {
        flag = false;
        yield return new WaitForSeconds(5);
        flag = true;
    }

    private void EngageTraget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            animator.SetTrigger("Chase");
            speed = 4;
            chaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            animator.SetTrigger("Attack");
            AttackTarget();
        }
    }
    private void chaseTarget()
    {

        navMeshAgent.SetDestination(target.position);
    }
    private void AttackTarget()
    {
        if (target == null) return;
          target.GetComponent<PlayerHealth>().TakeDamage(damage);
        //Debug.Log(name + " has seekes and destroying" + target.name);
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    public void setDied(Boolean bol)
    {
        isDied = bol;
    }
}

