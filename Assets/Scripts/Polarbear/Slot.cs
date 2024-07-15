using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public Image itemImage;

    public void SetItem(Item _item)
    {
        item = _item;
        itemImage.sprite = _item.itemImage;
        itemImage.gameObject.SetActive(true);
    }
}
