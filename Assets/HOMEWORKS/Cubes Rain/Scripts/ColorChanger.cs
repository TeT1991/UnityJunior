using UnityEngine;

namespace CubesRain
{
    [RequireComponent (typeof(Cube))]
    public class ColorChanger : MonoBehaviour
    {
        private Material _material;
        private Cube _cube;

        private void Awake()
        {
            _cube = GetComponent<Cube>();
            _material = GetComponent<Renderer>().material; 
        }

        public void ChangeColor()
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