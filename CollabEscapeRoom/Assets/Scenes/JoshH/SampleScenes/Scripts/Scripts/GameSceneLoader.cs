using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector Fade;
    void Start()
    {
        
    }


    public void MainSceneLoader() 
    {
        Fade.Play();
        Invoke("MainSceneLoadFade", 2);
    }

    public void MainSceneLoadFade()
    {
        SceneManager.LoadScene("GameScene");
        

    }
}
