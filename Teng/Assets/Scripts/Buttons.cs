using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Button playButton;
    public Button optionsButton;
    public Button exitButton;
    public Button pauseButton;
    public Button resumeButton;

    public bool gamePause = false;

    public GameObject mainMenuMusic;
    public GameObject gameOverMenu;
    public GameObject backgroundMusic;
    public GameObject scoreBoard;
    public GameObject coinBoard;
    public GameObject player;
    public GameObject enemy;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject logo;

    private CoinBoard coinBoardScore;
    private ScoreScript scoreScriptReference;
    private SpawnManager spawnManager;
    private PlayerController playerController;
    private CutScene cutScene;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        cutScene = GameObject.Find("CutSceneScriptReceiver").GetComponent<CutScene>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        coinBoardScore = GameObject.Find("CoinBoard").GetComponent<CoinBoard>();
        scoreScriptReference = GameObject.Find("ScoreBoard").GetComponent<ScoreScript>();

        mainMenuMusic = GameObject.Find("MenuMusic");
        gameOverMenu = GameObject.Find("GAME OVER MENU");
        backgroundMusic = GameObject.Find("BackgroundMusic");
        scoreBoard = GameObject.Find("ScoreBoard");
        coinBoard = GameObject.Find("CoinImage");
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        mainMenu = GameObject.Find("MAIN MENU");
        pauseMenu = GameObject.Find("PAUSE MENU");
        logo = GameObject.Find("LOGO");


        gamePause = false;
        mainMenu.gameObject.SetActive(true);
        gameOverMenu.gameObject.SetActive(false);
        backgroundMusic.gameObject.SetActive(false);
        scoreBoard.gameObject.SetActive(false);
        coinBoard.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        enemy.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == true)
        {
            coinBoard.gameObject.SetActive(false);
            scoreBoard.gameObject.SetActive(false);
            StartCoroutine(GameIsOver());
        }
    }

    // This is for when the user clicks the Play button.
    public void PlayButtonClicker()
    {
        mainMenu.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        cutScene.StartCutsceneTransition();
        Debug.Log(playButton.gameObject.name + " was clicked");
        StartCoroutine(InterfaceShow());
        StartCoroutine(CallingEssentialObjects());
        CallingBackgroundMusic();
        playerController.transform.rotation = new Quaternion(playerController.transform.rotation.x, 0, playerController.transform.rotation.z, 0);
    }
    // This is for calling required objects to be in the scene.
    public IEnumerator CallingEssentialObjects()
    {
        yield return new WaitForSeconds(2);
        player.gameObject.SetActive(true);
        enemy.gameObject.SetActive(true);
        spawnManager.GettingComponents();
    }
    public IEnumerator InterfaceShow()
    {
        yield return new WaitForSeconds(4);
        pauseButton.gameObject.SetActive(true);
        scoreBoard.gameObject.SetActive(true);
        coinBoard.gameObject.SetActive(true);
    }
    public void PauseButtonClicker()
    {
        pauseMenu.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        gamePause = true;
        playerController.playerAnimator.SetFloat("Blend", 0.0f);
    }
    public void ResumeButtonClicker()
    {
        pauseMenu.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        gamePause = false;
        playerController.playerAnimator.SetFloat("Blend", 1.0f);
    }
    public void CallingBackgroundMusic()
    {
        mainMenuMusic.gameObject.SetActive(false);
        backgroundMusic.gameObject.SetActive(true);
    }
    public IEnumerator GameIsOver()
    {
        pauseButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        gameOverMenu.gameObject.SetActive(true);
    }
    public void RestartingGame()
    {
        coinBoardScore.ResettingCoin();
        scoreScriptReference.ResettingScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
