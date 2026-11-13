using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
