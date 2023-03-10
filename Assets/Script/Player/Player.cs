using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _bonesCollected;

    private Vector2 _movement;
    private bool _playerGrounded;

    private CharacterController _controller;
    private Animator _anim;
    private float _animSpeed;
    private UIManager _uiManager;
    private GameManager _gameManager;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError(gameObject.name + " Failed to Connect to GameManager");
        }

        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError(gameObject.name + " Failed to connect to UIManager");
        }

        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError(gameObject.name + " Failed to connect the Animator");
        }

        _controller = GetComponent<CharacterController>();
        if (_controller == null)
        {
            Debug.LogError(gameObject.name + " No Character Controller Present");
        }

        _animSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        UICommunication();
    }

    #region Script Communication
    private void UICommunication()
    {
        AddBone();
    }


    #endregion

    #region Movement

    public void SetMovement(Vector2 move)
    {
        _movement = move;
    }
    public void SetMovementAnimation(float animSpeed)
    {
        _animSpeed = animSpeed;
    }

    private void Movement()
    {
        _playerGrounded = _controller.isGrounded;
        float h = _movement.x;
        float v = _movement.y;

        transform.Rotate(transform.up, h);


        Vector3 direction = transform.forward * v;
        Vector3 velocity = direction * _speed;

        _anim.SetFloat("Speed_f", _animSpeed);

        if (_playerGrounded)
        {
            velocity.y = 0f;
        }
        if (!_playerGrounded)
        {
            velocity.y += -2000f * Time.deltaTime;
        }

        _controller.Move(velocity * Time.deltaTime);
    }
    #endregion

    #region Bones

    public void CollectedBone(int boneValue)
    {
        _bonesCollected += boneValue;
    }
    private void AddBone()
    {
        _uiManager.UpdateCollectedBones(_bonesCollected);
        _gameManager.UpdateCollectedBones(_bonesCollected);
    }



    #endregion
}
