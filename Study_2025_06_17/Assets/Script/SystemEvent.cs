using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemEvent : MonoBehaviour
{
    private List<GameObject> Clouds = new List<GameObject>();
    private GameObject[] InstansCloud = new GameObject[50];
    [SerializeField] private GameObject Cloud;
    private Vector2 BaseVec = new Vector2(0, 0);
    private GameObject cat;
    private int CloudCount;
    private int RandomCount1;
    private int RandomCount2;
    private int RandomCount3;
    private bool OnDestroy;
    private int minuse;
    private int RoundCount;

    private void Start()
    {
        cat = GameObject.Find("cat");
        for(int i = 0; i < 5; i++)
        {
            InstansCloud[i] = Instantiate(Cloud, BaseVec + new Vector2(0, -4.5f + (2 * CloudCount)), Quaternion.identity);
            Clouds.Add(InstansCloud[i]);
            CloudCount++;
        }
    }
    private void Update()
    {
        if(CloudCount >= 0 && CloudCount <= 10)
        {
            if (cat.transform.position.y >= -4.5f + (2 * (CloudCount - 3)))
            {
                RandomCount1 = Random.Range(1, 6);
                InstansCloud[CloudCount] = Instantiate(Cloud, BaseVec + new Vector2(0, -4.5f + (2 * CloudCount)), Quaternion.identity);
                Clouds.Add(InstansCloud[CloudCount]);
                InstansCloud[CloudCount].transform.Find($"Cloud_Number{RandomCount1}").gameObject.SetActive(false);
                CloudCount++;
                OnDestroy = true;
            }
        }
        else if(CloudCount > 10 && CloudCount <= 19)
        {
            if (cat.transform.position.y >= -4.5f + (2 * (CloudCount - 3)))
            {
                RandomCount1 = Random.Range(1, 6);
                do
                {
                    RandomCount2 = Random.Range(1, 6);
                } while (RandomCount2 == RandomCount1);
                InstansCloud[CloudCount] = Instantiate(Cloud, BaseVec + new Vector2(0, -4.5f + (2 * CloudCount)), Quaternion.identity);
                Clouds.Add(InstansCloud[CloudCount]);
                InstansCloud[CloudCount].transform.Find($"Cloud_Number{RandomCount1}").gameObject.SetActive(false);
                InstansCloud[CloudCount].transform.Find($"Cloud_Number{RandomCount2}").gameObject.SetActive(false);
                CloudCount++;
                OnDestroy = true;
            }
        }
        else if(CloudCount >= 20)
        {
            if (cat.transform.position.y >= -4.5f + (2 * (CloudCount - 3 + RoundCount)))
            {
                RandomCount1 = Random.Range(1, 6);
                do
                {
                    RandomCount2 = Random.Range(1, 6);
                } while (RandomCount2 == RandomCount1);
                do
                {
                    RandomCount3 = Random.Range(1, 6);
                } while (RandomCount3 == RandomCount2 || RandomCount3 == RandomCount1);

                InstansCloud[CloudCount] = Instantiate(Cloud, BaseVec + new Vector2(0, -4.5f + (2 * (CloudCount + RoundCount))), Quaternion.identity);
                Clouds.Add(InstansCloud[CloudCount]);
                InstansCloud[CloudCount].transform.Find($"Cloud_Number{RandomCount1}").gameObject.SetActive(false);
                InstansCloud[CloudCount].transform.Find($"Cloud_Number{RandomCount2}").gameObject.SetActive(false);
                InstansCloud[CloudCount].transform.Find($"Cloud_Number{RandomCount3}").gameObject.SetActive(false);
                CloudCount++;
                OnDestroy = true;
            }
        }
        if (Clouds.Count >= 10 && OnDestroy)
        {
            if(CloudCount == 50)
            {
                CloudCount = 20;
                minuse = 0;
                RoundCount = RoundCount + 30;
            }
            if (InstansCloud[49] != null)
            {
                Clouds.Remove(InstansCloud[40 + minuse]);
                Destroy(InstansCloud[40 + minuse]);
                minuse++;
            }
            else
            {
                Clouds.Remove(InstansCloud[CloudCount - 10]);
                Destroy(InstansCloud[CloudCount - 10]);
            }
            OnDestroy = false;
        }
    }
    
}
