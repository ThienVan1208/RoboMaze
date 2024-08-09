using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public Rigidbody rb;
    float horizontalMove, verticalMove;
    public Transform orientation;
    public Vector3 moveDirect;
   
    public Animator anim;
    bool run;
    public bool canMove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MoveInput();
            Running();
            getRun();
            Vector3 Dir = new Vector3(horizontalMove, 0, verticalMove);
            rb.velocity = Dir.normalized * speed;
            anim.SetFloat("speed", Dir.magnitude);
            directionRotate();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    
    public void MoveInput()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        
    }
    public void Running()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) { run = false; }
    }

    public void getRun()
    {
        if(run)
        {
            speed = 7f;
        }
        else
        {
            speed = 3f;
        }
    }

    public void directionRotate()
    {
        if(horizontalMove < 0 || Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation =  Quaternion.Euler(0, -90, 0);
        }
        if(horizontalMove > 0 || Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (verticalMove < 0 || Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        if (verticalMove > 0 || Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void winning()
    {
        anim.SetTrigger("win");
        anim.SetBool("cheer", true);
        rb.velocity = Vector3.zero;
        Debug.Log("winning");
    }
    public void stopWin()
    {
        anim.SetBool("cheer", false);
        Debug.Log("stopWin");
    }
    
}
