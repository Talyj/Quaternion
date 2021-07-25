using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private string chemin, jsonString;
    private  float playerSpeed = 20; 
    [SerializeField] private Camera mainCamera;
    private float jumpPower = 7000;
    private float jumpCoolDown;
    private int jumpCounter = 2;

    public Animator steve;
    public GameObject panel;
        
    //Movement and Dash variables
    private Vector3 lastDirectionIntent;
    
    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        gameObject.transform.localPosition += lastDirectionIntent * (Time.deltaTime * playerSpeed);
    }
    
    void Update()
    {
        jumpCoolDown -= Time.deltaTime;
        Movement();
        Jump();
        lastDirectionIntent = lastDirectionIntent.normalized;
    }

    private void Jump()
    {
        if (jumpCoolDown <= 0 && Input.GetKey(KeyCode.Space) && jumpCounter > 0)
        {
            jumpCoolDown = 0.3f;
            if (jumpCounter == 1)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower * 1.1f);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
            }
            jumpCounter -= 1;
            steve.SetBool("jump", true);
        }
        else
        {
            steve.SetBool("jump", false);
        }
    }
    
    private void Movement()
    {
        // Get key down (Z,Q,S,D) 
        if (Input.GetKey(KeyCode.D))
        {
            lastDirectionIntent += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            lastDirectionIntent +=  Vector3.left;
        }
        if (!Input.anyKey)
        {
            // Si on lâche la touche on s'arrête
            lastDirectionIntent = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            jumpCounter = 2;
        }

        if (other.CompareTag("Obstacle"))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
