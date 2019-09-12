using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    public Transform carToFollow;
    public float travelTime = 10f;
    public float lookSpeed = 10f;

    private void MoveCamera()
    {
        Vector3 _targetPos = new Vector3(carToFollow.position.x + offset.x,carToFollow.position.y + offset.y, carToFollow.position.z + offset.z);

        transform.position = Vector3.Lerp(transform.position, _targetPos, travelTime * Time.deltaTime);
    }

    public void LookAtTarget()
    {
        Vector3 _lookDirection = carToFollow.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCamera();
        LookAtTarget();
    }
}
