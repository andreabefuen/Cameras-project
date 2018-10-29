﻿using UnityEngine;
using System.Collections;

public class ShipMovementGame : MonoBehaviour {

    Rigidbody shipRigidbody;
    Vector3 movement;


    public float speed;
    Vector3 target;
    Vector3 targetRot;
    Vector2 A, B, C, D;
    Camera mainCam;
    StereoscopicCamController camController;


    private float distanceToShip;
    private float sweetSpot;
    private float advanceDistance;


    // Use this for initialization
    void Start () {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        camController = mainCam.GetComponent<StereoscopicCamController>();
        sweetSpot = camController.SWEETSPOTLOCATION;

        shipRigidbody = GetComponent<Rigidbody>();

        Debug.Log(Screen.width);

    }
	
	// Update is called once per frame
	void Update () {


        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float avance = Input.GetAxisRaw("Avance");

       //Boton para acelerar y desacelerar

       // Move(h, v);

        Turning(h, v);

        MoveAvance(h,v, avance);

       // Debug.Log("SFJSF: " + transform.forward * h * -1);

     


	
	}

    void MoveAvance(float h, float v, float a)
    {
        movement.Set(h, v, a);
        movement = movement.normalized * speed * Time.deltaTime;

        Vector3 newPos = new Vector3();
        newPos = transform.position + movement;




        Vector3 pos = mainCam.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = mainCam.ViewportToWorldPoint(pos);

        shipRigidbody.MovePosition(transform.position + movement);
    }

    void Turning(float h, float v)
    {

        

        Vector3 rotation = transform.forward * h * -1;
        rotation.z = Mathf.Clamp(rotation.z, -0.5f, 0.5f);

        if (h == 0)
        {
            //Debug.Log("no gira");

            shipRigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * speed));
               
            
           // shipRigidbody.AddTorque(rotation * -1, ForceMode.VelocityChange);
          

        }
        else
        {
            shipRigidbody.AddTorque(rotation, ForceMode.VelocityChange);
        }


     
    }

    void Move(float h, float v)
    {

        movement.Set(h, v, 0f);
        movement = movement.normalized * speed * Time.deltaTime;

        Vector3 newPos = new Vector3();
        newPos = transform.position + movement;

       


        Vector3 pos = mainCam.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = mainCam.ViewportToWorldPoint(pos);

        shipRigidbody.MovePosition(transform.position + movement);

        //shipRigidbody.MovePosition(transform.position + movement);



        //if(newPos.x < Screen.width && new)


    }
}