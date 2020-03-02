using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVehicleMovement : MonoBehaviour
{
    public float movementSpeed = 400;//the speed of the car
    float currentSpeed;//the speed of car that modifiers will be applied to

    public float rotationSpeed = 2;//speed which teh car will turn at
    float h, v;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentSpeed = movementSpeed;
    }

    void Update()
    {
        //get the input from the user
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //use the horizontal input to rotate the player
        //note the negative h value to make rotate in the correct direction
        //try it with the - symbol to see the effect
        transform.Rotate(0, 0, -h * rotationSpeed);
    }

    private void FixedUpdate()
    {
        //transofrm.up is the forward direction of the game object in 2D
        //move the object in the forward direction by the current speed
        body.velocity = transform.up * v * currentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
