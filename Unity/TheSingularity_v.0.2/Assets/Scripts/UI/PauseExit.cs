using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class PauseExit : MonoBehaviour
{


    GameObject pauseMenu;
    GameObject defMenu;
    [SerializeField] Button btnSelected;
    [SerializeField] Button btnSelectedTemp;

    void Start()
    {
        pauseMenu = GameObject.Find("PAUSEMENU");
        defMenu = GameObject.Find("defaultMenu");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }

    }

    public void Pausar()
    {
        pauseMenu.SetActive(true);

        btnSelectedTemp.Select();
        btnSelected.Select();
        Time.timeScale = 0;
        GameManager.gamePaused = true;
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        GameManager.gamePaused = false;
        pauseMenu.SetActive(false);
    }

    //Listeners
   
}
