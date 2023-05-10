using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    public TextMeshProUGUI _healthText;
    public static bool _gameOver;
    public AudioClip _damagePlayerAudio;

    void Start()
    {
        _gameOver = false;
    }
    void Update()
    {
        _healthText.text = "" + _health;

        if (_gameOver)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void TakeDamage(int damage)
    {
        if (_health - damage <= 0)
        {
            _gameOver = true;
            return;
        }
        _health -= damage;
        HapticPulseUnity();
        GetComponent<AudioSource>().PlayOneShot(_damagePlayerAudio);
    }

    static void HapticPulseUnity()
    {
        Debug.Log("Haptic Unity");
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        HapticCapabilities capabilities;
        if (device.TryGetHapticCapabilities(out capabilities))
            if (capabilities.supportsImpulse)
                device.SendHapticImpulse(0, 0.5f, 1.0f);
        device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (device.TryGetHapticCapabilities(out capabilities))
            if (capabilities.supportsImpulse)
                device.SendHapticImpulse(0, 0.5f, 1.0f);
    }
}
