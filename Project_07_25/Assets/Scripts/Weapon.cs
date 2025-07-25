using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet_1;
    private void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            Vector2 Trans = new Vector2(transform.position.x + 0.9f, transform.position.y);
            GameObject Shoot = Instantiate(Bullet_1, Trans, Quaternion.identity);
        }
    }
}
