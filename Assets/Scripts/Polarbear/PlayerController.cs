using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    public AudioClip walk;
    private bool isWalkAudioPlaying = false;

    Rigidbody2D rigidbody2d;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    Animator animator;
    AudioSource audioSource;

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }    
    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
    }

    void FixedUpdate() {
        Vector2 position = rigidbody2d.position + 3.0f * move * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    void LateUpdate() {
        animator.SetFloat("Speed", move.magnitude);

        if (move.x != 0) {
            spriteRenderer.flipX = move.x < 0;
        }
        bool isWalking = IsAnimationPlaying("Player_Run");
        if (isWalking && !isWalkAudioPlaying) {
            audioSource.clip = walk;
            audioSource.Play();
            isWalkAudioPlaying = true;
        } else if (!isWalking && isWalkAudioPlaying) {
            audioSource.Stop();
            isWalkAudioPlaying = false;
        }
    }
    bool IsAnimationPlaying (string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName);
    }
}
