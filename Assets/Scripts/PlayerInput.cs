using UnityEngine;
using UnityEngine.InputSystem;
using KBCore.Refs;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    private InputAction move;
    private InputAction look;
    private float camRotation;
    private Vector3 velocity;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float gravity = -5.0f;
    [SerializeField] private float rotationSpeed = 4.0f;
    [SerializeField] private float mouseSens = 5.0f;
    [SerializeField, Self] private CharacterController controller;
    [SerializeField, Child] private Camera cam;
    private void OnValidate() {this.ValidateRefs();}
    void Start()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        look = InputSystem.actions.FindAction("Player/Look");
        // controller = GetComponent<CharacterController>();
        // if (controller == null)
            // controller = gameObject.AddComponent<CharacterController>();
        //adds a CharacterController component if one does not already exist when the game starts
        //not effective if you have multiple scripts trying to add the component at once
        //not needed with Self attribute and ValidateRefs method
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 readMove = move.ReadValue<Vector2>();
        Vector2 readLook = look.ReadValue<Vector2>();
        Vector3 movement = transform.right * readMove.x
        + transform.forward * readMove.y;

        //controller.Move(movement * maxSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
        movement *= maxSpeed * Time.deltaTime;
        movement += velocity;
        controller.Move(movement);

        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * Time.deltaTime);
        
        mouseSens *= readLook.y;
        mouseSens = Mathf.Clamp(mouseSens, -90f, 90f);
        cam.gameObject.transform.localRotation = Quaternion.Euler(mouseSens, 0, 0);
        //*-1 also works (but need a += instead of -=)
        camRotation -= mouseSens * readLook.y * Time.deltaTime;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f); //values can be smaller
        cam.gameObject.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);
        //directional light = sun (entire scene)
        //point light = lamp (circle)
        //spot light = flashlight (cone)
        //area light = tv (rectangle) baked only
        //bake the light calculation in the scene prior to see its effect
        //realtime lights are more performance heavy but work with dynamic objects
        //the higher the intensity value te more it bounces off other surfaces
    }
}