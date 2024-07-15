using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turtle_ItemPickup : MonoBehaviour
{
    public Turtle_Item turtle_item;
    public GameObject interactionText;
    public InputAction PickupAction;
    public Canvas inventoryCanvas;
    bool isTurtleInRange = false;

    void Start()
    {
        interactionText.SetActive(false);
        PickupAction.Enable();
    }

    void Update()
    {
        if(isTurtleInRange && PickupAction.IsPressed()) {
            PickupItem();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<TurtleController>() != null) {
            interactionText.SetActive(true);
            isTurtleInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<TurtleController>() != null) {
            interactionText.SetActive(false);
            isTurtleInRange = false;
        }
    }

    void PickupItem()
    {
        Turtle_Inventory inventory = inventoryCanvas.GetComponent<Turtle_Inventory>();
        if (inventory != null) {
            Destroy(interactionText);
            Destroy(gameObject);
            inventory.AddItem(turtle_item);
        }
    }
}