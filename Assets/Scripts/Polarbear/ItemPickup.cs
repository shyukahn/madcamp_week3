using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    public GameObject interactionText;
    public InputAction PickupAction;
    bool isPlayerInRange = false;

    
    // Start is called before the first frame update
    void Start()
    {
        interactionText.SetActive(false);
        PickupAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && PickupAction.IsPressed()) {
            PickupItem();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.GetComponent<PlayerController>() != null) {
            interactionText.SetActive(true);
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<PlayerController>() != null) {
            interactionText.SetActive(false);
            isPlayerInRange = false;
        }
    }

    void PickupItem()
    {
        Destroy(interactionText);
        Destroy(gameObject);
        interactionText.SetActive(false);
    }
}
