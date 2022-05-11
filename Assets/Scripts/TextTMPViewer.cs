using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textScore;   // Text - TextMeshPro UI [����]

    [SerializeField]
    private GameManager gameManager;


    void Update()
    {
        textScore.text = "Score : " + gameManager.Score.ToString();
    }
}
