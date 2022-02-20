using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }
    public float horizontalInput { get; private set; }
    public float verticalInput { get; private set; }
    public bool isJumpButtonPressed { get; private set; }

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
