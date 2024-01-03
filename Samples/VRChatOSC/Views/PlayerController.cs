#nullable enable

using OSCReceiver.VRChatOSC;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAxisControllerEvent inputAxisControllerEvent = default!;
    [SerializeField] private InputButtonControllerEvent inputButtonControllerEvent = default!;
    [SerializeField] private CharacterController characterController = default!;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 180f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float runningSpeedMultiplier = 1.5f;

    private float vertical = 0;
    private float horizontal = 0;
    private float lookHorizontal = 0;

    private float verticalSpeed;

    private bool isRunning = false;
    private bool isGrounded;

    private void Update()
    {
        HandleRotationInput();
        HandleGravity();
        HandleMovementInput();
    }

    private void HandleRotationInput()
    {
        characterController.transform.Rotate(Vector3.up * lookHorizontal * rotationSpeed * Time.deltaTime);
    }

    private void HandleGravity()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed += Physics.gravity.y * Time.deltaTime;
            characterController.Move(Vector3.up * verticalSpeed * Time.deltaTime);
        }
    }

    private void HandleMovementInput()
    {
        var localMoveVector = new Vector3(horizontal, 0f, vertical);

        if (localMoveVector.magnitude >= 0.1f)
        {
            var moveVector = characterController.transform.TransformVector(localMoveVector);

            var speed = moveSpeed;
            if (isRunning)
            {
                speed *= runningSpeedMultiplier;
            }

            characterController.Move(moveVector * speed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        inputAxisControllerEvent.Vertical += InputVertical;
        inputAxisControllerEvent.Horizontal += InputHorizontal;
        inputAxisControllerEvent.LookHorizontal += InputLookHorizontal;

        inputButtonControllerEvent.MoveForward += InputMoveForward;
        inputButtonControllerEvent.MoveBackward += InputMoveBackward;
        inputButtonControllerEvent.MoveLeft += InputMoveLeft;
        inputButtonControllerEvent.MoveRight += InputMoveRight;
        inputButtonControllerEvent.LookLeft += InputLookLeft;
        inputButtonControllerEvent.LookRight += InputLookRight;
        inputButtonControllerEvent.Jump += Jump;
        inputButtonControllerEvent.Run += InputRun;
    }

    private void OnDisable()
    {
        inputAxisControllerEvent.Vertical -= InputVertical;
        inputAxisControllerEvent.Horizontal -= InputHorizontal;
        inputAxisControllerEvent.LookHorizontal -= InputLookHorizontal;

        inputButtonControllerEvent.MoveForward -= InputMoveForward;
        inputButtonControllerEvent.MoveBackward -= InputMoveBackward;
        inputButtonControllerEvent.MoveLeft -= InputMoveLeft;
        inputButtonControllerEvent.MoveRight -= InputMoveRight;
        inputButtonControllerEvent.LookLeft -= InputLookLeft;
        inputButtonControllerEvent.LookRight -= InputLookRight;
        inputButtonControllerEvent.Jump -= Jump;
        inputButtonControllerEvent.Run -= InputRun;
    }


    private void InputVertical(float value) => vertical = value;
    private void InputHorizontal(float value) => horizontal = value;
    private void InputLookHorizontal(float value) => lookHorizontal = value;

    private void InputMoveForward(bool isOn) => vertical = isOn switch{ true => 1, _ => 0 };
    private void InputMoveBackward(bool isOn) => vertical = isOn switch { true => -1, _ => 0 };
    private void InputMoveLeft(bool isOn) => horizontal = isOn switch { true => -1, _ => 0 };
    private void InputMoveRight(bool isOn) => horizontal = isOn switch { true => 1, _ => 0 };
    private void InputLookLeft(bool isOn) => lookHorizontal = isOn switch { true => -1, _ => 0 };
    private void InputLookRight(bool isOn) => lookHorizontal = isOn switch { true => 1, _ => 0 };
    private void InputRun(bool isOn) => isRunning = isOn;

    void Jump(bool isOn)
    {
        if (!isOn)
        {
            return;
        }

        isGrounded = characterController.isGrounded;
        if (isGrounded)
        {
            verticalSpeed = Mathf.Sqrt(2f * jumpForce * Mathf.Abs(Physics.gravity.y));
            characterController.Move(Vector3.up * verticalSpeed * Time.deltaTime);
        }
    }
}
