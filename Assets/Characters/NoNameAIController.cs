using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(DetectionDistance))]
[RequireComponent(typeof(PatrolAI))]
public class NoNameAIController : MonoBehaviour
{
    private enum State
    {
        Idle,
        //Walk,
        Patrol,
        goToTarget,
        //Run,        
        Talk
        //Attack,
        //Die
    }

    [SerializeField] private Transform _target;
    private State _state;
    private State _nextState;
    private Animator _animator;
    private NavMeshAgent _agent;
    private DetectionDistance _detectionDistance;
    private PatrolAI _patrolAI;
    [SerializeField] private Transform _lookAtTarget;
    //private float _idleDuration = 5f;

    void Start()
    {

        _detectionDistance = GetComponent<DetectionDistance>();
        _patrolAI = GetComponent<PatrolAI>();
        IsActivated();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _state = State.Idle;
        _nextState = _state;
        StartState();
    }

    void Update()
    {
        if (CheckForTransition())
        {
            Transition();
        }
        Behaviour();
    }

    private bool CheckForTransition()
    {
        switch (_state)
        {
            case State.Idle:
                // Transition vers l'état patrouille si l'IA est activée
                if (IsActivated())
                {
                    _nextState = State.Patrol;
                    return true;
                }
                break;
            case State.Patrol:
                // Transition vers l'état se déplacer vers le joueur s'il est à portée
                if (_detectionDistance.IsTargetInShortRange())
                {
                    _nextState = State.goToTarget;
                    return true;
                }
                // Transition vers l'état Idle si l'IA est désactivée
                if (!IsActivated())
                {
                    _nextState = State.Idle;
                    return true;
                }
                break;
            case State.goToTarget:
                // Transition vers l'état parler si le joueur est à portée
                if (_detectionDistance.IsTargetInContact())
                {
                    _nextState = State.Talk;
                    return true;
                }
                break;
            case State.Talk:
                // Transition vers l'état Patrol
                if (_detectionDistance.IsTargetInLongRange())
                {
                    _nextState = State.Patrol;
                    return true;
                }
                break;
        }
        return false;
    }

    private void Transition()
    {
        EndState();
        _state = _nextState;
        StartState();
    }

    private void StartState()
    {
        switch (_state)
        {
            case State.Idle:
                // Commencez l'animation Idle
                break;
            case State.Patrol:
                _patrolAI.Patrol();
                break;
            // Commencer l'animation Patrol pour aller vers le joueur
            case State.goToTarget:
                moveToTarget();
                break;
            case State.Talk:
                // Commencez l'animation Talk
                _animator.SetBool("Talk", true);
                break;
        }
    }

    private void EndState()
    {
        switch (_state)
        {
            case State.Idle:
                // Arrêtez l'animation Idle                
                break;
            case State.Patrol:
                _patrolAI.StopPatrol();
                break;
            case State.Talk:
                // Arrêtez l'animation Talk
                _animator.SetBool("Talk", false);
                break;
        }
    }

    private void Behaviour()
    {
        switch (_state)
        {
            case State.Idle:
                // L'IA ne fait rien en mode Idle
                break;
            case State.Patrol:
                // L'IA patrouille vers des points de patrouille définis
                _patrolAI.Patrol();
                break;
            case State.Talk:
                // L'IA parle au futur ennemi
                Talk();
                break;
        }
    }

    private bool IsActivated()
    {
        return true;
    }
    private void Talk()
    {
        transform.LookAt(_target);
    }
    private void moveToTarget()
    {
        _agent.isStopped = false;
        _agent.SetDestination(_target.position);
        transform.LookAt(_lookAtTarget);
        _agent.speed = 0.5f;
        _agent.stoppingDistance = 0.5f;

    }

}
