using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public static NextScene Instance;
    private Scene currentScene;
    public int num;
    private enum NextGameScene
    {
        None = 0,
        Title,
        World_1,
        World_2,
    }
    private NextGameScene ChangeScene;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCurrentScene();
    }

    private void OnEnable()
    {
        InputSystem.Switch_Scene += NextChangeScene;
        //InputSystem.Current_Scene += StartCurrentScene;
    }
    private void OnDisable()
    {
        InputSystem.Switch_Scene -= NextChangeScene;
        //InputSystem.Current_Scene -= StartCurrentScene;
    }
    private void StartCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "None")
        {
            num = 0;
            ChangeScene = (NextGameScene)num;
        }
        else if (currentScene.name == "TitleScene")
        {
            num = 1;
            ChangeScene = (NextGameScene)num;
        }
        else if (currentScene.name == "GameWorld_1")
        {
            num = 2;
            ChangeScene = (NextGameScene)num;
        }
    }
    private void NextChangeScene()
    {
        if(ChangeScene != (NextGameScene)num)
        {
            ChangeScene = (NextGameScene)num;
            switch (ChangeScene)
            {
                case NextGameScene.None:
                    Debug.Log(ChangeScene);
                    break;
                case NextGameScene.Title:
                    SceneManager.LoadScene("TitleScene", LoadSceneMode.Single); 
                    Debug.Log(ChangeScene);
                    break;
                case NextGameScene.World_1:
                    SceneManager.LoadScene("GameWorld_1", LoadSceneMode.Single);
                    Debug.Log(ChangeScene);
                    break;
            }
        }
    }
    
}
