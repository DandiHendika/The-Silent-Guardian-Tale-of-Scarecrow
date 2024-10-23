using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] GameObject menu1;

    public GameObject Menu;
    public bool isPaused = false;
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }

    public void Continue(){
        Menu.SetActive(false);       // Sembunyikan pause menu
        Time.timeScale = 1f;   
        isPaused = false;
    }

    public void Pause(){
        Menu.SetActive(true);        
        Time.timeScale = 0f;               
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }
}
