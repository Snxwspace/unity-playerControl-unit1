using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject active;
    public GameObject alternate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) {
            alternate.SetActive(true);
            active.SetActive(false);
        }
    }
}
