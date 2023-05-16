using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _enemyHealth;
    public Slider _healthBar;
    public AudioClip _damageEnemyAudio;
    public AudioClip _deathEnemyAudio;
    [SerializeField] private GameObject _deathAnimation;
    [SerializeField] private GameObject[] _thingPrefabs;

    void Update()
    {
        _healthBar.value = _enemyHealth;
    }

    public void TakeDamage(int endamage)
    {
        _enemyHealth -= endamage;
        if (_enemyHealth <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(_damageEnemyAudio);
            _healthBar.gameObject.SetActive(false);
            Destroy(this.gameObject);
            Instantiate(_deathAnimation, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
            int randThing = Random.Range(0, _thingPrefabs.Length);
            Instantiate(_thingPrefabs[randThing], transform.position, Quaternion.identity);

        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(_deathEnemyAudio);
        }
    }
}
