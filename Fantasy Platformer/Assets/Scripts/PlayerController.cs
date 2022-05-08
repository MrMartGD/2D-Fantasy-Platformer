using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 550f;

    private Player _player;
    private Animator _animator;
    private float _horizontalMove;
    private bool _isJumping;

    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
        Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MovingPlatform platform))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MovingPlatform platform))
        {
            this.transform.parent = null;
        }
    }

    private void Flip() 
    {
        if (_horizontalMove < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (_horizontalMove > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_isJumping == false) 
            {
                _player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce);
                _animator.SetTrigger(AnimatorPlayerController.States.Jump);
            }
        }
    }

    private void Move()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
        _player.transform.position = new Vector3(transform.position.x + _horizontalMove, transform.position.y, 0);

        if (_horizontalMove != 0)
        {
            _animator.SetFloat(AnimatorPlayerController.Params.Run, 1f);
        }
        else
        {
            _animator.SetFloat(AnimatorPlayerController.Params.Run, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground)) 
        {
            _isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            _isJumping = true;
        }
    }
}
