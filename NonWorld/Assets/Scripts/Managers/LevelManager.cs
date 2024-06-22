using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string levelName;

    public void LoadLevel(){
        SceneManager.LoadScene(levelName,LoadSceneMode.Single);
    }
    public void ExitGame(){
        Application.Quit();
    }
}
