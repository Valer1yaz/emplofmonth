using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodScript : MonoBehaviour
{
    [SerializeField] private int _healthAmount;
    private Player _player;
    [SerializeField] private GameObject _Animation;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Healing);

    }

    public void Healing(ActivateEventArgs arg)
    {
        if (_player._health > 0)
        {
            _player.IncreaseHealth(_healthAmount);
            Destroy(this.gameObject);
            Instantiate(_Animation, transform.position, Quaternion.identity);
        }
    }
}
