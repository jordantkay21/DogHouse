using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    #region Variables
    private GameInputAction _input;
    private Animator _anim;

    //GameObject Refrences
    [SerializeField]
    private Player _player;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Failed to connect to Animator");
        }
        _input = new GameInputAction();
        _input.Dog.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Controls
        PlayerInputs();
    }

    private void PlayerInputs()
    {
        Vector2 move = _input.Dog.Movement.ReadValue<Vector2>();
        _player.SetMovement(move);
    }
}
