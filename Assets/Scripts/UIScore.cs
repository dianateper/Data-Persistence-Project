using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScore : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = GameManager.Instance.bestPlayer.ToString();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
