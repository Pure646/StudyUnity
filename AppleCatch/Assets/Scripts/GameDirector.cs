using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject timerText;
    private GameObject pointText;
    [HideInInspector] public float time = 30.0f;
    private int point = 0;
    void Start()
    {
        this.timerText = GameObject.Find("Timer");
        this.pointText = GameObject.Find("Point");
    }
    void Update()
    {
        this.time -= Time.deltaTime;
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
