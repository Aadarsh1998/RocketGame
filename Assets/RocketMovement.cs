﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rb;
    //AudioSource audio;
    [SerializeField]
    float thrust;
    [SerializeField]
    float rotateThrust;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RcoketFly();
        RocketControls();
    }


    private void RcoketFly()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(Vector3.up * thrust);
            //if (audio.isPlaying == false)
            //{
            //    audio.Play();
            //}


        }
        //else
        //{
        //    audio.Stop();
        //}
    }
    private void RocketControls()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotateThrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotateThrust * Time.deltaTime);
        }
        rb.freezeRotation = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
