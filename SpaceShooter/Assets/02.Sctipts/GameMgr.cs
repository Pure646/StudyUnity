using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum GameState
{
    GameIng,
    GameEnd
}
public class GameMgr : MonoBehaviour
{
    public static GameState s_GameState = GameState.GameIng;

    // ���Ͱ� ������ ��ġ�� ���� �迭
    public Transform[] points;
    //���� �������� �Ҵ��� ����
    public GameObject monsterPrefab;
    // ���͸� �̸� ������ ������ ����Ʈ �ڷ���
    public List<GameObject> monsterPool = new List<GameObject>();

    // ���͸� �߻���ų �ֱ�
    public float createTime = 2.0f;
    // ������ �ִ� �߻� ����
    public int maxMonster = 10;

    public bool isGameOver = false;

    // �̱��� ����
    public static GameMgr Inst = null;

    public Text txtScore;

    private int totScore = 0;

    public Button BackBtn;
    private void Awake()
    {
        Inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        s_GameState = GameState.GameIng;

        DispScore(0);

        if (BackBtn != null)
            BackBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Lobby");
            });
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        //���͸� ������ ������Ʈ Ǯ�� ����
        for(int i = 0; i < maxMonster; i++)
        {
            //���� �������� ����
            GameObject monster = (GameObject)Instantiate(monsterPrefab);
            //������ ������ �̸� ����
            monster.name = "Monster_" + i.ToString();
            //������ ���͸� ��Ȱ��ȭ
            monster.SetActive(false);
            //������ ���͸� ������Ʈ Ǯ�� �߰�
            monsterPool.Add(monster);
        }
        if(1 < points.Length)
        {
            StartCoroutine(this.CreateMonster());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DispScore(int score)
    {
        totScore += score;
        txtScore.text = "Score <color=#ff0000>" + totScore.ToString() + "</color>";
    }
    public bool IsPointerOverUIObject() //UGUI�� UI���� ���� ��ŷ�Ǵ��� Ȯ���ϴ� �Լ�
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

    IEnumerator CreateMonster()
    {
        while (s_GameState == GameState.GameIng)
        {
            yield return new WaitForSeconds(createTime);

            if (s_GameState == GameState.GameEnd)
                yield break;

            foreach (GameObject monster in monsterPool)
            {
                if (!monster.activeSelf)
                {
                    int idx = Random.Range(1, points.Length);

                    monster.transform.position = points[idx].position;
                    monster.SetActive(true);
                    break;
                }
            }

            //int monsterCount = (int)GameObject.FindGameObjectsWithTag("MONSTER").Length;

            //if(monsterCount < maxMonster)
            //{
            //    yield return new WaitForSeconds(createTime);

            //    if (s_GameState == GameState.GameEnd)
            //        yield break;

            //    int idx = Random.Range(1, points.Length);

            //    Instantiate(monsterPrefab, points[idx].position, points[idx].rotation);
            //}
            //else
            //{
            //    yield return null;
            //}
        }
    }
}
