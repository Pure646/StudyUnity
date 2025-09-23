using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GameIng,
    GameEnd
}
public class GameMgr : MonoBehaviour
{
    public static GameState s_GameState = GameState.GameIng;

    // ΩÃ±€≈Ê ∆–≈œ
    public static GameMgr Inst = null;

    private void Awake()
    {
        Inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
