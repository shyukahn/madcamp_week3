using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    public Item item;    
    public GameObject interactionText;
    public InputAction PickupAction;
    public Canvas inventoryCanvas;
    bool isPlayerInRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        interactionText.SetActive(false);
        PickupAction.Enable();
        GetComponent<SpriteRenderer>().sprite = item.itemImage;
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
        Inventory inventory = inventoryCanvas.GetComponent<Inventory>();
        if (inventory != null) {
            Destroy(interactionText);
            Destroy(gameObject);
            inventory.AddItem(item);
        }
    }
}
