using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;
    [SerializeField] private int _extraJumpValue;
    [SerializeField] private LayerMask _isGround;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private AudioSource _jumping;


    private int _extraJump;
    private float _moveImput;
    private bool _isFacingRight = true;
    private bool _onTheGround;
    private Rigidbody2D _rb;

    private void Start()
    {
        _extraJump = _extraJumpValue;
        _rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _onTheGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _isGround);

        _moveImput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_moveImput * _speed, _rb.velocity.y);
        if(!_isFacingRight && _moveImput > 0)
        {
            Flip();
        }else if(_isFacingRight && _moveImput < 0)
        {
            Flip();
        }

        #region Старый код
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(_speed * Time.deltaTime, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        //}

        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    transform.Translate(0, 2, 0);
        //}
        #endregion
    }

    private void Update()
    {
        if (_onTheGround)
        {
            _extraJump = _extraJumpValue;
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _extraJump > 0)
        {
            _rb.velocity = Vector2.up * _jumpForce;
            _extraJump--;
            _jumping.Play();
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _extraJump == 0 && _onTheGround)
        {
            _rb.velocity = Vector2.up * _jumpForce;
            _jumping.Play();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
