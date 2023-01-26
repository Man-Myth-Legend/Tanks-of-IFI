using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    bool activeTank = true;

    public float movementSpeed;
    public float rotateSpeed;
    public float projectileForce;

    public int rotateBarrelThreshold;
    private float tempBarrelHeading;
    

    public GameObject barrel;
    public GameObject barrelStart;
    public GameObject barrelEnd;

    public GameObject projectile;

    private UI ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTank)
        {
            Move();
            Rotate();
            Shoot();
        }
    }

    void Shoot()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float rad = (int)barrel.transform.localEulerAngles.x * Mathf.Deg2Rad;
            double sin = Math.Sin(rad);
            double cos = Math.Cos(rad);
            float sinNorm = (float)Math.Round(sin / (sin + cos), 3);
            float cosNorm = (float)Math.Round(cos / (sin + cos), 3);
            GameObject shot = Instantiate(projectile, barrelEnd.transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody>().AddForce(new Vector3(0, sinNorm, cosNorm) * projectileForce);
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
            tempBarrelHeading += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tempBarrelHeading -= 1;
        }
        if (tempBarrelHeading == rotateBarrelThreshold || tempBarrelHeading == -rotateBarrelThreshold)
        {
            if (tempBarrelHeading == rotateBarrelThreshold && barrel.transform.localEulerAngles.y == 0 && barrel.transform.localEulerAngles.x != 90)
            {
                barrel.transform.Rotate(new Vector3(1, 0, 0));
            }
            else if (tempBarrelHeading == -rotateBarrelThreshold && barrel.transform.localEulerAngles.x < 180 && barrel.transform.localEulerAngles.x != 0)
            {
                barrel.transform.Rotate(new Vector3(-1, 0, 0));
            }
            barrel.transform.localEulerAngles = new Vector3((float)Math.Round((double)barrel.transform.localEulerAngles.x), 0, 0); //Round the angle
            tempBarrelHeading = 0;
            ui.UpdateAngle((int)barrel.transform.localEulerAngles.x);
        }
    }
}
