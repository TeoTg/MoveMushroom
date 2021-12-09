using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Mush speed")]
    private float moveSpeed;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float localTime;
    private float frameTime;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, localTime);
        localTime += Time.deltaTime * frameTime;
    }

    public void SetMovePoint(Transform newMovePosition)
    {
        transform.SetParent(newMovePosition);
        endPosition = newMovePosition.position;
        startPosition = transform.position;

        transform.rotation = Quaternion.Euler(Vector3.up * moveDuration(endPosition));
        
        frameTime = 1 / (endPosition.magnitude / moveSpeed);
        localTime = 0;
    }

    private float moveDuration(Vector3 endPosition)
    {
        Vector3 forward = transform.forward;
        float currentCos = Vector3.Dot(endPosition, forward) / (endPosition.magnitude * forward.magnitude);
        
        return Mathf.Acos(currentCos) * 180 / Mathf.PI;
    }
}
