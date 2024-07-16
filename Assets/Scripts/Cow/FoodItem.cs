using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public int cost;
    void Awake() {
        cost = Random.Range(3, 6);
    }
}
