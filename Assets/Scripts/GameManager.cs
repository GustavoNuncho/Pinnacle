using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Menu Canvases: ")]
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject screenFader;

    private bool isPaused = false;
    public bool IsPaused { get { return isPaused; } }

    private bool isLoading = true;
    public bool IsLoading { get { return isLoading; } }

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScreenFadeClear());
        
        switch(SceneManager.GetActiveScene().name)
        {
            case "MainMenu":
                mainMenu.SetActive(true);
                break;
            default:
                mainMenu.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //PauseToggle(false);
    }

    public void PauseToggle(bool fromMenu)
    {
       /* if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (!fromMenu)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Pause();
                }
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        if (!isLoading)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }*/
    }
    
    public void ResetScene()
    {
        StartCoroutine(ResetSceneCoroutine());
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneName));
    }

    public void QuitApplication()
    {
        StartCoroutine(QuitApplicationCoroutine());
    }

    private IEnumerator ResetSceneCoroutine()
    {
        Time.timeScale = 1;

        PauseToggle(true);

        StartCoroutine(ScreenFadeBlack());

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private IEnumerator ChangeSceneCoroutine(string sceneName)
    {
        Time.timeScale = 1;
        
        PauseToggle(true);

        StartCoroutine(ScreenFadeBlack());

        yield return new WaitForSeconds(2.0f);
        
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    private IEnumerator QuitApplicationCoroutine()
    {
        StartCoroutine(ScreenFadeBlack());

        yield return new WaitForSeconds(2.0f);
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private IEnumerator ScreenFadeBlack()
    {
        isLoading = true;

        Image screenFaderImage = screenFader.transform.GetChild(0).GetComponent<Image>();
        float alpha = screenFaderImage.color.a;

        for (float i = 0; alpha < 1; i += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            alpha = i;
            screenFaderImage.color = new Color(screenFaderImage.color.r, screenFaderImage.color.g, screenFaderImage.color.b, alpha);
        }
    }

    private IEnumerator ScreenFadeClear()
    {
        Image screenFaderImage = screenFader.transform.GetChild(0).GetComponent<Image>();
        float alpha = screenFaderImage.color.a;

        for (float i = alpha; alpha > 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            alpha = i;
            screenFaderImage.color = new Color(screenFaderImage.color.r, screenFaderImage.color.g, screenFaderImage.color.b, alpha);
        }

        isLoading = false;
    }
}
