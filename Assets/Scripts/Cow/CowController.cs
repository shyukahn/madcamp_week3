using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CowController : MonoBehaviour
{
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
    }

    void FixedUpdate() 
    {
        Vector2 position = rigidbody2d.position + 4.0f * move * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    void LateUpdate() 
    {
        animator.SetFloat("Speed", move.magnitude);
        
        if (move.x != 0) {
            spriteRenderer.flipX = move.x > 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
