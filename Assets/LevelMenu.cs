using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lvWindow;
    void Start()
    {
        PopUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PopUp()
    {
        lvWindow.SetActive(true);
        lvWindow.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1f);
    }

    public void LevelEasy()
    {
        ChangeScene.Instance.NextScene(1);
    }
    public void LevelMedium()
    {
        ChangeScene.Instance.NextScene(2);
    }
    public void LevelHard()
    {
        ChangeScene.Instance.NextScene(3);
    }

}
