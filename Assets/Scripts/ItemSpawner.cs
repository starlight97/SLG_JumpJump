using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;
    [SerializeField]
    private Player player;

    private int itemCount;

    private float itemHeight;
    private float currentPosY;

    public float ItemHeight
    {
        get => itemHeight;
        set => itemHeight = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }
    private void Update()
    {       
        for (int i = 0; i < itemCount; i++)
        {
            if (items[i].activeSelf == true)
            {
                float distance = player.transform.position.y - items[i].transform.position.y;
                if (distance > 10f)
                {
                    items[i].transform.position = GetItemPosition();
                }
                    
            }
        }
    }


    private void Setup()
    {
        itemHeight = 2.3f;
        itemCount = items.Length;
        currentPosY = 0f;

        for (int i=0; i<itemCount; i++)
        {
            items[i].SetActive(true);
            items[i].transform.position = GetItemPosition();
        }

    }

    public void SpawnItem()
    {
        for (int i = 0; i < itemCount; i++)
        {
            if(items[i].activeSelf == false)
            {
                items[i].transform.position = GetItemPosition();
                items[i].SetActive(true);
                break;
            }
        }
    }

    private Vector3 GetItemPosition()
    {
        float posX = Random.Range(-5.5f, 5.5f);
        Vector3 pos = new Vector3(posX, currentPosY, 1);
        currentPosY = currentPosY + itemHeight;
        return pos;
    }
}
