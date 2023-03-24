using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshNoName : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private float _speed;
    [SerializeField] private List<Transform> _navPoints;
    private int _currentNavPointIndex = 0;
    private float _stoppingDistance = 0.1f;
    [SerializeField] private Transform _player;
    [SerializeField] private float _interactionDistance = 2f;
    private bool _isInteracting = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _agent.stoppingDistance = _stoppingDistance;
        

         // Définir la destination initiale
        SetNextNavPoint();
    }

    void Update()
    {
        //Si l'agent n'est pas en train d'interagir
        if(!_isInteracting)
        {
            // Vérifier si l'agent est proche du point de destination actuel
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
            // Changer le point de destination
            SetNextNavPoint();
            }
            //Calcul de la distance entre l'agent et la position du joueur
            if(Vector3.Distance(transform.position,_player.position)<= _interactionDistance)
            {
            _isInteracting = true;
            _agent.SetDestination(transform.position);
            _animator.SetBool("isInteracting",true);
            }
        }
        else
        {
                        
        }

        // Mettre à jour la vitesse de l'animation en fonction de la vitesse de l'agent
        _animator.SetFloat("speed", _agent.velocity.magnitude);
    }

    // Fonction pour définir le prochain point de destination
    private void SetNextNavPoint()
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
}
