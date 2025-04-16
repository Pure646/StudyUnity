using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Scissors_Rock_Paper : MonoBehaviour
{
    public int User_money;
    private int Victory_Count = 0;
    private int Draw_Count = 0;
    private int Defeat_Count = 0;

    private string Result_SRP;
    private int Computer_Random;
    private string Computer_SRP;
    private int User_Number;
    private string User_SRP;

    [Header("------------------------------------")]
    public Text User_money_Text;
    public Text Victory_Text;
    public Text Draw_Text;
    public Text Defeat_Text;

    public Text User_Actuality_Text;
    public Text Computer_Actuality_Text;
    public Text Result_Counter_Text;

    public Button Scissors_Button;
    public Button Rock_Button;
    public Button Paper_Button;

    public Image User_Image;
    public Image Computer_Image;

    public Sprite Scissors_Image;
    public Sprite Rock_Image;
    public Sprite Paper_Image;

    public Button Reset_Button;

    private void Start()
    {
        if (Scissors_Button != null)
        {
            Scissors_Button.onClick.AddListener(Scissors);
        }
        if (Rock_Button != null)
        {
            Rock_Button.onClick.AddListener(Rock);
        }
        if(Paper_Button != null)
        {
            Paper_Button.onClick.AddListener(Paper);
        }
        if(Reset_Button != null)
        {
            Reset_Button.onClick.AddListener(Reset_Btn);
        }
    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    while(User_money > 0)
        //    {
        //        Rock();
        //    }
        //}
    }
    
    private void Random_system()
    {
        Computer_Random = Random.Range(1, 4);
        if(Computer_Random == 1)
        {
            Computer_SRP = "가위";
            Computer_Image.sprite = Scissors_Image;
        }
        else if(Computer_Random == 2)
        {
            Computer_SRP = "바위";
            Computer_Image.sprite = Rock_Image;
        }
        else if(Computer_Random == 3)
        {
            Computer_SRP = "보";
            Computer_Image.sprite = Paper_Image;
        }
        
    }
    private void User_System()
    {
        if(User_Number == 1)
        {
            User_SRP = "가위";
            User_Image.sprite = Scissors_Image;
        }
        else if(User_Number == 2)
        {
            User_SRP = "바위";
            User_Image.sprite = Rock_Image;
        }
        else if(User_Number == 3)
        {
            User_SRP = "보";
            User_Image.sprite = Paper_Image;
        }
        
    }
    private void Draw_System()
    {
        if(User_Number == Computer_Random)
        {
            Result_SRP = "비겼습니다.";
        }
    }
    private void Result_Text()
    {
        User_money_Text.text = $"유저의 보유금액 : {User_money}";
        Victory_Text.text = $"승리 : {Victory_Count}";
        Defeat_Text.text = $"패배 : {Defeat_Count}";
        Draw_Text.text = $"무승부 : {Draw_Count}";

        User_Actuality_Text.text = $"유저 : {User_SRP}";
        Computer_Actuality_Text.text = $"컴퓨터 : {Computer_SRP}";
    }
    private void Reset_Btn()
    {
        User_money = 1000;
        Victory_Count = 0;
        Defeat_Count = 0;
        Draw_Count = 0;

        User_Number = 0;
        User_SRP = "None";
        Computer_SRP = "None";
        User_Image.sprite = null;
        Computer_Image.sprite = null;
        Result_Text();
        Result_Counter_Text.text = "초기화가 완료되었습니다.";

    }
    private void Scissors()
    {
        if (User_money <= 0)
            return;
        User_Number = 1;
        Random_system();
        User_System();
        Draw_System();
        if (Computer_Random == 1)            // 가위
        {
            Draw_Count++;
            Result_Counter_Text.text = Result_SRP;
        }
        else if(Computer_Random == 2)       // 바위
        {
            Defeat_Count++;
            User_money -= 200;
            Result_Counter_Text.text = "패배하였습니다.";
        }
        else if(Computer_Random == 3)       // 보
        {
            Victory_Count++;
            User_money += 200;
            Result_Counter_Text.text = "이겼습니다.";
        }
        Result_Text();
    }
    private void Rock()
    {
        if (User_money <= 0)
            return;
        User_Number = 2;
        Random_system();
        User_System();
        Draw_System();
        if (Computer_Random == 1)            // 가위
        {
            Victory_Count++;
            User_money += 200;
            Result_Counter_Text.text = "이겼습니다.";
        }
        else if (Computer_Random == 2)       // 바위
        {
            Draw_Count++;
            Result_Counter_Text.text = Result_SRP;
        }
        else if (Computer_Random == 3)       // 보
        {
            Defeat_Count++;
            User_money -= 200;
            Result_Counter_Text.text = "패배하였습니다.";
        }
        Result_Text();
    }
    private void Paper()
    {
        if (User_money <= 0)
            return;
        User_Number = 3;
        Random_system();
        User_System();
        Draw_System();
        if (Computer_Random == 1)            // 가위
        {
            Defeat_Count++;
            User_money -= 200;
            Result_Counter_Text.text = "패배하였습니다.";
        }
        else if (Computer_Random == 2)       // 바위
        {
            Victory_Count++;
            User_money += 200;
            Result_Counter_Text.text = "이겼습니다.";
        }
        else if (Computer_Random == 3)       // 보
        {
            Draw_Count++;
            Result_Counter_Text.text = Result_SRP;
        }
        Result_Text();
    }
}
