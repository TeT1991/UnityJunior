using UnityEngine;

namespace CubesRain
{
    public class ObjectsCreator : MonoBehaviour
    {
        [SerializeField] private Cube _prefab;

        public Cube CreateObject(Vector3 position)
        {
            Cube obj = Instantiate(_prefab);
            obj.transform.position = position;

            return obj;
        }
    }
}

