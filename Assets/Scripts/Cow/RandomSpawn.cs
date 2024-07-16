using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject rangeObject;
    public GameObject cereal1;
    public GameObject cereal2;
    public GameObject cereal3;
    public GameObject cereal4;
    public GameObject cereal5;
    BoxCollider2D rangeCollider;
    GameObject[] cereals;
    float spawnInterval = 1.0f;
    float destroyInterval = 3.0f;
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
    IEnumerator SpawnCereal()
    {
        GameObject instantFood = Instantiate(cereals[Random.Range(0, 5)], ReturnRandomPosition(), Quaternion.identity);
        yield return new WaitForSeconds(destroyInterval);
        Destroy(instantFood);
    }
    IEnumerator RandomSpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            StartCoroutine(SpawnCereal());
        }
    }
    void Awake() {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
        cereals = new GameObject[5]{cereal1, cereal2, cereal3, cereal4, cereal5};
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
