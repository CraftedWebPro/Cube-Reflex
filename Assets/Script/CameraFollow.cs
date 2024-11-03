using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // The player object to follow
    public Vector3 offset; // The offset distance between the player and the camera
    

    void Update()
    {
        
        // Set the camera position to the smoothed position
        transform.position = player.position + offset;

    }
}
