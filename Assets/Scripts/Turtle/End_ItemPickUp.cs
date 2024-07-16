using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class End_ItemPickUp : MonoBehaviour
{
    public Turtle_Item turtle_item;
    public GameObject interactionText;
    public InputAction PickupAction;
    public Canvas endCanvas;
    bool isTurtleInRange = false;

    void Start()
    {
        interactionText.SetActive(false);
        PickupAction.Enable();
        endCanvas.gameObject.SetActive(false);
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
        Destroy(interactionText);
        Destroy(gameObject);
        endCanvas.gameObject.SetActive(true);
    }
}
