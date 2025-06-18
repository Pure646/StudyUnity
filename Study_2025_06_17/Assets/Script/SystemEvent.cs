using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemEvent : MonoBehaviour
{
    private List<GameObject> Clouds = new List<GameObject>();
    private List<GameObject> Fishs = new List<GameObject>();
    [SerializeField] private GameObject Cloud;
    [SerializeField] private GameObject Fish;
    private Vector2 BaseVec = new Vector2(0, 0);
    private GameObject cat;
    private int CloudCount;
    private int RandomCount1;
    private int RandomCount2;
    private int RandomCount3;
    private int RandomFishCount;
    private bool OnDestroy;

    private void Start()
    {
        cat = GameObject.Find("cat");
        for(int i = 0; i < 5; i++)
        {
            GameObject Clone = Instantiate(Cloud, BaseVec + new Vector2(0, -4.5f + (2 * CloudCount)), Quaternion.identity);
            Clouds.Add(Clone);
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
                
                GameObject Clone = Instantiate(Cloud, BaseVec + new Vector2(0, -4.5f + (2 * CloudCount)), Quaternion.identity);
                Clouds.Add(Clone);
                Clone.transform.Find($"Cloud_Number{RandomCount1}").gameObject.SetActive(false);

                HealingFish();
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
                GameObject Clone = Instantiate(Cloud, BaseVec + new Vector2(0, -4.5f + (2 * CloudCount)), Quaternion.identity);
                Clouds.Add(Clone);
                Clone.transform.Find($"Cloud_Number{RandomCount1}").gameObject.SetActive(false);
                Clone.transform.Find($"Cloud_Number{RandomCount2}").gameObject.SetActive(false);

                HealingFish();
                CloudCount++;
                OnDestroy = true;
            }
        }
        else if(CloudCount >= 20)
        {
            if (cat.transform.position.y >= -4.5f + (2 * (CloudCount - 3)))
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

                GameObject Clone = Instantiate(Cloud, BaseVec + new Vector2(0, -4.5f + (2 * CloudCount)), Quaternion.identity);
                Clouds.Add(Clone);
                Clone.transform.Find($"Cloud_Number{RandomCount1}").gameObject.SetActive(false);
                Clone.transform.Find($"Cloud_Number{RandomCount2}").gameObject.SetActive(false);
                Clone.transform.Find($"Cloud_Number{RandomCount3}").gameObject.SetActive(false);

                HealingFish();
                CloudCount++;
                OnDestroy = true;
            }
        }

        if (Clouds.Count >= 10 && OnDestroy)
        {
            Destroy(Clouds[0]);
            Clouds.RemoveAt(0);

            OnDestroy = false;
        }
        if (Fishs.Count >= 10)
        {
            Destroy(Fishs[0]);
            Fishs.RemoveAt(0);
        }
    }
    private void HealingFish()
    {
        RandomFishCount = Random.Range(1, 21);
        if (RandomFishCount <= 5)
        {
            GameObject FishClone = Instantiate(Fish, new Vector2(-3.5f + (1.75f * (RandomFishCount - 1)), -3.5f + (2f * CloudCount)), Quaternion.identity);
            Fishs.Add(FishClone);
        }
    }
    
}
