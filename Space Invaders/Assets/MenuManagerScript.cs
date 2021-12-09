using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour {

    public AudioSource audioSource;
    public AudioSource buttonPress;
    public static MenuManagerScript instance;
    public GameObject GameMenu;
    public GameObject MainMenu;

    public GameObject MenuItems;
    public GameObject GameButtons;

    private bool gameOn;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        //SceneManager.UnloadSceneAsync("Game");
        GameButtons.SetActive(false);
        gameOn = false;
	}
	
	// Update is called once per frame
	void Update () {

        TimeCount();
	}

    public void StartGame(string Game)
    {
        //GameController.instance.PlaySound(buttonPress, audioSource);
        buttonPress.Play();
        audioSource.Stop();
        //audioSource.PlayOneShot(buttonPress);
        SceneManager.LoadSceneAsync(Game, LoadSceneMode.Additive);
        MenuItems.SetActive(false);
        GameButtons.SetActive(true);
        game = Game;
        gameOn = true;
    }

    public uint frames = 0;
    public uint seconds = 0;
    public Text TimeText;

    void TimeCount()
    {
        if (gameOn)
        {
            if (frames >= 60)
            {
                seconds++;
                frames -= 60;
            }
            TimeText.text = seconds.ToString();
            frames++;
        }
        
        
    }

    private string game;

    public void QuitGame()
    {
        Application.Quit();
    }


    public Text startButtonText;

    public void ReturnToMenu()
    {
        SceneManager.UnloadScene(game);
        buttonPress.Stop();
        audioSource.Play();
        MenuItems.SetActive(true);
        GameButtons.SetActive(false);
        startButtonText.text = "Play Again";
        gameOn = false;
        frames = 0;
        seconds = 0;
    }
}
