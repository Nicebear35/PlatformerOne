using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string OnGround = "OnGround";
    private const string Speed = "Speed";

    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AudioSource _jumpSound;

    private float _direction;
    private bool _onGround;
    private float _checkRadius = 0.5f;

    private void Update()
    {
        _animator.SetBool(OnGround, _onGround);
        _animator.SetFloat(Speed, Mathf.Abs(_direction));
        MovePlayer();
    }

    private void MovePlayer()
    {
        _onGround = CheckGround();
        _direction = Input.GetAxisRaw(Horizontal);

        _spriteRenderer.flipX = _direction < 0 ? true : false;

        transform.Translate(_direction * Time.deltaTime * _speed, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpVelocity;
            _jumpSound.Play();
        }
    }

    private bool CheckGround()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
    }
}
