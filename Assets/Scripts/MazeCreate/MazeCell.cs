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

    public bool l = true, r = true, f = true, b = true;
    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
        Destroy(_unvisitedBlock);
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
        l = false;
        Destroy(_leftWall);
    }

    public void ClearRightWall()
    {
        r = false;
        Destroy(_rightWall);
    }

    public void ClearFrontWall()
    {
        f = false;
        Destroy(_frontWall);
    }

    public void ClearBackWall()
    {
        b = false;
        Destroy(_backWall);
    }
}