using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;
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


    }
}
