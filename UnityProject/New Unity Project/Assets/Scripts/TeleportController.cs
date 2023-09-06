using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportController : MonoBehaviour
{
    public GameObject baseControllerGameObject;
    public GameObject teleportationGameObject;

    public InputActionReference teleportActivationReference;

    [Space]
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancle;

    private void Start()
    {
        teleportActivationReference.action.performed += TeleportModeActivate;
        teleportActivationReference.action.canceled += TeleportModeCancle;

    }

    private void TeleportModeCancle(InputAction.CallbackContext obj)
    {
        Invoke("DeactivateTeleporter", .1f);
    }

    void DeactivateTeleporter() => onTeleportCancle.Invoke();

    private void TeleportModeActivate(InputAction.CallbackContext obj) => onTeleportActivate.Invoke();


}
