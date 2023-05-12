using UnityEngine;

[RequireComponent (typeof(AlarmSystem))]
public class DoorController : MonoBehaviour
{
    private AlarmSystem _alarmSystem;

    private void Start()
    {
        _alarmSystem = GetComponent<AlarmSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out FirstPersonController player))
        {
            _alarmSystem.ActivateAlarm();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out FirstPersonController player))
        {
            _alarmSystem.DeactivateAlarm();
        }
    }
}
