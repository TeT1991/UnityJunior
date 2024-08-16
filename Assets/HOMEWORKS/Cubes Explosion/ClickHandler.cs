using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    public UnityEvent Clicked;

    private void OnMouseDown()
    {
        Clicked?.Invoke();
    }

    private void OnDestroy()
    {
        Clicked.RemoveAllListeners();
    }
}
