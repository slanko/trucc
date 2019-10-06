using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject focus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = focus.transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1.5f, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1.5f, 0));
        }
    }
}
