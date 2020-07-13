using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallMult = 2.5f;
    [SerializeField] private float _lowJumpMult = 2f;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _hitSound;
    private Rigidbody2D _rb;
    private Animator _anim;
    private bool _playerJumped;
    private bool _playerIsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
	    {
            _playerJumped = true;
		}
    }

	private void FixedUpdate()
	{
		if (_playerJumped)
		{
            if (_playerIsGrounded)
			{
                SoundManager.Instance.PlaySound(_jumpSound);
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _playerIsGrounded = false;
                _anim.SetTrigger("Jump");
                
            }
            _playerJumped = false;
		}

  //      if (_rb.velocity.y < 0)
		//{
  //          _rb.velocity += Vector2.up * Physics2D.gravity.y * (_fallMult - 1) * Time.deltaTime;
		//}
        if (_rb.velocity.y > 0 && !Input.GetButton("Jump"))
		{
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMult - 1) * Time.deltaTime;
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Equals("Ground"))
		{
            _playerIsGrounded = true;
		}

		else
		{
            GameManager.Instance.GameOver();
            SoundManager.Instance.PlaySound(_hitSound);
		}
	}
}
