using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private float _speed;

    private Vector2 _movement;
    private bool _playerGrounded;

    private CharacterController _controller;
    private Animator _anim;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
        {
            Debug.LogError("No Character Controller Present");
        }

        _anim = GetComponent<Animator>();
        if (_controller == null)
        {
            Debug.LogError("Failed to connect the Animator");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    #region Movement

    public void SetMovement(Vector2 move)
    {
        _movement = move;
    }

    private void Movement()
    {
        _playerGrounded = _controller.isGrounded;
        float h = _movement.x;
        float v = _movement.y;

        transform.Rotate(transform.up, h);

        Vector3 direction = transform.forward * v;
        Vector3 velocity = direction * _speed;

        _anim.SetFloat("Speed", Mathf.Abs(velocity.magnitude));

        if (_playerGrounded)
        {
            velocity.y = 0f;
        }
        if (!_playerGrounded)
        {
            velocity.y += -20f * Time.deltaTime;
        }

        _controller.Move(velocity * Time.deltaTime);
    }
    #endregion
}
