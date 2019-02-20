using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector2 direction;

    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void GetInput()
    {
        Animator animator = GetComponent<Animator>();
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) {
            direction += Vector2.up;
            animator.Play("player_walk_up");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            animator.Play("player_walk_left");
            if (facingRight)
                Flip();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            animator.Play("player_walk_down");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            animator.Play("player_walk_left");
            if (!facingRight)
                Flip();
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        facingRight = !facingRight;
    }
}
