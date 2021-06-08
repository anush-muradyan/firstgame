using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInput : MonoBehaviour
    {
        public Transform line;
        public void Update()
        {
            float v = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * 7f * v * Time.deltaTime);
            
        }

        private void OnMouseUp()
        {
            Debug.LogError(gameObject);
        }
    }

}