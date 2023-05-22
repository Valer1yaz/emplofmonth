using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodScript : MonoBehaviour
{
    [SerializeField] private int _healthAmount;
    private Player _player;
    [SerializeField] private GameObject _Animation;


    void Update()
    {
        /*var device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out var triggerValue) && triggerValue && !isPressed)
        {
            if (player._health >= 0)
            {
                player.IncreaseHealth(_healthAmount);
                Destroy(this.gameObject);
                Instantiate(_Animation, transform.position, Quaternion.identity);
            }
            isPressed = true;
        }
        else if (!triggerValue)
        {
            isPressed = false;
        }*/
    }

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
