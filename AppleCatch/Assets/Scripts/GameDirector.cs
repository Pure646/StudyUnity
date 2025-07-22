using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject timerText;
    private GameObject pointText;
    [HideInInspector] public float time = 30.0f;
    private int point = 0;
    private GameObject generator;
    public GameObject GameOverPanel;
    public Text PointText;
    public Button RestartBtn;
    void Start()
    {
        this.timerText = GameObject.Find("Timer");
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator");

        if (RestartBtn != null)
        {
            RestartBtn.onClick.AddListener(() =>
            SceneManager.LoadScene("GameScene")
            );
        }
        time = 30;
    }
    void Update()
    {
        Time.timeScale = 1.0f;          // 원래 속도로 돌려놓기
        this.time -= Time.deltaTime;
        if(this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);

            GameOverPanel.SetActive(true);
            PointText.text = "획득점수 : " + this.point.ToString();
            Time.timeScale = 0.0f;      // 일시정지 효과를 얻을 수 있음.
        }
        else if(0 <= this.time && this.time < 5)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.9f, -0.04f, 3);
        }
        else if(5 <= this.time && this.time < 10)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.4f, -0.06f, 6);
        }
        else if(10 <= this.time && this.time < 20)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 4);
        }
        else if(20 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }

        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        // ToString("F1") : 소수점 첫번째 자리에서 끈어준다.
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " Point";
    }
    public void GetApple()
    {
        this.point += 100;
    }
    public void GetBomb()
    {
        this.point /= 2;
    }
}
