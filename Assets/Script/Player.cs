using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
     Rigidbody2D playerRigidbody;
    private bool ishold;
    GameObject holdObj;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        ishold = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Hold();
    }

    
    void Move()
    {

        Vector2 input;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        Vector2 velocity = input * moveSpeed;
        Debug.Log("vel=" + velocity);
        playerRigidbody.velocity = velocity;
    }

    void Hold()
    {
        //if(holdObj == null) { return; }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("isHold");
            ishold = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        holdObj=collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        holdObj = null;
    }
}
