using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    // spawn game objects every 5 seconds
    // create a coroutine of type IEnumerator -- Yield Events
    // while loop
    IEnumerator SpawnEnemyRoutine() {
        while (_isSpawning) {
            // wait for 5 seconds
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
            
    }

    public void OnPlayerDeath() {
        _isSpawning = false;
    }
}
