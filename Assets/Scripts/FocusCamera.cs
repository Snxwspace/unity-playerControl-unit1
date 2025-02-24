using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    // game objects to triangulate the angles
    public GameObject focus;
    public GameObject player;
    public float cameraDistance;
    private Vector3 offset = new Vector3(0, 5, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // NOTEPAD
        // can you make a camera a rigidbody to enable collisions with the ground?
        // need to calculate the angle between the player and the focus and move in a distance
            // use a Vector3.back by a certain distance to accomplish that?
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
