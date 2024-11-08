using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }
    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume(){
        
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }
   public void MainMenu(){
    Time.timeScale = 1f;
       SceneManager.LoadScene(0);
   } 
   public void Restart()
   {
         Time.timeScale = 1f;
    SceneManager.LoadScene(1);
   }

}
