using UnityEngine;

public class TankMove : MonoBehaviour
{
    private float speed = 15.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // go
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
