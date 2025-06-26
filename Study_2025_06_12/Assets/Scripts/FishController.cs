using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("cat");
    }

    private void Update()
    {
        if (transform.position.y < player.transform.position.y - 10.0f)
            Destroy(gameObject);
    }
}
