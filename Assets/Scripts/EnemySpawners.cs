using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;

    [SerializeField] private float _spawnInterval;
    [SerializeField] private int _mixX;
    [SerializeField] private int _maxX;
    [SerializeField] private int _mixY;
    [SerializeField] private int _maxY;
    [SerializeField] private float _height;
    private float _currentSpawnTimer;
    
    
    private void Update()
    {
        _currentSpawnTimer += Time.deltaTime;
        if (_currentSpawnTimer >= _spawnInterval)
        {
            int randEnemy = UnityEngine.Random.Range(0, _enemyPrefabs.Length);
            var enemyInstance = Instantiate(_enemyPrefabs[randEnemy]);
            var newPosition = GenerateStartPosition();
            enemyInstance.transform.position = newPosition;
            _currentSpawnTimer = 0;
        }
    }

    private Vector3 GenerateStartPosition()
    {
        var startPos = new Vector3(Random.Range(_mixX, _maxX), _height, Random.Range(_mixY, _maxY));
        return startPos;
    }
}
