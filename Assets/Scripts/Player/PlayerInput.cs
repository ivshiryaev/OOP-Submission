using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }
    public float horizontalInput { get; private set; }
    public float verticalInput { get; private set; }
<<<<<<< Updated upstream:Assets/Scripts/PlayerInput.cs
    public bool isJumpButtonPressed { get; private set; }
=======

    [field: SerializeField]
    public KeyCode jumpButton { get; private set; }
    [field: SerializeField]
    public KeyCode restartButton { get; private set; }

    [field: SerializeField]
    public KeyCode stopGameButton { get; private set; }
    [field: SerializeField]
    public KeyCode abilityButton { get; private set; }

>>>>>>> Stashed changes:Assets/Scripts/Player/PlayerInput.cs

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        isJumpButtonPressed = Input.GetKeyDown(KeyCode.Space);
    }
}
