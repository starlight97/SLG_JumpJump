using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    [SerializeField]
    private ItemSpawner itemSpawner;
    [SerializeField]
    private PlayerMove playerMove;
    private GameManager gameManager;

    private int difficulty;
    private float currentTime;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        currentTime = 0f;
        difficulty = 1;
        DifficultySetting();
    }

    // Update is called once per frame
    void Update()
    {

        if(gameManager.Score != 0)
        {
            currentTime = currentTime + Time.deltaTime;
        }

        if (currentTime >= 60f && difficulty == 1)
        {
            difficulty = 2;
            DifficultySetting();
        }
        else if (currentTime >= 120f && difficulty == 2)
        {
            difficulty = 3;
            DifficultySetting();
        }

    }

    public void DifficultySetting()
    {

        if (difficulty == 1)
        {
            itemSpawner.ItemHeight = 2.3f;
            playerMove.JumpPower = 4f;
            playerMove.Gravity = 3f;
        }
        else if (difficulty == 2)
        {
            itemSpawner.ItemHeight = 4.6f;
            playerMove.JumpPower = 8f;
            playerMove.Gravity = 6f;
        }
        else if (difficulty == 3)
        {
            itemSpawner.ItemHeight = 7f;
            playerMove.JumpPower = 9.3f;
            playerMove.Gravity = 6f;
        }
    }
}

/*
 * 게임 난이도 설정 스크립트 입니다.
 * 
 */