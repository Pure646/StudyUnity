using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    private GameObject cat;
    private CinemachineVirtualCamera Camera;
    private bool OnLook = false;
    private void Start()
    {
        cat = GameObject.Find("cat");
        Camera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if(cat.transform.position.y >= 0 && OnLook == false)
        {
            Camera.Follow = cat.transform;
            Camera.LookAt = cat.transform;
            OnLook = true;
        }
    }
}
