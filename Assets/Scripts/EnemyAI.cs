using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _minWalkableDistance;
    [SerializeField] private float _maxWalkableDistance;
    [SerializeField] private float _reachedPointDistance;
    [SerializeField] private GameObject _roamTarget;
    [SerializeField] private float _targetFollowRange;
    [SerializeField] private float _stopTargetFollovingRange;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private AIDestinationSetter _aiDestinationSetter;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private AIPath _aIPath;
    private Player _player;
    private EnemyStates _currentState;
    private Vector3 _roamPosition;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _currentState = EnemyStates.Roaming;
        _roamPosition = GenerateRoamPosition();
    }

    private void Update()
    {
        switch (_currentState)
        {
            case EnemyStates.Roaming:
                _roamTarget.transform.position = _roamPosition;

                if (Vector3.Distance(gameObject.transform.position, _roamPosition) <= _reachedPointDistance)
                {
                    _roamPosition = GenerateRoamPosition();
                }
                _aiDestinationSetter.target = _roamTarget.transform;
                TryFindPlayer();

                _enemyAnimator.IsWalking(true);
                _enemyAnimator.IsRunning(false);

                _aIPath.maxSpeed = 1;

                break;

            case EnemyStates.Warning:
               // _aIPath.canMove = false;
                _enemyAnimator.IsWalking(false);
                _enemyAnimator.IsRunning(false);
                _enemyAnimator.PlayFollow();


                _currentState = EnemyStates.Following;
                break;

            case EnemyStates.Following:
                _aiDestinationSetter.target = _player.transform;

                
               // _aIPath.canMove = true;
                _enemyAnimator.IsWalking(false);
                _enemyAnimator.IsRunning(true);

                _aIPath.maxSpeed = 2;

                
                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _enemyAttack.AttackRange)
                {
                    //_aIPath.canMove = false;
                    _enemyAnimator.IsWalking(false);
                    _enemyAnimator.IsRunning(false);

                    if (_enemyAttack.CanAttack)
                    {
                        _enemyAttack.TryAttackPlayer();

                        _enemyAnimator.PlayAttack();
                    }
                }

                //_aIPath.canMove = true;

                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) >= _stopTargetFollovingRange)
                {
                    _currentState = EnemyStates.Roaming;
                }
                break;
            
        }
    }

    private void TryFindPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= _targetFollowRange)
        {
            _currentState = EnemyStates.Warning;
        }
    }

    private Vector3 GenerateRoamPosition()
    {
        var roamPosition = gameObject.transform.position + GenerateRandomDirection() * GenerateRandomWalkableDistance();
        return roamPosition;
    }
    
    private float GenerateRandomWalkableDistance()
    {
        var randomDistance = Random.Range(_minWalkableDistance, _maxWalkableDistance);

        return randomDistance;
    }

    private Vector3 GenerateRandomDirection()
    {
        var newDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

        return newDirection.normalized;
    }
}

public enum EnemyStates
{
    Roaming,
    Following,
    Warning
}
