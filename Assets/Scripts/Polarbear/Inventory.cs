using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Canvas endCanvas;
    public GameObject player;
    private Slot[] slots;
    private int maxSlots;
    private int currentSlots = 0;
    private bool isFull = false;

    public void AddItem(Item _item)
    {
        foreach (Slot slot in slots) {
            if (slot.item == null) {
                slot.SetItem(_item);
                currentSlots++;
                if (currentSlots == maxSlots) {
                    isFull = true;
                }
                return;
            }
        }
    }

    void ShowEndScreen()
    {
        endCanvas.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().MoveAction.Disable();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        maxSlots = slots.Length;
    }

    void Update() {
        if (isFull) {
            ShowEndScreen();
            // prevent [ShowEndScreen] from being called again
            isFull = false;
        }
    }
}
