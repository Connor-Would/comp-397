using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    private InputAction fire;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private float force = 0f;
    
    private void Awake()
    {
        fire = InputSystem.actions.FindAction("Player/Attack");
        
    }
    private void OnEnable()
    {
        fire.started += Shoot;
    }
    private void OnDisable()
    {
        fire.started -= Shoot;
    }
    private void Shoot(InputAction.CallbackContext context)
    {
        //Debug.Log("Start" + context.started);
        //Debug.Log("Perform" + context.performed);
        //Debug.Log("Context" + context.canceled);
        GameObject projectile = GameObject.Instantiate(bullet, projectileSpawn.position, projectileSpawn.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * force, ForceMode.Impulse);
        //Destroy(projectile, 1.5f); //destroys the projectile after 1.5 seconds to prevent cluttering the scene with unused objects
    }
}
