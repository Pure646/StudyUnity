using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    private float rotSpeed = 0;     // ȸ�� �ӵ�

    private float DownSpeed;
    private void Start()
    {
        // �����ӷ���Ʈ�� 60���� ���� (� ��ǻ���̿��� FPS �� ������Ų��.)
        Application.targetFrameRate = 60;       // �� �ѹ� ������ �ȴ�.

        // ����� �ֻ���(�÷���)�� �ٸ� ��ǻ���� ��� ĳ���� ���۽� ������ ������ �� �ִ�.
        // ������� �������� �����Ѵ�.  // 0�̸� ������� �ֻ����� ������ ���� �ʰ� �Ѵ�.
        QualitySettings.vSyncCount = 0;
    }
    private void Update()
    {
        
        // Ŭ���ϸ� ȸ�� �ӵ��� �����Ѵ�.
        if(Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 20;
            //for (int i = 11; i > 0; i--)
            //{
            //    this.rotSpeed = i;
            //    if(i == 1)
            //    {
            //        i = 11;
            //    }
            //    else if (Input.GetMouseButtonDown(1))
            //    {
            //        i = 0;
            //    }
            //    if(i == 0)
            //    {
            //        break;
            //    }
            //}
        }
        // ȸ�� �ӵ���ŭ �귿�� ȸ����Ų��.   // 1���� rotSpeed�� ��ŭ ���Ѵ�.
        transform.Rotate(0, 0, this.rotSpeed);

        // ȸ�� �ӵ��� ���� �پ���.
        this.rotSpeed *= 0.95f;
    }
}
