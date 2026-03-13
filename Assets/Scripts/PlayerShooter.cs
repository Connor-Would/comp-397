using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    private InputAction fire;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private float force = 0f;
    private void OnEnable() => fire.started += ShootPooled;
    private void OnDisable() => fire.started -= ShootPooled;
    private void Awake()
    {
        fire = InputSystem.actions.FindAction("Player/Attack");
    }
    private void Shoot(InputAction.CallbackContext context)
    {
        GameObject projectile = GameObject.Instantiate(bullet, projectileSpawn.position, projectileSpawn.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * force, ForceMode.Impulse);
        Destroy(projectile, 1.5f);
    }
    private void ShootPooled(InputAction.CallbackContext context)
    {
        Bullet bullet = BulletObjectPool.Instance.Get();
        bullet.transform.SetPositionAndRotation(projectileSpawn.position, projectileSpawn.rotation);
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * force, ForceMode.Impulse);
    }
}
