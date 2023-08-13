using UnityEngine;

public class SmoothRotation : MonoBehaviour
{

    public float rotateSpeed = 50.0f;

    void Update()
    {
        // Calculate the desired rotation as a Quaternion
        Quaternion rotation = Quaternion.Euler(0,rotateSpeed * Time.deltaTime, 0);

        // Apply the rotation to the GameObject
        transform.rotation *= rotation;
    }
}
