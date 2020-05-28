using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject panelGameOver;

    public void GameOver(string message)
    {
        panelGameOver.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = message;
        panelGameOver.SetActive(true);
    }

    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadSceneAsync(sceneNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
