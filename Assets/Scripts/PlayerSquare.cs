using UnityEngine;

public class PlayerSquare : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float _movementSpeed = 2f;
    [SerializeField] private float _jumpForce = 6f;

    private bool _moveLeft = false;
    private bool _moveRight = false;
    private bool _jump = false;
    private bool _isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _jump = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !_isJumping;
        _moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        _moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = 0f;

        if (_moveRight)
            horizontalVelocity = _movementSpeed;
        else if (_moveLeft)
            horizontalVelocity = -_movementSpeed;

        rb.linearVelocity = new Vector2(horizontalVelocity, rb.linearVelocity.y);

        if (_jump)
        {
            rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _jump = false;
            _isJumping = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
