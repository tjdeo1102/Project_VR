using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Vector3 targetRotation;
    [SerializeField] float rotationSpeed;
    bool isOpenDoor;
    Quaternion startRotation;
    private void Start()
    {
        startRotation = transform.rotation;
    }
    private void Update()
    {
        if (isOpenDoor)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed * Time.deltaTime);
        else
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startRotation, rotationSpeed * Time.deltaTime);
    }
    public void DoorToggle()
    {
        isOpenDoor ^= true;
    }
}
