using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScreen : MonoBehaviour
{
    public string MainMenuScene;
    public GameObject pauseMenu;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
            }
        }
    }

    public void ResumeGame()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(MainMenuScene);

    }
}
