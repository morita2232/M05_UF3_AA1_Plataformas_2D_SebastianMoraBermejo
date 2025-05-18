using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;
    private bool active = false;
    private bool goingToB = true;

    void Update()
    {
        if (!active) return;

        Vector3 target = goingToB ? pointB : pointA;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            goingToB = !goingToB;
        }
    }

    public void ActivatePlatform()
    {
        active = true;
    }
}

