using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backgrounds;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject panelGameOver;
    [SerializeField]
    private GameAudioManager gameAudioManager;

    public AudioClip audioGameOver;
    private AudioSource audioSource;

    private int score;
    private float distance;
    private float backgroundPosY;
    private bool isGameOver;
    public int Score => score;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Setup();
    }
    private void Update()
    {
        backgroundPosY = backgrounds[0].transform.localPosition.y;
        for (int i=0; i< backgrounds.Length; i++)
        {
            if (backgroundPosY > backgrounds[i].transform.localPosition.y)
                backgroundPosY = backgrounds[i].transform.localPosition.y;
        }

        distance = backgroundPosY - player.transform.position.y;
        if(distance > 10f && !panelGameOver.activeSelf)
        {
            GameOver();
        }
        if(isGameOver)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Home");
            }
        }
    }
    private void Setup()
    {
        backgroundPosY = 9999f;
        score = 0;
        isGameOver = false;
    }

    public void UpScore()
    {
        score++;
    }

    private void GameOver()
    {
        isGameOver = true;
        gameAudioManager.StopSound();
        PlaySound("GAMEOVER");
        panelGameOver.SetActive(true);

        int highScore = DataManager.instance.userData.highScore;
        if (highScore < score)
        {
            DataManager.instance.SaveHighScore(score);
        }
    }



    public void PlaySound(string action)
    {
        if (action == "GAMEOVER")
        {
            audioSource.clip = audioGameOver;
        }

        audioSource.Play();
    }

}
