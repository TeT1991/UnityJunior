using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubesRain
{
    public class CubesCreator : MonoBehaviour
    {
        [SerializeField] private Cube _prefab;

        public Cube CreateCube (Vector3 position)
        {
            Cube cube = Instantiate(_prefab, position, Quaternion.identity);
            cube.Reset();
            return cube;    
        }
    }
}

