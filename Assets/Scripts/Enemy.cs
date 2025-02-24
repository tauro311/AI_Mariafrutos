using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// componente de ordenes para que se mueva el enemigo 
public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform[] _patrolPoints;
    private int _patrolIndex; 
    private Transform _playerTransform;
    [SerializeField] private float _visionRange = 15;
    [SerializeField] private float _attackRange = 3;
    public enum EnemyState
    {
        Patrolling,
        Searching,
        Chasing,
        Waiting,
        Attacking 


    }
    
    public EnemyState currentState;
    // Start is called before the first frame update
    void Awake()
    {
         _agent = GetComponent<NavMeshAgent>();
         _playerTransform = GameObject.FindWithTag("Player").transform;
    }
    // Update is called once per frame
    void Start()
    {
        currentState = State.Patrolling;
        SetPatrolPoint;
    }
    void Update()
    {
        switch(currentState)//
        {
            case State.Patrolling:
             Patrol();
            break;

            case State.Searching:
             Search();
            break;

            case State.Chasing:
             Chase();
            break;

            case State.Waiting:
             Wait();
            break;

            case State.Attacking:
            Attack();
            break;


        }
    }


    void SetPatrolPoint()
   
    {  
    
      _agent.destination = _patrolPoints[_patrolIndex].position;
      _patrolIndex++;
      if(_patrolIndex >= _patrolPoints.Length)
      {
        _patrolIndex = 0;
      }
      
    } 
    void Patrol()
    {

        if(InRange(_visionRange))
        {
            currentState = State.Chasing;
        }
        if(_agent.remainingDistance < 0.5f)
        {
            SetPatrolPoint();


        }
    }
    void Chase()
    {
       
         if(InRange(_visionRange))
        {
            currentState = State.Patrolling;
        }
        
        if(InRange(_attackRange))
         {
            currentState = State.Attacking;
         }
        _agent.destination = _playerTransform.position;


    }

    bool InRange(float range)
    {
        return Vcetor3.Distance(tranform.position, _playerTransform.position) < range;

    }
    void Search()
    {

    }
   
    void wait()
    {

    }
    void Attack()
    {
        Debug.Log("atacando");
        currentState = State.Searching;

    }
}
