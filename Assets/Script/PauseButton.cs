using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {

    }

    public void ActiveMenu(){
        Time.timeScale=0;
        pauseMenuUI.SetActive(true);
    }

    public void DeactiveMenu(){
        Time.timeScale=1;
        pauseMenuUI.SetActive(false);
    }
}
