using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private int _speedForce;
    [SerializeField]
    private int _jumpForce;
    [SerializeField]
    private bool _onGrounded;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speedForce = 8;

    }

    // Update is called once per frame
    void Update()
    {
        // Augmente la gravité en fonction de la vélocité y 
        // Permet que ça ne dépasse pas un minimum
        Physics.gravity = new Vector3(0, Mathf.Clamp(-20 + _rigidbody.velocity.y * 8, -30, -20), 0);
    }

    private void OnMovement(InputValue value)
    {
        _rigidbody.velocity = new Vector3(value.Get<Vector2>().x * _speedForce, _rigidbody.velocity.y, 0);
    }

    private void OnJump()
    {
        Debug.Log("Jump");
        if (_onGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _onGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            foreach (ContactPoint hitPos in collision.contacts)
            {
                if (hitPos.normal.x != 0) // check if the wall collided on the sides
                {
                    _onGrounded = false; // boolean to prevent player from being able to jump
                }
                else if (hitPos.normal.y > 0) // check if its collided on top 
                {
                    //_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, 0);
                    _onGrounded = true;
                }
                else _onGrounded = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            _onGrounded = false;
        }
    }
}
