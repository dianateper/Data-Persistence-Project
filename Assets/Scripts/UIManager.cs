using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] GameObject usernameValidationMessage;
    [SerializeField] TMP_Text BestScoreText;

    private void Start()
    {
        usernameInput.text = GameManager.Instance.bestPlayer.Username;
        BestScoreText.text = GameManager.Instance.bestPlayer.ToString();
    }

    public void LoadMain()
    {
        if (!string.IsNullOrEmpty(usernameInput.text))
        {
            GameManager.Instance.currentPlayer.Username = usernameInput.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            usernameValidationMessage.SetActive(true);
        }
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        GameManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
