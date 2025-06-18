using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPhy : MonoBehaviour
{
    private GameObject cat;
    public float ArrowSpeed;

    private void Start()
    {
        cat = GameObject.Find("cat");
    }
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * ArrowSpeed);

        if(cat.transform.position.y >= transform.position.y + 5f)
        {
            Destroy(gameObject);
        }
        //else if()
    }
}
