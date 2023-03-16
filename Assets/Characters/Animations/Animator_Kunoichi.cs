using UnityEngine;
using UnityEngine.InputSystem;

public class Animator_Kunoichi : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody rb;
    //private float _jumpDuration = 0.5f;
    private float _jumpHeight = 10.0f;

    void Start()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponentInChildren<Rigidbody>();

        // _animator.SetFloat("jumpDuration", _jumpDuration);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isWaiting", false);
            Debug.Log("Walking");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isWaiting", true);
            Debug.Log("Walking");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("jump");
            rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
            Debug.Log("jump");
        }



    }
}

