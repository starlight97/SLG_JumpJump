using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallMove : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject wallLeft;
    [SerializeField]
    private GameObject wallRight;
    private int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        //difficulty = DataManager.instance.Difficulty;

        difficulty = 2;
        if (difficulty == 1)
        {
            Vector3 pos = new Vector3(4.6f, 4f, 0);
            wallRight.transform.position = pos;
        }
        else if(difficulty == 2)
        {
            Vector3 pos = new Vector3(6.2f, 4f, 0);
            wallRight.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = wallLeft.transform.position.x;
        float y = player.transform.position.y + 7;
        Vector3 pos = new Vector3(x, y, 0);
        wallLeft.transform.position = pos;

        x = wallRight.transform.position.x;
        pos = new Vector3(x, y, 0);
        wallRight.transform.position = pos;
    }
}
