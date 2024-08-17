using UnityEngine;

[RequireComponent(typeof(ClickHandler))]
public class Destroyer : MonoBehaviour
{
    private ClickHandler _clickHandler;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _clickHandler = GetComponent<ClickHandler>();
        _clickHandler.Clicked.AddListener(DestroyCube);
    }

    private void DestroyCube()
    {
        Destroy(gameObject);
    }
}
