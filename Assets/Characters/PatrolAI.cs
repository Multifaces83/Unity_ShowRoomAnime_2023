using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] private List<Transform> _navPoints;
    [SerializeField] private int _currentNavPointIndex = 0;
    private Animator _animator;
    private float _stoppingDistance = 0.1f;
    // Start is called before the first frame update
    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _agent.stoppingDistance = _stoppingDistance;

        // Définir la destination initiale
        SetNextNavPoint();
    }

    // Update is called once per frame
    public void Update()
    {
        // if (_agent.remainingDistance <= _agent.stoppingDistance)
        //     {
        //     // Changer le point de destination
        //     SetNextNavPoint();
        //     }
        //     // Mettre à jour la vitesse de l'animation en fonction de la vitesse de l'agent
        // _animator.SetFloat("speed", _agent.velocity.magnitude);
        Patrol();
    }

    public void SetNextNavPoint()
    {
        // Si nous avons atteint le dernier point de navigation, revenir au début de la liste
        if (_currentNavPointIndex == _navPoints.Count)
        {
            _currentNavPointIndex = 0;
        }

        // Définir la destination de l'agent sur le prochain point de navigation
        _agent.SetDestination(_navPoints[_currentNavPointIndex].position);

        // Incrémenter l'index pour le prochain point de navigation
        _currentNavPointIndex++;
    }

    public void Patrol()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            // Changer le point de destination
            SetNextNavPoint();
        }
        // Mettre à jour la vitesse de l'animation en fonction de la vitesse de l'agent
        _animator.SetFloat("speed", _agent.velocity.magnitude);
    }
    public void StopPatrol()
    {
        _agent.isStopped = true;
    }
}
