using UnityEngine;
using UnityEngine.InputSystem;
using KBCore.Refs;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    private InputAction move;
    private InputAction look;
    private InputAction jump;
    private float camRotation;
    private Vector3 velocity;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float gravity = -0.01f;
    [SerializeField] private float rotationSpeed = 4.0f;
    [SerializeField] private float mouseSens = 5.0f;
    [SerializeField, Self] private CharacterController controller;
    [SerializeField, Child] private Camera cam;
    private void OnValidate() => this.ValidateRefs();
    private void OnDisable() => jump.started -= Jump;
    void Start()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        look = InputSystem.actions.FindAction("Player/Look");
        jump = InputSystem.actions.FindAction("Player/Jump");
        jump.started += Jump;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        Vector2 readMove = move.ReadValue<Vector2>();
        Vector2 readLook = look.ReadValue<Vector2>();
        Vector3 movement = transform.right * readMove.x
        + transform.forward * readMove.y;

        velocity.y += gravity * Time.deltaTime;
        movement *= maxSpeed * Time.deltaTime;
        movement += velocity;
        controller.Move(movement);

        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * Time.deltaTime);
        
        camRotation -= mouseSens * readLook.y * Time.deltaTime;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        cam.gameObject.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);
    }
    public void ChangeMouseSens(float m)
    {
        mouseSens = m; rotationSpeed = m;
    }
    private void Jump(InputAction.CallbackContext context)
    {
        AudioController.Instance.PlayJumpSFX();
    }
}