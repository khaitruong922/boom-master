using UnityEngine;
using UnityEngine.Events;

public class KeyDownEvent : MonoBehaviour
{
    [SerializeField] private KeyCode activeKey;
    [SerializeField] private bool callableWhilePausing = false;
    [SerializeField] private UnityEvent onKeyDown;
    private void Update()
    {
        if (Input.GetKeyDown(activeKey)) 
        if (callableWhilePausing || Time.timeScale > 0)
        onKeyDown?.Invoke();
    }
}
