using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quadromino : MonoBehaviour
{
    public Button yRotUp, yRotDown;
    public Button xzRotUp, xzRotDown;
    public CameraSwap cam;


    // Start is called before the first frame update
    void Start()
    {
        yRotUp.onClick.AddListener(yRotateUp);
        yRotDown.onClick.AddListener(yRotateDown);
        xzRotUp.onClick.AddListener(xzRotateUp);
        xzRotDown.onClick.AddListener(xzRotateDown);
    }

    void yRotateUp()
    {
        transform.position += new Vector3(1, 0, 0);
        //transform.Rotate(0, 90, 0);
    }

    void yRotateDown()
    {
        transform.Rotate(0, -90, 0);
    }

    void xzRotateUp()
    {
        int camera = cam.getCamera();
        if(camera == 0)
        {
            transform.Rotate(0, 0, 90);
        }
        else
        {
            transform.Rotate(90, 0, 0);
        }
    }

    void xzRotateDown()
    {
        int camera = cam.getCamera();
        if (camera == 0)
        {
            transform.Rotate(0, 0, -90);
        }
        else
        {
            transform.Rotate(-90, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
