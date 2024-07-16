using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle_Inventory : MonoBehaviour
{
    public Canvas EndCanvas;
    private Turtle_Slot[] slots;
    private int maxSlots;
    private int currentSlots = 0;
    private bool isFull = false;

    public void AddItem(Turtle_Item turtleItem)
    {
        foreach (Turtle_Slot slot in slots) {
            if (slot.turtleItem == null) {
                slot.SetTurtleItem(turtleItem);
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
        slots = GetComponentsInChildren<Turtle_Slot>();
        maxSlots = slots.Length;
    }

    void Update() {
        if (isFull) {
            EndCanvas.gameObject.SetActive(true);
        }
    }
}
