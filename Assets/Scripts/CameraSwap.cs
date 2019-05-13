using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera0;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    AudioListener camera0Audio;
    AudioListener camera1Audio;
    AudioListener camera2Audio;
    AudioListener camera3Audio;

    public Button right;
    public Button left;

    int camera;
    void Start()
    {
        camera0Audio = camera0.GetComponent<AudioListener>();
        camera1Audio = camera1.GetComponent<AudioListener>();
        camera2Audio = camera2.GetComponent<AudioListener>();
        camera3Audio = camera3.GetComponent<AudioListener>();

        right.onClick.AddListener(incrementCamera);
        left.onClick.AddListener(decrementCamera);

        camera = 0;
        changeView(camera);
    }

    public int getCamera()
    {
        return camera;
    }

    // Update is called once per frame
    void Update()
    {

            
    }

    void incrementCamera()
    {
        camera += 1;
        if (camera > 3)
            camera = 0;
        changeView(camera);
    }

    void decrementCamera()
    {
        camera -= 1;
        if (camera < 0)
            camera = 3;
        changeView(camera);
    }

    void changeView(int camera)
    {
        switch (camera)
        {
            case 0:
                camera0.SetActive(true);
                camera0Audio.enabled = true;
                camera1Audio.enabled = false;
                camera1.SetActive(false);
                camera2Audio.enabled = false;
                camera2.SetActive(false);
                camera3.SetActive(false);
                camera3Audio.enabled = false;
                break;
            case 1:
                camera1.SetActive(true);
                camera1Audio.enabled = true;
                camera0Audio.enabled = false;
                camera0.SetActive(false);
                camera2Audio.enabled = false;
                camera2.SetActive(false);
                camera3.SetActive(false);
                camera3Audio.enabled = false;
                break;
            case 2:
                camera2.SetActive(true);
                camera2Audio.enabled = true;
                camera1Audio.enabled = false;
                camera1.SetActive(false);
                camera0Audio.enabled = false;
                camera0.SetActive(false);
                camera3.SetActive(false);
                camera3Audio.enabled = false;
                break;
            case 3:
                camera3.SetActive(true);
                camera3Audio.enabled = true;
                camera1Audio.enabled = false;
                camera1.SetActive(false);
                camera2Audio.enabled = false;
                camera2.SetActive(false);
                camera0.SetActive(false);
                camera0Audio.enabled = false;
                break;
        }
    }
}
