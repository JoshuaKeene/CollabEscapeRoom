using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerJH : MonoBehaviour
{
    // Start is called before the first frame update


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //Application.targetFrameRate = 60;
    }
    void Start()
    {

        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
