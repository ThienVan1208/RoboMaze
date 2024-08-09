using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CamPos;

    public bool cam_rev;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cam_rev)
            FollowPlayer();
    }
    public void FollowPlayer()
    {
        transform.position = new Vector3(CamPos.transform.position.x, 4.5f, CamPos.transform.position.z);
    }

}
