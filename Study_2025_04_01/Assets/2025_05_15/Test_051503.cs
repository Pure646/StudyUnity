using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ŭ���� �Ҽ� �ɹ� static(����) ����, (�����޼���)
// <Ư��>
// 1, ��ü �������� Ŭ�����̸�.������, Ŭ�����̸�.�޼����̸�()
// 2, ���α׷��� ������ �� �޸𸮰� Ȯ���Ǽ� ���α׷��� ����� ������ �����ȴ�.
// 3, Ŭ���� �Ҽ������� �޸𸮸� Ŭ������ ������ �����ϰ� �����ȴ�.

public class Hero
{
    public string m_Name;                   //<-- �Ϲ� �ɹ� ���� (�ν��Ͻ� �ɹ� ����)
    public int m_Hp;

    public static int s_UserPoint = 0;      //<-- ���� �ɹ� ���� (Ŭ���� �ɹ� ����)

    public void AddUserPoint(int a_Point)   //<-- �Ϲ� �ɹ� �޼��� (�ν��Ͻ� �ɹ� �޼���)
    {
        s_UserPoint = a_Point;
    }
    public int GetUserPoint()               //<-- �Ϲ� �ɹ� �޼���
    {
        return s_UserPoint;
    }

    public static void StaticPrint()        //<-- ���� �ɹ� �޼��� (Ŭ���� �ɹ� �޼���)
    {
        Debug.Log(s_UserPoint);
    }
}
public class Test_051503 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
