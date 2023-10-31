using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMgr : MonoBehaviour
{
    public GameObject ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitButton.SetActive(!ExitButton.activeSelf);
            Time.timeScale = ExitButton.activeSelf ? 0 : 1;
        }  
    }


    public void Exit(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }
}
