using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using Yarn.Unity;

public class PlayerMovement : MonoBehaviour
{
    //Player Movement
    [SerializeField] GameObject GroundTest; 
    Rigidbody _myRigidbody;
    public Vector3 move; 
    public float _speed;
    public float _acceleration;
    public float _jumpForce;
    public float _gravity;
    float _startSpeed;
    float _halfSpeed; 
    float verticalVelocity;
    bool _isGrounded = true;

    public bool _moving = false;

    private void Start()
    {
        _myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        _startSpeed = _speed;
        _halfSpeed = _speed * .75f; 
    }
    void FixedUpdate()
    {
        if(!GameManager.Instance.pauseActive)
        {
            Move();
            Jump();
        }       
    }

    private void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        if (xDir != 0 || zDir != 0)
            _moving = true; 
        else 
            _moving = false;

        if (xDir != 0 && zDir != 0)
        { 
            _speed = _halfSpeed; 
        }
        else
        {
            _speed = _startSpeed;
        }

        move = transform.right * xDir * _acceleration + transform.forward * zDir * _acceleration;

        _myRigidbody.velocity = new Vector3(move.x * _speed, verticalVelocity, move.z * _speed);
    }
    private void Jump()
    { 
        _isGrounded = GroundTest.gameObject.GetComponent<GroundedTest>()._isGrounded;

        if (_isGrounded)
        {
            verticalVelocity = -_gravity;
            if (Input.GetAxis("Jump") == 1)
            {
                verticalVelocity = _jumpForce;
                _myRigidbody.velocity += (Vector3.up * _jumpForce);
                _isGrounded = false;
            }
        }
        else
        {
            verticalVelocity -= _gravity;
        }
    }


}
