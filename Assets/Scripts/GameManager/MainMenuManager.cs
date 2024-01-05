using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject SettingPanel;
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting()
    {
        MainPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        MainPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("2.Gameplay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
