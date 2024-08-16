using UnityEngine;

[RequireComponent(typeof(ClickHandler))]
public class Destroyer : MonoBehaviour
{
    private ClickHandler clickHandler;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        clickHandler = GetComponent<ClickHandler>();
        clickHandler.Clicked.AddListener(DestroyCube);
    }

    private void DestroyCube()
    {
        Destroy(gameObject);
    }
}
