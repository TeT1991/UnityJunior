using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubesRain
{
    [RequireComponent (typeof(GameObject))]
    public class ColorChanger : MonoBehaviour
    {
        private Material _material;
        private Cube _cube;

        private void Awake()
        {
            _cube = GetComponent<Cube>();
            _material = GetComponent<Renderer>().material; 
        }

        private void Start()
        {
            _cube.CollidedFirstTime += ChangeColor;
        }

        public void ChangeColor(Cube cube)
        {
            Color color = Random.ColorHSV();
            color.a = 1;
            _material.color = color;
        }

        public void ResetColor()
        {
            _material.color = Color.white;
        }
    }
}