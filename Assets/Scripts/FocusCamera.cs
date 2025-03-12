using Unity.Mathematics;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    // game objects to triangulate the angles
    public GameObject focus;
    public GameObject player;
    public float cameraDistance = 5.0f;
    private Vector3 offset = new Vector3(0, 5, 0);

    public float xDiff;
    public float yDiff;
    public float zDiff;
    public float xAngle;
    public float yAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // NOTEPAD
        // can you make a camera a rigidbody to enable collisions with the ground?
        // need to calculate the angle between the player and the focus and move in a distance
            // use a Vector3.back by a certain distance to accomplish that?
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = new quaternion(0, 0, 0, 0);

        // calculate position differences
        xDiff = focus.transform.position.x - transform.position.x;
        yDiff = focus.transform.position.y - transform.position.y;
        zDiff = focus.transform.position.z - transform.position.z;

        // fix that bizzare camera flipping bug
        int flip = 0;
        if(math.sign(zDiff) == -1) {
            flip = 180;
        }

        // calculate angles
        yAngle = math.atan(xDiff/zDiff);
        xAngle = math.atan(yDiff/math.cos(yAngle)); // feeding bad info
        transform.Rotate(new Vector3(xAngle, RadiansToDegrees(yAngle) - flip));
        transform.Translate(Vector3.back * cameraDistance);
    }

    float RadiansToDegrees(float rad)
    {
        float deg = rad;
        deg *= 180;
        deg /= math.PI;
        return deg;
    }

}
