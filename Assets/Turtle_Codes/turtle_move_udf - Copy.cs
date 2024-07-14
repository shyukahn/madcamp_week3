using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class turtle_move_udf : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    public KeyCode key = KeyCode.E;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        float speedMultiplier = 4.0f;
        Vector2 nextVec = inputVec * speed * speedMultiplier * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate() 
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0;
        }

        if (Input.GetKeyDown(key)) {
            anim.SetTrigger("Eat");
        }
    }
}
