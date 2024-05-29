using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform target; // The ball or object you want to follow and orbit around
    public float rotationSpeed = 5f;
    public float followSpeed = 5f;
    public float distance = 5f; // Distance between the camera and the target
    void Update()
    {
        // Check for user input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Rotate the camera around the target based on user input
        RotateCamera(horizontalInput);

        // Follow the target's position
        FollowTarget();
    }
    void RotateCamera(float horizontalInput)
    {
        // Check if the target is null before rotating the camera
        if (target == null)
        {
            return;
        }

        // Calculate the rotation angle based on input
        float rotationAngle = horizontalInput * rotationSpeed * Time.deltaTime;

        // Rotate the camera around the target
        transform.RotateAround(target.position, Vector3.up, rotationAngle);
    }
    void FollowTarget()
    {
        // Check if the target is null before following it
        if (target == null)
        {
            return;
        }

        // Calculate the target position with an offset
        Vector3 targetPosition = target.position - transform.forward * distance;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}








