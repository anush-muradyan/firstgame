using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Follow:MonoBehaviour
    {
        public Transform followObject;
        private void Update()
        {
            var pos = transform.position;
            var fromY = pos.y;
            var toY = followObject.transform.position.y;
            var value = Mathf.Lerp(fromY, toY, Time.deltaTime * 2f);
            pos.y = value;
            transform.position = pos;
        }
    }
}