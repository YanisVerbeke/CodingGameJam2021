using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //transform.position += new Vector3(Input.GetAxis("Horizontal") * _speedForce * Time.deltaTime, 0, 0);
        _rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * _speedForce, _rigidbody.velocity.y, 0);

        if (Input.GetButton("Jump") && _onGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _onGrounded = false;
        }

        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            foreach (ContactPoint hitPos in collision.contacts)
            {
                Debug.Log(hitPos.normal.ToString());
                if (hitPos.normal.x != 0) // check if the wall collided on the sides
                {
                    _onGrounded = false; // boolean to prevent player from being able to jump
                }
                else if (hitPos.normal.y > 0) // check if its collided on top 
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, 0);
                    _onGrounded = true;
                    print("grounded");
                }
                else _onGrounded = false;
            }
        }
    }
}
