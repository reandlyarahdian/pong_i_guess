using UnityEngine;
using UnityEngine.SceneManagement;
public class HalamanManager : MonoBehaviour
{
    public bool isPlay;
    public GameObject canvas;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (isPlay) {
                Paused();
            } else {
                Resume();
            }
        }
    }
    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
        isPlay = true;

    }
    public void Paused()
    {
        canvas.SetActive(true);
        Time.timeScale = 0;
        isPlay = false;
    }
    public void MulaiPermainan()
    {
        SceneManager.LoadScene("Main");
    }
    public void KembaliKeMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void doExit(){
        Application.Quit();
    }
}