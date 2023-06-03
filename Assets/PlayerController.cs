using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;
    public KeyCode keyRight = KeyCode.D;
    public KeyCode keyLeft = KeyCode.A;
    public float limitRight = -7;
    public float limitLeft = -9;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame  -7
    void Update()
    {
        

        if(Input.GetKey(keyUp) && transform.position.y<4)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }

        if (Input.GetKey(keyDown) && transform.position.y > -4)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }

        if (Input.GetKey(keyRight) && transform.position.x < limitRight)
        {
            transform.position += Vector3.right * Time.deltaTime * speed*5;
        }
        if (Input.GetKey(keyLeft) && transform.position.x > limitLeft)
        {
            transform.position += Vector3.left * Time.deltaTime * speed*5;
        }




    }
}
