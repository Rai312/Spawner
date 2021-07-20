using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elapsedTime = 0;
    private int currentNumberPoints = 0;

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                if (currentNumberPoints < _spawnPoints.Length)
                {
                    _elapsedTime = 0;

                    SetEnemy(enemy, _spawnPoints[currentNumberPoints].position);

                    currentNumberPoints++;
                }
                else
                {
                    currentNumberPoints = 0;
                }
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
