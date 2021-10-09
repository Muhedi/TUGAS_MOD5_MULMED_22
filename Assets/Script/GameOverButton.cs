using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverButton : MonoBehaviour
{
 
   public void GoToStartMenu(){

        SceneManager.LoadScene("StartMenu");
    }

    public void GoToGameplay(){
        SceneManager.LoadScene("Gameplay");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
