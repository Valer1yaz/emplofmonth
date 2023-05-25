using UnityEngine;

public class Mushrooms : MonoBehaviour
{
    [SerializeField] private GameObject _Animation;
    public Results _results;
    private void Start()
    {
        _results = FindObjectOfType<Results>();
    }

    public void MushActivate()
    {
        Destroy(this.gameObject);
        Instantiate(_Animation, transform.position, Quaternion.identity);
        _results.AddObject();
    }
}
