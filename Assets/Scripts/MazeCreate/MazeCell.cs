using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftWall;

    [SerializeField]
    private GameObject _rightWall;

    [SerializeField]
    private GameObject _frontWall;

    [SerializeField]
    private GameObject _backWall;

    [SerializeField]
    private GameObject _unvisitedBlock;

    public GameObject coin;
    public GameObject player;

    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
        _unvisitedBlock.SetActive(false);
        if (gameObject.transform.position == Vector3.zero)
        {
            Instantiate(coin, _unvisitedBlock.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(coin, _unvisitedBlock.transform.position, Quaternion.identity);
        }
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightWall.SetActive(false);
    }

    public void ClearFrontWall()
    {
        _frontWall.SetActive(false);
    }

    public void ClearBackWall()
    {
        _backWall.SetActive(false);
    }
}