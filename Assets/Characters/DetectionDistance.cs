using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionDistance : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _interactionShortDistance = 2f;
    [SerializeField] private float _interactionLongDistance = 10f;
    [SerializeField] private float _interactionContactDistance = 0.5f;
    // Start is called before the first frame update
    public void Start()
    {

    }


    public void Update()
    {
        IsTargetInShortRange();
        IsTargetInLongRange();
        IsTargetInContact();
    }
    public bool IsTargetInShortRange()
    {
        if (Vector3.Distance(transform.position, _target.position) <= _interactionShortDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsTargetInLongRange()
    {
        if (Vector3.Distance(transform.position, _target.position) >= _interactionLongDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsTargetInContact()
    {
        if (Vector3.Distance(transform.position, _target.position) <= _interactionContactDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
