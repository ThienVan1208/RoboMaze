using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public static ChangeScene Instance;
    public Image fade;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void NextScene(int sceneIndex)
    {
        StartCoroutine(FadeUI(sceneIndex));
    }

    IEnumerator FadeUI(int sceneIndex)
    {
        fade.gameObject.SetActive(true);
        fade.DOFade(1f,1f);
        yield return new WaitForSeconds(1f);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadSceneAsync(sceneIndex);

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fade.DOFade(0f, 1f);
        StartCoroutine(FadeSceneLoad());
    }
    IEnumerator FadeSceneLoad()
    {
        yield return new WaitForSeconds(1f);
        fade.gameObject.SetActive(false);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
