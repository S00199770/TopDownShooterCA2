using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnFootMovement : MonoBehaviour
{
    public float movementSpeed = 10;
    Vector3 mousePosition;

    float h, v;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        transform.up = direction;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(h, v) * movementSpeed * Time.deltaTime;
    }
}

