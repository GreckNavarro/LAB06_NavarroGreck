using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovementController : MonoBehaviour
{

    [SerializeField] Transform ogreTransform;
    [SerializeField] Rigidbody2D ogreRB2D;
    [SerializeField] float velocityModifier;

    private Transform currentTarget;
    private bool isFollowing;
    private bool isMoving;



    private void Start()
    {
        currentTarget = transform;
    }
    private void Update()
    {
        if (isFollowing)
        {
            ogreRB2D.velocity = (currentTarget.position - ogreTransform.position).normalized * velocityModifier;
            CalculateDistance();
        }
        else 
        {
            ogreRB2D.velocity = (currentTarget.position - ogreTransform.position).normalized * velocityModifier;
            CalculateDistance();
        }
    
    }

    private void CalculateDistance()
    {
        if((currentTarget.position - ogreTransform.position).magnitude < 0.15f)
        {
            ogreTransform.position = currentTarget.position;
            isMoving = false;
            ogreRB2D.velocity = Vector2.zero;
        }
        else
        {
            isMoving = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enter Player: " + other.transform.position);
            currentTarget = other.transform;
            isFollowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = false;
            Debug.Log("Exit Player: " + other.transform.position);
            currentTarget = transform;

        }
    }

}
