/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;
    private Animator _anim;
    private Rigidbody _rb;

    public float turnSpeed = 20f;
    public AudioSource _footsteps;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _footsteps = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;
        _anim.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!_footsteps.isPlaying)
            {
                _footsteps.Play();
            }
        }
        else
        {
            _footsteps.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, turnSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        _rb.MovePosition(_rb.position + _movement * _anim.deltaPosition.magnitude);
        _rb.MoveRotation(_rotation);
    }
}
