using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float spawn = 2.0f;
    float delta = 0.0f;

    private void Start()
    {
        
    }
    private void Update()
    {
        delta += Time.deltaTime;
        if(delta > spawn)
        {
            delta = 0.0f;
            GameObject go = Instantiate(arrowPrefab);

            int dropIndex = Random.Range(-2, 3);
            go.GetComponent<ArrowController>().InitArrow(dropIndex);
        }
    }
}
