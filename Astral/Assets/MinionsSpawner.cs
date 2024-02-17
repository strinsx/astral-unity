using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsSpawner : MonoBehaviour
{   
    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f,5), Random.Range(-6f,6f),0), Quaternion.identity);
        newEnemy.tag = "EnemyCollide";
        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
