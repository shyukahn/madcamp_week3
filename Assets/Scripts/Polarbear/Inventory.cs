using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Canvas EndCanvas;
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
    
    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        maxSlots = slots.Length;
    }

    void Update() {
        if (isFull) {
            EndCanvas.gameObject.SetActive(true);
        }
    }
}
