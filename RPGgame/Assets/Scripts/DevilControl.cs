using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevilControl : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D rbody;
    Animator anim;
    private bool moving;
    public float timeBetweenMove;
    private float TimeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;
        
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //TimeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        TimeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rbody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                moving = false;
                anim.SetBool("IsWalking", false);
                //TimeBetweenMoveCounter = timeBetweenMove;
                TimeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }else
        {
            TimeBetweenMoveCounter -= Time.deltaTime;
            rbody.velocity = Vector2.zero;

            if(TimeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                anim.SetBool("IsWalking", true);
                anim.SetFloat("input_x", moveDirection.x);
                anim.SetFloat("input_y", moveDirection.y);
            }
        }
        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
       /* if(other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;
        }*/
    }
}
