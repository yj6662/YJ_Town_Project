using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class M_PlayerController : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    protected Animator animator;

    private Vector2 movementInput;
    private static readonly int isMove = Animator.StringToHash("IsMove");

    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    public void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
        movementInput = movementInput.normalized;
        if (animator != null)
        {
            animator.SetBool(isMove, movementInput != Vector2.zero);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movementInput.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody != null)
        {
            Vector2 moveDirection = new Vector2(movementInput.x, movementInput.y);
            _rigidbody.MovePosition(_rigidbody.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
