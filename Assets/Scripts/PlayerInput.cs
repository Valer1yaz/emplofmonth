using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private const string GRIP = "Grip";
    private const string TRIGGER = "Trigger";
    [SerializeField] private Animator _animator;

    [SerializeField] private InputActionProperty _gripAction;
    [SerializeField] private InputActionProperty _activateAction;

    private void Update()
    {
        var gripValue = _gripAction.action.ReadValue<float>();
        var actionValue = _activateAction.action.ReadValue<float>();

        _animator.SetFloat(GRIP, gripValue);
        _animator.SetFloat(TRIGGER, gripValue);
    }
}
