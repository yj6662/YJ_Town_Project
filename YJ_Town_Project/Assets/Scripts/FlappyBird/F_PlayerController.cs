using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class F_PlayerController : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    public bool isDead = false;
    float deathCoolDown = 0f;

    F_GameManager gameManager = null;

    bool isJumping = false;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = F_GameManager.Instance;
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCoolDown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Debug.Log("게임 재시작");
                    isDead = false;
                    animator.SetBool("IsDie", false);
                    _rigidbody.isKinematic = false;

                    gameManager.F_RestartGame();
                }
            }
            else
            {
                deathCoolDown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isJumping = true;
                animator.SetBool("IsMove", true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = moveSpeed;

        if (isJumping)
        {
            velocity.y = jumpForce;
            isJumping = false;
            animator.SetBool("IsMove", false);
        }
        
        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90f, 90f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Ground"))
        {
            isDead = true;
            animator.SetBool("IsDie", true);
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.isKinematic = true;
            deathCoolDown = 1f;
            gameManager.F_GameOver();
        }
    }
}

