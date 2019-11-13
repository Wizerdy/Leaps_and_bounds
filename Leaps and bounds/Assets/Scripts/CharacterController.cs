using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Vector2 _speed;
    public float _dashSpeed;
    public float _rollSpeed;
    public float _dashTime;

    private Rigidbody2D _rgBd;
    private bool _dashing;

    void Start()
    {
        _rgBd = GetComponent<Rigidbody2D>();
        _dashing = false;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !_dashing && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
                StartCoroutine(Dash(_dashTime, new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), _dashSpeed));
            else if (Input.GetKeyDown(KeyCode.Space) && !_dashing && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
                StartCoroutine(Dash(_dashTime, new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), _rollSpeed));
            else if (!_dashing)
                _rgBd.velocity = new Vector2(
                    Input.GetAxisRaw("Horizontal") * _speed.x * Time.deltaTime,
                    Input.GetAxisRaw("Vertical") * _speed.y * Time.deltaTime);
        }

    }

    IEnumerator Dash(float time, Vector2 direction, float speed)
    {
        _dashing = true;
        for (int i = 0; i < 10; i++)
        {
            _rgBd.velocity = new Vector2(speed * Time.deltaTime * direction.x, speed * Time.deltaTime * direction.y);
            yield return new WaitForSeconds(time / 10);
        }
        _rgBd.velocity = new Vector2(0, 0);
        _dashing = false;
    }
}
