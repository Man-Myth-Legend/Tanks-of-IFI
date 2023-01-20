using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    bool activeTank = true;

    public float movementSpeed;
    public float rotateSpeed;

    public GameObject barrel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTank)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(0, 0, -movementSpeed));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(0, 0, movementSpeed));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                barrel.transform.Rotate(new Vector3(rotateSpeed, 0, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                barrel.transform.Rotate(new Vector3(-rotateSpeed, 0, 0));
            }
        }
    }
}
