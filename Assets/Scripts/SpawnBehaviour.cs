using System.Collections;
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
    [SerializeField]
    private float _spawnRateEnemy = 1.5f;
   
    void Start()
    {
        StartCoroutine(SpawnEnemy());
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

    IEnumerator SpawnEnemy()
    {
        while (_isPlayerAlive)
        {
            var newEnemy = Instantiate(Enemy);
            newEnemy.transform.parent = EnemyContainer.transform;
            yield return new WaitForSeconds(_spawnRateEnemy);
        }
    }

    internal void IncreaseSpawnRate(float increaseValue)
    {
        if(_spawnRateEnemy > 1f)
        {
            _spawnRateEnemy -= increaseValue;
        }
    }

    public void IsPlayerAlive(bool playerAlive) => _isPlayerAlive = playerAlive;
}
