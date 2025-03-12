using Unity.Mathematics;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    // game objects to triangulate the angles
    public GameObject focus;
    public GameObject player;
    private float cameraDistance = 10.0f;
    private float offset = 6.0f;

    private float xDiff;
    private float yDiff;
    private float zDiff;
    private float xAngle;
    private float yAngle;

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
        transform.position = player.transform.position + new Vector3(0, offset, 0);
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
        yAngle = math.atan(xDiff/zDiff); // good info
        xAngle = -math.abs(zDiff)/math.cos(yAngle); // feeding bad info
        xAngle = math.atan(yDiff/xAngle);
        transform.Rotate(new Vector3(RadiansToDegrees(xAngle), RadiansToDegrees(yAngle) - flip));
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
