using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cityScript : MonoBehaviour
{
    public GameObject[] adjacentCities;
    Text cityNameTag;
    public GameObject mainCamera, nameTag;

    // Start is called before the first frame update
    void Start()
    {
        cityNameTag = GameObject.Find(transform.name + "/Canvas/NameText").GetComponent<Text>();
        nameTag = GameObject.Find(transform.name + "/Canvas/NameText");
        cityNameTag.text = transform.name;
        mainCamera = GameObject.Find("CameraOffset/Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        nameTag.transform.LookAt(mainCamera.transform.position);
    }
}
