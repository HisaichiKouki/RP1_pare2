using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;


public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;
    Rigidbody2D playerRigidbody;
    private Vector2 input;
    private GameObject playerAnimeObj;
    private Animator playerAnime = null;
    private bool isYadoHold;
    GameObject holdObj;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        isYadoHold = false;
        playerAnimeObj = transform.GetChild(0).gameObject;
        playerAnime=playerAnimeObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Hold();
        SetAnimator();
    }


    void Move()
    {

       
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        Vector2 velocity = input* moveSpeed;
        Debug.Log("vel=" + velocity);
        playerRigidbody.velocity = velocity;
        if (velocity.x > 0)
        {
            playerAnimeObj.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (velocity.x < 0)
        {
            playerAnimeObj.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void Hold()
    {
        //if(holdObj == null) { return; }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("isYadoHold");
            isYadoHold =!isYadoHold;
        }
    }

    void SetAnimator()
    {
        playerAnime.SetFloat("speed", input.magnitude);
        playerAnime.SetBool("isYadoHold", isYadoHold);

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        holdObj = collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        holdObj = null;
    }
}
