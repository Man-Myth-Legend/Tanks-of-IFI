using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    bool activeTank = true;

    public float movementSpeed;
    public float rotateSpeed;

    public int rotateBarrelThreshold;
    private int barrelHeading;
    private float tempBarrelHeading;

    public GameObject barrel;
    private UI ui;
    // Start is called before the first frame update
    void Start()
    {
        barrelHeading = (int) barrel.transform.rotation.eulerAngles.x;
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTank)
        {
            Move();
            Rotate();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(0, 0, -movementSpeed));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0, 0, movementSpeed));
        }
    }
    void Rotate()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tempBarrelHeading -= 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tempBarrelHeading += 1;
        }
        if (tempBarrelHeading == rotateBarrelThreshold || tempBarrelHeading == -rotateBarrelThreshold)
        {
            if (tempBarrelHeading == rotateBarrelThreshold) {
                barrel.transform.eulerAngles = new Vector3((int)barrel.transform.eulerAngles.x + 1, 0, 0);
                barrel.transform.Rotate(new Vector3(1, 0, 0));
                tempBarrelHeading = 0;
            }
            else
            {
                barrel.transform.eulerAngles = new Vector3((int)barrel.transform.eulerAngles.x - 1, 0, 0);
                tempBarrelHeading = 0;
            }
           ui.UpdateAngle((int)barrel.transform.eulerAngles.x);
        }
    }
}
