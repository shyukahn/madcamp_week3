using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Turtle_Slot : MonoBehaviour
{
    public Turtle_Item turtleItem;
    public Image itemImage;

    public void SetTurtleItem(Turtle_Item newItem)
    {
        turtleItem = newItem;
        itemImage.sprite = newItem.itemImage;
        itemImage.gameObject.SetActive(true);
        Debug.Log("Slot SetItem");
    }
}
