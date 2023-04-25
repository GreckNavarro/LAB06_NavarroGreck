using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [Header("Vector3 Positions")]
    [SerializeField] Vector3 mousePosition;
    [SerializeField] Vector3 mousePositionCamera;
    [SerializeField] Vector3 mousePositionCameraNormalized;
    [SerializeField] Vector3 mousePositionPlayer;

    [Header("Targets")]
    [SerializeField] Transform mouseTarget;
    [SerializeField] Transform mouseTargetCamera;
    [SerializeField] Transform mouseTargetCameraNormalized;
    [SerializeField] Transform mouseTargetPlayer;

    float rayDistance = 5f;
    private void Update()
    {
        mousePosition = Input.mousePosition;
        mouseTarget.position = mousePosition;
        Debug.DrawLine(transform.position, mousePosition * rayDistance, Color.gray);

        mousePositionCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseTargetCamera.position = mousePositionCamera;
        Debug.DrawLine(transform.position, mousePositionCamera * rayDistance, Color.green);

        mousePositionCameraNormalized = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;
        mouseTargetCameraNormalized.position = mousePositionCameraNormalized;
        Debug.DrawLine(transform.position, mousePositionCameraNormalized * rayDistance, Color.yellow);

        Vector3 distance = mousePositionCamera - transform.position;
        mousePositionPlayer = distance;
        mouseTargetPlayer.position = mousePositionPlayer;
        Debug.DrawLine(transform.position, mousePositionPlayer * rayDistance, Color.red);
    }
} 
