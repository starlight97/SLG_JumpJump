using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMove;
    [SerializeField]
    private ItemSpawner itemSpawner;
    [SerializeField]
    private GameManager gameManager;

    public AudioClip audioEatItem;
    public AudioClip audioPlayerJump;
    private AudioSource audioSource;


    private int posYIndex;
    public int PosYIndex => posYIndex;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        posYIndex = (int)(transform.position.y / 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            item.OnEat();
            gameManager.UpScore();
            playerMove.ReadyJump = true;
            itemSpawner.SpawnItem();
            PlaySound("EATITEM");
        }
    }

    public void PlaySound(string action)
    {
        if (action == "EATITEM")
        {
            audioSource.clip = audioEatItem;
        }
        else if (action == "PLAYERJUMP")
        {
            audioSource.clip = audioPlayerJump;
        }
        audioSource.Play();
    }
}
