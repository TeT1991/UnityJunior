using System.Collections.Generic;
using UnityEngine;

namespace CodeStyleGenius
{
    public class ObjectsPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        private Queue<T> _pool = new Queue<T>();

        public T GetObject()
        {
           return _pool.Dequeue();
        }

        public void ReturnObject(T obj)
        {
            _pool.Enqueue(obj);
        }
    }
}