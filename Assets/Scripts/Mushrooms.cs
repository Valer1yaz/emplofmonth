using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mushrooms : MonoBehaviour
{
    [SerializeField] private GameObject _Animation;
    public Results _results;
    private void Start()
    {
        _results = FindObjectOfType<Results>();
        var grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(_ => gameObject.SetActive(false));
        grabInteractable.selectExited.AddListener(_ => gameObject.SetActive(false));
        Instantiate(_Animation, transform.position, Quaternion.identity);
        //_results.AddObject();
    }
}
