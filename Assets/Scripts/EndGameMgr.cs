using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndGameMgr : MonoBehaviour
{
    public bool gameOver = false;
    public float restartTimer = 1.5f;
    public GameObject mainUI;

    public GameObject completeUI;
    public Text mainUITime;
    public TMP_Text finalTime;
    public void Completed()
    {
        if (gameOver == false)
        {
            mainUI.SetActive(false);
            completeUI.SetActive(true);
            gameOver = true;
            finalTime.text = mainUITime.text;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Win");
            Debug.Log(gameOver);
            //Invoke("Restart", restartTimer);
        }
    }

    public GameObject diedUI;
    public void Died()
    {
        if (gameOver == false)
        {
            mainUI.SetActive(false);
            diedUI.SetActive(true);
            gameOver = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Ded");
            //Invoke("Restart", restartTimer);
        }
    }

    public void Restart()
    {
        // restart from the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
