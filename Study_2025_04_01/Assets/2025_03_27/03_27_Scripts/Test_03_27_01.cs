using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Study_Unity
{
    public class Test_03_27_01 : MonoBehaviour
    {
        private void Awake()
        {
            //Timeset();
        }
        private void OnEnable()
        {
            //Timeset();
        }
        private void Start()
        {
            //Timeset();
        }
        private void Update()
        {
            UpdateTime();
        }
        private void FixedUpdate()
        {
            FixedUpdateTime();
        }
        private void LateUpdate()
        {
            LateTimeset();
        }
        private void OnDisable()        // 프로젝트 사용을 종료했을때 한번 실행
        {
            OnDisableTime();
        }
        private void OnDestroy()
        {
            //Timeset();
        }
        private void UpdateTime()
        {
            if (Time.time <= 2)
            {
                Debug.Log("Update");
            }
        }
        private void FixedUpdateTime()
        {
            if (Time.time <= 2)
            {
                Debug.Log("FixedUpdate");
            }
        }
        private void LateTimeset()
        {
            if (Time.time <= 2)
            {
                Debug.Log("LateUpdate");
            }
        }
        private void OnDisableTime()
        {
            if (Time.time <= 2)
            {
                Debug.Log("OnDisable");
            }
        }
    }

}
