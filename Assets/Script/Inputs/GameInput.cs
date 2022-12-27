using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    #region Variables
    private GameInputAction _input;

    //GameObject Refrences
    [SerializeField]
    private Player _player;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _input = new GameInputAction();
        _input.Dog.Enable();
        _input.Dog.Movement.performed += Movement_performed;
        _input.Dog.Movement.canceled += Movement_canceled;
    }

    private void Movement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _player.SetMovementAnimation(0f);
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _player.SetMovementAnimation(.85f);
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
