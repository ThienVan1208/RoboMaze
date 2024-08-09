using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;
    public TextMeshProUGUI textScore;
    public GameObject player;
    public GameObject WinPanel, OverPanel;
    private Coroutine curCo = null;
    public ghost[] enemy;
    public GameObject instructPanel;
    public GameObject displayPanel;
    public GameObject[] panelRender;
    public Transform cam;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        
        WinPanel.SetActive(false);
        displayPanel = panelRender[0];
        StartCoroutine( ActiveInstruction());
        
    }

    public void Update()
    {
        DisplayScore();
        WinGame();
    }

    public void WinGame()
    {
        if (score == 99)
        {
            if (curCo == null)
            {
                curCo = StartCoroutine(Win());
            }
        }
    }

    public void ActiveOverPanel()
    {
        StopGhost();
        StopPlayer();
        OverPanel.SetActive(true);
        OverPanel.transform.Find("Over_window").DOScale(new Vector3(1f, 1f, 1f), 1f);

    }
    public void OverButton()
    {
        StartCoroutine(InactiveOverPanel());
    }
    public IEnumerator InactiveOverPanel()
    {
        OverPanel.transform.Find("Over_window").DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1f);
        ChangeScene.Instance.NextScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(exit(OverPanel, 1f));
        yield return new WaitForSeconds(1f);
        
        GameOver();
    }
    
    public void GameOver()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public IEnumerator Win()
    {
        move playerScript = player.GetComponent<move>();
        playerScript.canMove = false;
        playerScript.winning();
        StopGhost();
        yield return new WaitForSeconds(2.5f);
        WinPanel.SetActive(true);
        WinPanel.transform.Find("Win_window").DOScale(new Vector3(1f, 1f, 1f), 1f);
        playerScript.stopWin();
    }
    public void AgainButton()
    {
        StartCoroutine(PlayAgain());
    }
    public IEnumerator PlayAgain()
    {
        WinPanel.transform.Find("Win_window").DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1f);
        yield return new WaitForSeconds(1f);
        WinPanel.SetActive(false);
        GameOver();
    }
    public void DisplayScore()
    {
        textScore.text = "Score : " + score.ToString();
    }
    
    public IEnumerator ActiveInstruction()
    {
       
        StopGhost();
        StopPlayer();
        yield return new WaitForSeconds(1f);
        instructPanel.SetActive(true);
        displayPanel.transform.DOScale(new Vector3(1f, 1f, 1f), 1f);
    }
    public void InactiveInstruction()
    {
        displayPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1f);
        StartCoroutine(exit(instructPanel, 1f));
    }
    IEnumerator exit(GameObject panel, float time)
    {
        yield return new WaitForSeconds(time);
        panel.SetActive(false);
        StartCoroutine(CamReview());
    }

    public IEnumerator CamReview()
    {
        cam.GetComponent<MoveCam>().cam_rev = true;
        for (int i = 0; i < enemy.Length; i++)
        {
            cam.DOMove(new Vector3(enemy[i].transform.position.x, 4.5f, enemy[i].transform.position.z), 2f);
            yield return new WaitForSeconds(2f);
        }
        cam.DOMove(new Vector3(player.transform.position.x, 4.5f, player.transform.position.z), 1f);
        yield return new WaitForSeconds(1f);
        cam.GetComponent<MoveCam>().cam_rev = false;
        MoveGhost();
        MovePlayer();
    }

    public void StopGhost()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].notMove = true;
        }
    }
    public void MoveGhost()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].notMove = false;
        }
    }
    public void StopPlayer()
    {
        player.GetComponent<move>().canMove = false;
    }
    public void MovePlayer()
    {
        player.GetComponent<move>().canMove = true;
    }
    public void NextButtonClick()
    {
        StartCoroutine(NextButton());
    }
    public void BackButtonClick()
    {
        StartCoroutine (BackButton());
    }
    public IEnumerator NextButton()
    {
        
        panelRender[1].SetActive(true);

        
        
        yield return new WaitForSeconds(0.01f);
        displayPanel = panelRender[1];
        panelRender[0].SetActive(false);
        
    }
    public IEnumerator BackButton()
    {
        
        panelRender[0].SetActive(true);
        
        yield return new WaitForSeconds(0.01f);
        displayPanel = panelRender[0];
        panelRender[1].SetActive(false);
    }
}
