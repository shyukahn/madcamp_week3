using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CowController : MonoBehaviour
{
    public InputAction MoveAction;
    public GameObject profitText;
    public GameObject profitAddText;
    public Canvas endCanvas;
    public GameObject gameManager;
    public AudioClip itemGetClip;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    Animator animator;
    int profit = 0;
    bool isClear = false;
    AudioSource audioSource;
    IEnumerator AnimateText(TextMeshProUGUI textAdd)
    {
        textAdd.fontSize = 60;
        yield return new WaitForSeconds(0.1f);
        textAdd.fontSize = 50;
        yield break;
    }
    void ShowEndScreen()
    {
        endCanvas.gameObject.SetActive(true);
        MoveAction.Disable();
        gameManager.SetActive(false);
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
        if (isClear)
        {
            ShowEndScreen();
            isClear = false;
        }
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
    void OnTriggerEnter2D(Collider2D other)
    {
        FoodItem foodItem = other.GetComponent<FoodItem>();
        if (foodItem != null)
        {
            audioSource.PlayOneShot(itemGetClip);
            profit += foodItem.cost;
            profitText.GetComponent<TextMeshProUGUI>().text = $"$ {profit}";
            TextMeshProUGUI textAdd = profitAddText.GetComponent<TextMeshProUGUI>();
            textAdd.text = $"+ ${foodItem.cost}";
            StartCoroutine(AnimateText(textAdd));
            Destroy(other.gameObject);
            if (profit >= 100)
            {
                isClear = true;
            }
        }
    }
}
