using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float _speed;

    private Rigidbody2D _rgBd;

    void Start()
    {
        _rgBd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            _rgBd.velocity = new Vector2(
                Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 
                Input.GetAxis("Vertical") * _speed * Time.deltaTime);
    }
}
