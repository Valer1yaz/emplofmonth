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
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(_deathEnemyAudio);
        }
        

    }
}
