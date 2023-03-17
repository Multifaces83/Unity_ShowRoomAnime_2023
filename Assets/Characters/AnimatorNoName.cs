using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorNoName : MonoBehaviour
{
    //je recupere mes mon input action
    public InputActionAsset inputActionAsset;
    [SerializeField] private Animator animator;
    private float walkForward;
    private float SlowRun;
    private float FastRun;

    internal void SetFloat(string v, float magnitude)
    {
        throw new NotImplementedException();
    }

    //je recupere mon action walk forward

    // Start is called before the first frame update
    void Start()
    {
        walkForward = inputActionAsset["WalkForward"].ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkForward > 0.1f)
        {
            //animator.SetFloat("Speed", 2f);
        }
        else
        {
            //animator.SetFloat("Speed", 1f);
        }
    }
}
