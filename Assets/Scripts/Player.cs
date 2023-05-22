using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public int _health;
    public TextMeshProUGUI _healthText;
    public static bool _gameOver;
    private AudioSource _audioSource;
    public AudioClip _damagePlayerAudio;

    void Start()
    {
        _gameOver = false;

        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        _healthText.text = "" + _health;

        if (_gameOver)
        {
            SceneManager.LoadScene("Results");
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

        _audioSource.PlayOneShot(_damagePlayerAudio);
    }

    public void IncreaseHealth(int healthAmount)
    {
        if (_health + healthAmount >= 100)
        {
            _health = 100;
        }
        else
        {
            _health += healthAmount;
        }
        
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