using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public List<GameObject> cameraPosition = new List<GameObject>();
    public ThirdPersonController controller;
    public bool canMoveWithCloseCam;
    
    int activeCam;

    // Start is called before the first frame update
    void Start()
    {
        activeCam = 1;
        setCam(activeCam - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(SwitchCam()) setCam(activeCam - 1);
    }

    private bool SwitchCam()
    {
        int temp = activeCam;

        if (Input.GetKeyDown("1")) activeCam = 1;
        if (Input.GetKeyDown("2")) activeCam = 2;
        if (Input.GetKeyDown("3")) activeCam = 3;
        if (Input.GetKeyDown("4")) activeCam = 4;
        if (Input.GetKeyDown("5")) activeCam = 5;

        return activeCam != temp;
    }
    
    public void setCam(int idx)
    {
        for (int i = 0; i < cameraPosition.Count; i++)
        {
            if (i == idx)
            {
                cameraPosition[i].SetActive(true);
            }
            else
            {
                cameraPosition[i].SetActive(false);
            }
        }

        if (controller != null)
        {
            controller.enabled = (idx < 2 || canMoveWithCloseCam);
        }
    }



}
