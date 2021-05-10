using System;
using UnityEngine;
using System.Collections;
using UnityEditor.UIElements;
using Random = UnityEngine.Random;

public class BallMove : MonoBehaviour
{
    public Vector3 velocity;
    public Transform transformBall;
    public Transform line;
    public Camera camera;
    [Range(-1f,1f)]public float velocityMult;
    private float boundXMin;
    private float boundXMax;

    private float boundYMin;
    private float boundYMax;
    private float boundLine;

    private void Awake()
    {
        var bound = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        boundXMax = bound.x;
        boundXMin = -boundXMax;
        boundYMax = bound.y;
        boundYMin = -boundYMax;
        
        velocity = Random.insideUnitCircle;
        Debug.Log($"{boundXMin} : {boundXMax}, {boundYMin} : {boundYMax}");
    }

    private void Update()
    {
        var pos = transformBall.position;
        var scale = transformBall.localScale;
        if (pos.x > boundXMax - scale.x || pos.x < boundXMin + scale.x)
        {
            velocity.x *= -1f;
        }

        if (pos.y > boundYMax - scale.y * 0.5f || pos.y < boundYMin + scale.y * 0.5f)
        {
            velocity.y *= -1f;
        }

        transformBall.position += velocity * velocityMult;

        var angle = -Input.GetAxisRaw("Horizontal") * Time.deltaTime * 30f;
        line.Rotate(Vector3.forward, angle);

        Debug.DrawLine(line.position, line.position + line.right * 5f,Color.red);
    }

    private void OnTriggerEnter2D(Collider2D t)
    {
        var norm = t.transform.right;
        velocity = norm;
    }
}