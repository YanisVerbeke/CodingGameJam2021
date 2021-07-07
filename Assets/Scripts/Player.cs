using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private int _speedForce;
    [SerializeField]
    private int _jumpForce;
    [SerializeField]
    private bool _onGrounded;
    private bool _isJumping;

    private int _idPlayer;
    private int _selectedSkin = 0;

    private Vector3 _movementVelocity;
    private Vector3 _gravity;

    public Animator animator;

    private PlayerController _playerController;
    private MenuController _menuController;

    public int PlayerId { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _speedForce = 10;
        _jumpForce = 65;

        _movementVelocity = new Vector3();
        _isJumping = false;
        _gravity = Vector3.down;
        _playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        _menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        _idPlayer = PlayerState.playerList.Count+1;
        _playerController.AddPlayer(this.gameObject);
        SetActiveAllChild(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Augmente la gravit? en fonction de la v?locit? y 
        // Permet que ?a ne d?passe pas un minimum
        //Physics.gravity = new Vector3(0, Mathf.Clamp(-20 + _rigidbody.velocity.y * 8, -30, -20), 0);
        _gravity = new Vector3(0, Mathf.Clamp(-20 + _rigidbody.velocity.y * 10, -30, -20), 0);

    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(_movementVelocity.x - _rigidbody.velocity.x, 0, 0), ForceMode.VelocityChange);

        if (_isJumping)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumping = false;
        }

        _rigidbody.AddForce(_gravity * _rigidbody.mass, ForceMode.Acceleration);
    }

    private void SetActiveAllChild(bool isActive)
    {
        foreach (Transform child in this.gameObject.transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }

    private void OnMovement(InputValue value)
    {
        _movementVelocity = Vector3.right * Mathf.Round(value.Get<Vector2>().x) * _speedForce;
        //Debug.Log(Mathf.Round(value.Get<Vector2>().x));
        animator.SetInteger("dX", (int)Mathf.Round(value.Get<Vector2>().x));
    }

    private void OnJump()
    {
        //Debug.Log("Jump");
        if (_onGrounded)
        {
            _isJumping = true;
        }
    }

    void OnTurnRight()
    {
        _selectedSkin++;
        Debug.Log("Right" + _idPlayer);
        _selectedSkin = _menuController.ChangeSkin(_selectedSkin, _idPlayer);
    }
    
    void OnTurnLeft()
    {
        _selectedSkin--;
        _selectedSkin = _menuController.ChangeSkin(_selectedSkin, _idPlayer);
        Debug.Log("Left");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            foreach (ContactPoint hitPos in collision.contacts)
            {
                if (hitPos.normal.x != 0 && !_onGrounded) // check if the wall collided on the sides
                {
                    _onGrounded = false; // boolean to prevent player from being able to jump
                }
                else if (hitPos.normal.x != 0 && _onGrounded)
                {
                    _onGrounded = true;
                }
                else if (hitPos.normal.y > 0) // check if its collided on top 
                {
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
