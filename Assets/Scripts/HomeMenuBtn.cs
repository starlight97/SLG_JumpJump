using UnityEngine;
using UnityEngine.SceneManagement;


public class HomeMenuBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject panelMenuBtn;
    [SerializeField]
    private GameObject panelOption;

    private GameOption gameOption;


    private void Start()
    {
        panelMenuBtn.SetActive(true);
        panelOption.SetActive(false);

        gameOption = panelOption.GetComponent<GameOption>();
    }

    public void GameStartBtnClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OptionBtnClick()
    {
        gameOption.Setting();
        panelMenuBtn.SetActive(false);
        panelOption.SetActive(true);
    }


    public void CloseBtnClick()
    {
        DataManager.instance.SaveSystemData();

        panelMenuBtn.SetActive(true);
        panelOption.SetActive(false);
    }
    public void ExitBtnClick()
    {
        Application.Quit();
    }
}
