using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject button_Next, UI_ChooseHeroCanvas;
    [SerializeField] private TMPro.TMP_InputField TMP_InputField;


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }




    public void UI_ShowChooseHero()
    {
        UI_ChooseHeroCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void UI_ShowNextButton()
    {
        button_Next.SetActive(true);
    }




    public void SaveData()
    {
        PlayerData.PlayerName = TMP_InputField.text;
    }
}
