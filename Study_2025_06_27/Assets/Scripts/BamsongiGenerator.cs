using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab);
            //bamsongi.GetComponent<bamsongiController>().Shoot(new Vector3(0, 200, 2000));

            bamsongi.transform.position =
                Camera.main.transform.position + Camera.main.transform.forward * 1.0f;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 5000);
        }
        //if (Input.GetMouseButton(1))
        //{
        //    GameObject bamsongi = Instantiate(bamsongiPrefab);
        //    //bamsongi.GetComponent<bamsongiController>().Shoot(new Vector3(0, 200, 2000));

        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Vector3 worldDir = ray.direction;
        //    bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 20000);
        //}
    }
    
}
