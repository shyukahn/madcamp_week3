using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject rangeObject;
    public GameObject foodItem;
    BoxCollider2D rangeCollider;
    Vector2 ReturnRandomPosition()
    {
        Vector2 originPosition = rangeObject.transform.position;
        float rangeX = rangeCollider.bounds.size.x;
        float rangeY = rangeCollider.bounds.size.y;

        rangeX = Random.Range(-(rangeX / 2.0f), rangeX / 2.0f);
        rangeY = Random.Range(-(rangeY / 2.0f), rangeY / 2.0f);
        Vector2 randomPosition = new Vector2(rangeX, rangeY);

        Vector2 spawnPosition = originPosition + randomPosition;
        return spawnPosition;
    }
    IEnumerator RandomSpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            GameObject instantFood = Instantiate(foodItem, ReturnRandomPosition(), Quaternion.identity);
        }
    }
    void Awake() {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomSpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
