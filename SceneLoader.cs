using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour


{

 
 


 public void LoadStartMenu()
 {
    FindObjectOfType<GameStatus>().ResetGame();
    SceneManager.LoadScene("Start Menu");
 }

 public void LoadNextScene() 
 {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
    Debug.Log(currentSceneIndex);
    SceneManager.LoadScene(currentSceneIndex + 1);
 }

 public void QuitGame(){
   Application.Quit();
 }
}
