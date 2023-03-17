using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshNoName : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private float _speed;
    //[SerializeField] private Transform _navPoint;
    [SerializeField] private Transform[] _navPoints;
    private Transform _lastNavPoint;



    // Start is called before the first frame update
    void Start()
    {
        //_animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _agent.updatePosition = false;
        _agent.SetDestination(_navPoints[3].position);


        // _lastNavPoint = _navPoints[3];
        // NavMeshPath path = new NavMeshPath();
        // _agent.CalculatePath(_lastNavPoint.position, path);
        // if (path.status == NavMeshPathStatus.PathPartial)
        // {
        //     Debug.Log("rtrgdgf");
        // }

        // for (int i = 0; i < _navPoints.Length; i++)
        // {
        //     _agent.nextPosition = _navPoints[i].position;
        //     _agent.updatePosition = true;
        // }



    }

    void Update()
    {

        _animator.SetFloat("speed", _agent.velocity.magnitude);
    }
}
