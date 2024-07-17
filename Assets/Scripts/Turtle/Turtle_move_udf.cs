using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class TurtleController : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public AudioClip swim;
    public AudioClip eatItem;
    private bool isSwimAudioPlaying = false;
    private AudioSource audioSource;
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
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = true;
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
            audioSource.PlayOneShot(eatItem);
            //AudioSource.PlayClipAtPoint(eatItem, Camera.main.transform.position);
        }

        bool isSwimming = IsAnimationPlaying("turtle_swim");
        if (isSwimming && !isSwimAudioPlaying) {
            audioSource.clip = swim;
            audioSource.Play();
            isSwimAudioPlaying = true;
        } else if (!isSwimming && isSwimAudioPlaying) {
            audioSource.Stop();
            isSwimAudioPlaying = false;
        }
    }

    bool IsAnimationPlaying (string animationName)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName);
    }
}
