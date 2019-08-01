using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject TripleShotPowerUp;
    public GameObject SpeedBoostPowerUp;
    public GameObject ShieldPowerUp;
    public GameObject PowerUpContainer;
    public GameObject EnemyContainer;
    public GameObject[] powerUps;
    private bool _isPlayerAlive = true;
   
    void Start()
    {
        StartCoroutine(SpawnEnemy(1.5f));
        StartCoroutine(SpawnRandomPowerUp(Random.Range(20,30)));
    }

    IEnumerator SpawnRandomPowerUp(float waitTime)
    {
        while (_isPlayerAlive)
        {
            var randomPowerUp = Instantiate(powerUps[Random.Range(0, 3)]);
            randomPowerUp.transform.parent = PowerUpContainer.transform;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator SpawnEnemy(float waitTime)
    {
        while (_isPlayerAlive)
        {
            var newEnemy = Instantiate(Enemy);
            newEnemy.transform.parent = EnemyContainer.transform;
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void IsPlayerAlive(bool playerAlive) => _isPlayerAlive = playerAlive;
}
