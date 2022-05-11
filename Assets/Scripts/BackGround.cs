using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private Transform[] backGroundTransform;

    [SerializeField]
    private Player player;

    private int backGroundIndex;
    private int backGroundCount;
    private int currentPlayerPosY;
    private float backGroundHeight;
    private void Start()
    {
        backGroundIndex = 0;
        currentPlayerPosY = 0;
        backGroundHeight = 10f;
        backGroundCount = backGroundTransform.Length;
    }
    // Update is called once per frame
    void Update()
    {
        if(player.PosYIndex > currentPlayerPosY)
        {
            BackGroundSort();
            currentPlayerPosY = player.PosYIndex;            
        }
        
    }


    private void BackGroundSort()
    {
        float posX = transform.position.x;
        float posZ = transform.position.z;
        // 플레이어 위치가 백그라운드 이미지 높이만큼 올려갈때마다
        // 백그라운드 index번째 부터 위치를 위로올리고 마지막 index가 됬을때
        // 다시 index0부터 위에 작업 반복
        float height = (backGroundCount * backGroundHeight) + (currentPlayerPosY * backGroundHeight);
 
        backGroundIndex = currentPlayerPosY % backGroundCount;
        backGroundTransform[backGroundIndex].position = new Vector3(posX, height, posZ);


    }
}
