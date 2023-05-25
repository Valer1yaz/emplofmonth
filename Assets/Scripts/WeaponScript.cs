using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] public int _damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(_damageAmount);
        }
        else if (other.tag == "Mushrooms")
        {
            other.GetComponent<Mushrooms>().MushActivate();
        }
    }
}
