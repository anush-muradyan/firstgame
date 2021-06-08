using System;
using UnityEngine;
namespace DefaultNamespace
{
    public class GameOver:MonoBehaviour
    {
        public Transform bound;
        public Transform bound2;
        private void Update()
        {
            // if (transform.position.x < bound.localPosition.x || -transform.position.x > bound2.localPosition.x)
            // {
            //     gameObject.SetActive(false);
            // }
        }

   
        /*private void OnTriggerEnter2D(Collider2D t)
        {
            if (t.bounds.min.x <= bound.localPosition.x)
            {
                gameObject.SetActive(false);
            }
        }*/
    }
}