using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedTest : MonoBehaviour
{
    public bool _isGrounded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isGrounded = false;
    }
}
