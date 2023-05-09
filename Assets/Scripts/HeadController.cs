using System;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigitbody;
    [SerializeField] private float _power;
    private const string WEAPON_TAG = "Weapon";

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(WEAPON_TAG))
        {
            return;
        }

        _rigitbody.isKinematic = false;
        _rigitbody.AddForce(Vector3.up * _power);
    }
}
