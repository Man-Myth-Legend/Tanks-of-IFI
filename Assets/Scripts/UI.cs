using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{


    public GameObject angleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAngle(int angle)
    {
        angleText.GetComponent<TextMeshProUGUI>().text = "Angle: " + angle;
    }
}
