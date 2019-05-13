using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quadromino : MonoBehaviour
{
    CameraSwap cam;
    Button yRotUp, yRotDown, xzRotUp, xzRotDown;
    Button DR, UR, DL, UL;

    float fall = 0;
    public float fallSpeed = 1;
    bool frozen = false;
    Vector3 last_move = new Vector3(0, 0, 0);
    bool isRotation = false;


    // Start is called before the first frame update
    void Start()
    {
        UL = GameObject.Find("MoveUL").GetComponent<Button>();
        UR = GameObject.Find("MoveUR").GetComponent<Button>();
        DL = GameObject.Find("MoveDL").GetComponent<Button>();
        DR = GameObject.Find("MoveDR").GetComponent<Button>();

        yRotUp = GameObject.Find("RotateUR").GetComponent<Button>();
        yRotDown = GameObject.Find("RotateDL").GetComponent<Button>();
        xzRotUp = GameObject.Find("RotateUL").GetComponent<Button>();
        xzRotDown = GameObject.Find("RotateDR").GetComponent<Button>();

        cam = GameObject.Find("CameraSwap").GetComponent<CameraSwap>();

        yRotUp.onClick.AddListener(yRotateUp);
        yRotDown.onClick.AddListener(yRotateDown);
        xzRotUp.onClick.AddListener(xzRotateUp);
        xzRotDown.onClick.AddListener(xzRotateDown);
        UL.onClick.AddListener(moveUL);
        DR.onClick.AddListener(moveDR);
        UR.onClick.AddListener(moveUR);
        DL.onClick.AddListener(moveDL);
    }

    public void yRotateUp()
    {
        if (frozen)
        {
            return;
        }

        Vector3 rotation = new Vector3(0, -90, 0);
        updateLastAction(rotation, true);
        transform.Rotate(rotation, Space.World);
    }

    public void yRotateDown()
    {
        if (frozen)
        {
            return;
        }
        Vector3 rotation = new Vector3(0, 90, 0);
        updateLastAction(rotation, true);
        transform.Rotate(rotation, Space.World);
    }

    public void xzRotateUp()
    {
        if (frozen)
        {
            return;
        }
        int camera = cam.getCamera();
        Vector3 rotation = new Vector3(0,0,0);
        switch (camera)
        {
            case 0: rotation = new Vector3(90,0,0); break;
            case 1: rotation = new Vector3(0, 0, 90); break;
            case 2: rotation = new Vector3(-90, 0, 0); break;
            case 3: rotation = new Vector3(0, 0, -90); break;
        }
        updateLastAction(rotation, true);
        transform.Rotate(rotation, Space.World);
        
    }

    public void xzRotateDown()
    {
        if (frozen)
        {
            return;
        }
        int camera = cam.getCamera();
        Vector3 rotation = new Vector3(0, 0, 0);
        switch (camera)
        {
            case 0: rotation = new Vector3(-90, 0, 0); break;
            case 1: rotation = new Vector3(0, 0, -90); break;
            case 2: rotation = new Vector3(90, 0, 0); break;
            case 3: rotation = new Vector3(0, 0, 90); break;
        }
        updateLastAction(rotation, true);
        transform.Rotate(rotation, Space.World);
    }

    public void moveUL()
    {
        if (frozen)
        {
            return;
        }
        int camera = cam.getCamera();
        Vector3 movement = new Vector3(0, 0, 0);
        switch (camera)
        {
            case 0: movement = new Vector3(0, 0, 1); break;
            case 1: movement = new Vector3(-1, 0, 0); break;
            case 2: movement = new Vector3(0, 0, -1); break;
            case 3: movement = new Vector3(1, 0, 0); break;
        }
        updateLastAction(movement, false);
        transform.position += movement;
    }

    public void moveUR()
    {
        if (frozen)
        {
            return;
        }
        int camera = cam.getCamera();
        Vector3 movement = new Vector3(0, 0, 0);
        switch (camera)
        {
            case 0: movement = new Vector3(1, 0, 0); break;
            case 1: movement = new Vector3(0, 0, 1); break;
            case 2: movement = new Vector3(-1, 0, 0); break;
            case 3: movement = new Vector3(0, 0, -1); break;
        }
        updateLastAction(movement, false);
        transform.position += movement;
    }

    public void moveDL()
    {
        if (frozen)
        {
            return;
        }
        int camera = cam.getCamera();
        Vector3 movement = new Vector3(0, 0, 0);
        switch (camera)
        {
            case 0: movement = new Vector3(-1, 0, 0); break;
            case 1: movement = new Vector3(0, 0, -1); break;
            case 2: movement = new Vector3(1, 0, 0); break;
            case 3: movement = new Vector3(0, 0, 1); break;
        }
        updateLastAction(movement, false);
        transform.position += movement;
    }

    public void moveDR()
    {
        if (frozen)
        {
            return;
        }
        int camera = cam.getCamera();
        Vector3 movement = new Vector3(0, 0, 0);
        switch (camera)
        {
            case 0: movement = new Vector3(0, 0, -1); break;
            case 1: movement = new Vector3(1, 0, 0); break;
            case 2: movement = new Vector3(0, 0, 1); break;
            case 3: movement = new Vector3(-1, 0, 0); break;
        }
        updateLastAction(movement, false);
        transform.position += movement;
    }

    void updateLastAction(Vector3 movement, bool rot)
    {
        last_move = movement;
        isRotation = rot;
    }

    void undoAction()
    {
        Vector3 undo = new Vector3(-last_move.x, -last_move.y, -last_move.z);
        if (isRotation)
        {
            transform.Rotate(undo, Space.World);
        }
        else
        {
            transform.position += undo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!frozen && Time.time-fall >= fallSpeed)
        {
            Vector3 movement = new Vector3(0, -1, 0);
            transform.position += movement;
            fall = Time.time;
        }

    }

    void OnTriggerExit(Collider col)
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Floor")
        {
            transform.position += new Vector3(0, 1, 0);
            frozen = true;
        }
        else if (col.gameObject.name == "Bound")
        {
            undoAction();
        }
    }
}
