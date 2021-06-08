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
    public Transform line2;
    public Camera camera;
    [Range(-1f, 1f)] public float velocityMult;
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
            // gameObject.SetActive(false);
            velocity.x *= -1f;
        }

        if (pos.y > boundYMax - scale.y * 0.5f || pos.y < boundYMin + scale.y * 0.5f)
        {
            velocity.y *= -1f;
        }

        if (Input.GetKeyDown((KeyCode.S)))
        {
            line.position = line.TransformDirection(line.position.x, line.position.y - 1, 0);
        }
        if (Input.GetKeyDown((KeyCode.W)))
        {
            line.position = line.TransformDirection(line.position.x, line.position.y + 1, 0);
        }
        
        transformBall.position += velocity * velocityMult;

        var angle = -Input.GetAxisRaw("Horizontal") * Time.deltaTime * 30f;
        transformBall.rotation=Quaternion.Euler(Vector3.forward*Mathf.Atan(velocity.y/velocity.x)*Mathf.Rad2Deg);

        Debug.DrawLine(line.position, line.position + line.right * 5f, Color.red);
        Debug.DrawLine(line2.position, line2.position - line2.right * 5f, Color.blue);
        
    }

    private void OnTriggerEnter2D(Collider2D t)
    {
        Debug.LogError(t);
        var norm = t.transform.right;
        // velocity = transform.position.normalized.x > 0 ? -norm : norm;
        velocity += norm;
        velocity.Normalize();
        
    }
}