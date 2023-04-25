using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRBD2;
    [SerializeField] float velocitymultiplier;
    public void SetUpVelocity(Vector2 velocity)
    {
       myRBD2.velocity = velocity * velocitymultiplier;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")|| other.CompareTag("Enemy"))
        {
            Debug.Log(other.gameObject);
        }
    }
}
