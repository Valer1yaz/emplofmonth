using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
	[SerializeField] private Animator _animator = null;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			_animator.Play("DoorOp", 0, 0.0f);
		}
		else if (other.CompareTag("Enemy"))
		{
			_animator.Play("DoorOp", 0, 0.0f);
		}
	}
}