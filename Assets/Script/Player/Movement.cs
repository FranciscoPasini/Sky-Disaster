using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public float Speed { get => speed; set => speed = value; } // Agregamos propiedad para la velocidad
    private float timeToRevert = 3f;
    private Rigidbody2D playerRB;
    private Vector2 moveInput;
    private Animator animator;
    private float direction = 1f;
    private bool inverted = false;
    private float currentTime = 0f;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        if (moveX == 1)
        {
            animator.SetBool("Moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (moveX == -1)
        {
            animator.SetBool("Moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (moveX == 0)
        {
            animator.SetBool("Moving", false);
        }

        currentTime += Time.deltaTime;
        if (inverted && currentTime > timeToRevert)
        {
            RecoverDirection();
        }
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.fixedDeltaTime);
    }

    public void InvertDirection()
    {
        if (!inverted)
        {
            inverted = true;
            direction *= -1;
        }
        currentTime = 0;
    }

    void RecoverDirection()
    {
        direction *= -1;
        inverted = false;
    }
}
