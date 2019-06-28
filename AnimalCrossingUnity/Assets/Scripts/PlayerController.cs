using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES -- edit in inspector
    public float walkSpeed;         // The speed scalar for walking
    public float turnSpeed;         // The speed scalar for turning (lerp constant)
    public new GameObject camera;   // The camera looking at the player

    // PRIVATE VARIABLES
    // private isSprinting = false;
    private float v;  // Input for vertical movement
    private float h;  // Input for horizontal movement

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        UpdatePlayerPosition();
        UpdateAngleToFace();
        UpdateCameraPosition();
    }

    void UpdatePlayerPosition()
    {
        gameObject.transform.position = new Vector3(transform.position.x + (h * walkSpeed), transform.position.y, transform.position.z + (v * walkSpeed));
    }

    void UpdateAngleToFace()
    {
        float angleToFace = gameObject.transform.rotation.eulerAngles.y;

        // Up + left
        if (v > 0 && h < 0)         {angleToFace = 225;}
        // Up + right
        else if (v > 0 && h > 0)    {angleToFace = 315;}
        // Down + left
        else if (v < 0 && h < 0)    {angleToFace = 135;}
        // Down + right
        else if (v < 0 && h > 0)    {angleToFace = 45;}
        // Up
        else if (v > 0)             {angleToFace = 270;}
        // Down
        else if (v < 0)             {angleToFace = 90;}
        // Left
        else if (h < 0)             {angleToFace = 180;}
        // Right
        else if (h > 0)             {angleToFace = 0;}

        Quaternion rotation = Quaternion.Euler(0, angleToFace, 0);
        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed);
    }

    void UpdateCameraPosition()
    {
        camera.transform.position = new Vector3(camera.transform.position.x + (h * walkSpeed), camera.transform.position.y, camera.transform.position.z + (v * walkSpeed));
    }
}
