using UnityEngine;

public class PlayerFollowCam : MonoBehaviour
{
    public Transform mainCameraTransform; // Reference to the Main Camera

    void Update()
    {
        // Ensure the player's position and rotation match the camera's position and rotation
        transform.position = mainCameraTransform.position;
        transform.rotation = mainCameraTransform.rotation;
    }
}



