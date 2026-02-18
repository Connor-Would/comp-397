using System.ComponentModel;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Bullet collided with " + other.gameObject.name, other.gameObject);
        if (other.gameObject.CompareTag("Enemy")){
            Destroy(gameObject); Destroy(other.gameObject);
        }//why does ,other.gameObject not work?
    }
}
