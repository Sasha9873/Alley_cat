using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class cat_walk : MonoBehaviour
{
    public float walkSpeed;
    public float jumpHeight;
    public float doubleJumpHeight;
    int scoreCounter = 0;
    public Text scoreText;
    public TMP_Text winText;

    public TMP_Text deadText;

    public int waitAfterdeath;

    public Button restartButton;


    private int curRope = 0;

    private Animator anim;
    private static readonly int Walk1 = Animator.StringToHash("cat_walk");
    private Rigidbody rigidbody;
    Quaternion base_look;
    Quaternion opposite_look;

    private bool isGrounded;
    private bool jump = false;



    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        rigidbody = GetComponent<Rigidbody>();

        base_look = this.transform.rotation;
        opposite_look = base_look;
        opposite_look.SetEulerAngles(opposite_look.eulerAngles.x, opposite_look.eulerAngles.y + 2.5f, opposite_look.eulerAngles.z);

        scoreCounter = 10;
        scoreText.text = "Current score = " + scoreCounter.ToString();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void Update()
    {
        var delta = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //var move_look = Camera.main.transform.TransformDirection(delta);

        if (delta.x > 0 || delta.z > 0)
        {
            rigidbody.AddForce(delta * walkSpeed * Time.deltaTime, ForceMode.VelocityChange);
            var look = this.transform.rotation;
            if (look != base_look)
            {
                look = base_look;
            }
            transform.rotation = look;
        }
        else if (delta.x < 0 || delta.z < 0)
        {
            rigidbody.AddForce(delta * walkSpeed * Time.deltaTime, ForceMode.VelocityChange);
            var look = this.transform.rotation;
            if (look != opposite_look)
            {
                look = opposite_look;
            }
            transform.rotation = look;
            //transform.rotation = (Camera.main.transform.rotation);

        }

        
        if (isGrounded && Input.GetKeyDown("space"))
        {
            rigidbody.AddForce(Vector3.up * jumpHeight);
        }
        else if (Input.GetKeyDown(KeyCode.B) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * doubleJumpHeight);
        }

        
        if(anim && delta.sqrMagnitude > 0.01f)
        {
            anim.SetBool(Walk1, true);
        }
        else
        {
            anim.SetBool(Walk1, false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == ("rope1"))
        {
            isGrounded = true;
            if(curRope != 1)
                scoreCounter += 50;
            scoreText.text = "Current score = " + scoreCounter.ToString();
            curRope = 1;
        }
        else if (collision.gameObject.tag == ("rope2"))
        {
            isGrounded = true;
           if(curRope != 2)
                scoreCounter += 75;
            scoreText.text = "Current score = " + scoreCounter.ToString();
            curRope = 2;

        }
        else if (collision.gameObject.tag == ("rope3"))
        {
            isGrounded = true;
            if(curRope != 3)
                scoreCounter += 100;
            scoreText.text = "Current score = " + scoreCounter.ToString();
            curRope = 3;
        }

        else if(collision.gameObject.tag == ("enemy"))
        {
            scoreCounter = 0;
            scoreText.text = "Current score = " + scoreCounter.ToString();
            deadText.text = "You are dead!";

            restartButton.gameObject.SetActive(true);

            //wait();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

        }

        else if(collision.gameObject.tag == ("Finish"))
        {
            scoreText.text = "Current score = " + scoreCounter.ToString();
            winText.text = "You have won!!!";

            restartButton.gameObject.SetActive(true);
        }
        else if(collision.gameObject.tag == ("enemy_cat"))
        {
            var pos = this.transform.position;
            pos.z -=1;
            transform.position = pos;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("ground"))
        {
            isGrounded = false;
        }
    }

    private IEnumerator wait()
    {
        
        yield return new WaitForSeconds(waitAfterdeath);
        
    }

   
    private void OnEnable()
    {
        
    }
}

