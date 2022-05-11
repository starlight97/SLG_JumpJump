using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textScore;   // Text - TextMeshPro UI [����]
    [SerializeField]
    private GameManager gameManager;

    private void Start()
    {
        textScore.text = "Your Score : " + gameManager.Score;
    }

}
