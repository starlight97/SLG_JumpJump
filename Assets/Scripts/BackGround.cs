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
        // �÷��̾� ��ġ�� ��׶��� �̹��� ���̸�ŭ �÷���������
        // ��׶��� index��° ���� ��ġ�� ���οø��� ������ index�� ������
        // �ٽ� index0���� ���� �۾� �ݺ�
        float height = (backGroundCount * backGroundHeight) + (currentPlayerPosY * backGroundHeight);
 
        backGroundIndex = currentPlayerPosY % backGroundCount;
        backGroundTransform[backGroundIndex].position = new Vector3(posX, height, posZ);


    }
}
