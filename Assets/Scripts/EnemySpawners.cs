using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;

    private float _spawnInterval;
    [SerializeField] private int _mixX;
    [SerializeField] private int _maxX;
    [SerializeField] private int _mixY;
    [SerializeField] private int _maxY;
    [SerializeField] private float _height;
    private float _currentSpawnTimer;
    private LevelState _levelState;

    public int _enemyCount = 5; 
    public int _enemyLimit; 

    private void Start()
    {
        int Level = SliderDifficulty._difficultyLevel;

        if (Level == 0)
            _levelState = LevelState.First;
        else if (Level == 1)
            _levelState = LevelState.Second;
        else
            _levelState = LevelState.Third;
        
        switch (_levelState)
        {
            case LevelState.First:
                _enemyLimit = 8;
                _spawnInterval = 60;
                break;

            case LevelState.Second:
                _enemyLimit = 13;
                _spawnInterval = 30;
                break;

            case LevelState.Third:
                _enemyLimit = 17;
                _spawnInterval = 30;
                break;
        }
    }

    private void Update()
    {
        
        _currentSpawnTimer += Time.deltaTime;
        if (_currentSpawnTimer >= _spawnInterval && _enemyCount < _enemyLimit)
        {
            int randEnemy = UnityEngine.Random.Range(0, _enemyPrefabs.Length);
            var enemyInstance = Instantiate(_enemyPrefabs[randEnemy]);
            var newPosition = GenerateStartPosition();
            enemyInstance.transform.position = newPosition;
            _currentSpawnTimer = 0;
            _enemyCount++;
            Debug.Log(_enemyCount);
        }
    }

    private Vector3 GenerateStartPosition()
    {
        var startPos = new Vector3(Random.Range(_mixX, _maxX), _height, Random.Range(_mixY, _maxY));
        return startPos;
    }
}

public enum LevelState
{
    First,
    Second,
    Third
}
