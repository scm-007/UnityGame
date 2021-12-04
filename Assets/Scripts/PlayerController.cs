using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instant;

    public float horizontal;
    [SerializeField] private bool isGrounded;
    [SerializeField] float jumpPower = 600f;
    [SerializeField] ForceMode forceMode;

    public Rigidbody rigidbody;
    public GameObject vanishingStep;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        if (instant == null)
        {
            instant = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void Move()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
        }

        rigidbody.velocity = new Vector3(horizontal * 35f, rigidbody.velocity.y);
    }

    public void Jump(float jumpPower)
    {
        isGrounded = false;
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        rigidbody.AddForce(new Vector3(0, jumpPower, 0), forceMode);
    }
    public void OnTriggerEnter(Collider other)
    {
        print(rigidbody.velocity.y);
        
        if (rigidbody.velocity.y < 0)
        {
            if (other.gameObject.tag == "Step")
            {
                Jump(jumpPower);
            }
            else if (other.gameObject.tag == "VanishingStep")
            {
                Jump(800f);
                Destroy(vanishingStep);
            }
            else
            {
                isGrounded = true;
            }
            if (other.tag == "DeadZone")
            {
                SceneManager.LoadScene(1);
            }
        }

        if (other.name == "RightZone")
        {
            print("RightZone");
            gameObject.transform.position = new Vector3(-4f, transform.position.y, 0f);
        }

        if (other.name == "ZoneLeft")
        {
            print("LeftZone");
            gameObject.transform.position = new Vector3(4f, transform.position.y, 0f);
        }
    }
}


