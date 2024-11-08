using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenu;
    public GameObject InstructionsPanel;
    void Start()
    {
        mainMenu.SetActive(true);
        InstructionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Settings(){
        InstructionsPanel.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Back(){
        InstructionsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
}
