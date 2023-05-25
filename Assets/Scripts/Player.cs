using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    [SerializeField] public int _health;
    public TextMeshProUGUI _healthText;
    public static bool _gameOver;
    private AudioSource _audioSource;
    public AudioClip _damagePlayerAudio;
    public GameObject ResultScreen;
    public GameObject HealthScreen;
    public GameObject HandMenu;
    private Player _player;



    void Start()
    {
        
        _gameOver = false;

        _audioSource = GetComponent<AudioSource>();
        HealthScreen.SetActive(true);
        ResultScreen.SetActive(false);
        HandMenu.SetActive(true); 
        Time.timeScale = 1;
        _player = FindObjectOfType<Player>();
        
    }

    void Update()
    {
        _healthText.text = "" + _health;

        if (_gameOver)
        {
            ResultScreen.SetActive(true);
            HealthScreen.SetActive(false); 
            HandMenu.SetActive(false);    
            Time.timeScale = 0;
            _player.transform.position = new Vector3(-6, 0, 1);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _gameOver = true;
            _health = 0;
            return;
        }

        HapticPulseUnity();

        _audioSource.PlayOneShot(_damagePlayerAudio);
    }

    public void IncreaseHealth(int healthAmount)
    {
        _health += healthAmount;
        if (_health >= 100)
            _health = 100;

        
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