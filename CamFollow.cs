using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    public float SmoothSpeed = 0.12f;
    public Vector3 offset;
    private void LateUpdate()
    {
        Vector3 postiondesire = target.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position,postiondesire,SmoothSpeed);
        transform.position = smoothposition;
    }
}
