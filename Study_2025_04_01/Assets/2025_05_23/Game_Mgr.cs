using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;     //<--- �ʿ�
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    [HideInInspector] public int m_NumCount = 0;    // �ζ� ��ȣ �ε��� ī��Ʈ �� ����
    public Text[] NumberTexts;                      // �ζ� ��ȣ ǥ�� UI ����� ����
    public Button Replay_Btn = null;
    void Start()
    {
        for(int i = 0; i < NumberTexts.Length; i++)
        {
            NumberTexts[i].text = "";
        }
        if(Replay_Btn != null)
        {
            Replay_Btn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("2025_05_23 Scene");
            });
        }
    }
    void Update()
    {
        
    }

    public void SetNumber(int a_Num)
    {
        if(m_NumCount < NumberTexts.Length)
        {
            NumberTexts[m_NumCount].text = a_Num.ToString();
            m_NumCount++;
        }
    }
    

    public static bool IsPointerOverUIObject() //UGUI�� UI���� ���� ��ŷ�Ǵ��� Ȯ���ϴ� �Լ�
    {
    PointerEventData a_EDCurPos = new PointerEventData(EventSystem.current);

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)

			List<RaycastResult> results = new List<RaycastResult>();
			for (int i = 0; i < Input.touchCount; ++i)
			{
				a_EDCurPos.position = Input.GetTouch(i).position;  
				results.Clear();
				EventSystem.current.RaycastAll(a_EDCurPos, results);
                if (0 < results.Count)
                    return true;
			}

			return false;
#else
    a_EDCurPos.position = Input.mousePosition;
    List<RaycastResult> results = new List<RaycastResult>();
    EventSystem.current.RaycastAll(a_EDCurPos, results);
    return (0 < results.Count);
#endif
    }//public bool IsPointerOverUIObject()
}
