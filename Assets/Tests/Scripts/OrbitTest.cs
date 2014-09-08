using UnityEngine;
using System.Collections;

public class OrbitTest : MonoBehaviour
{

    public Transform pivot;
    public float speed = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = RotateAroundPoint(transform.position, pivot.transform.position, Vector3.up, speed * Time.deltaTime);
    }

    Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }

    Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Vector3 axis, float angle)
    {
        return Quaternion.Euler(axis * angle) * (point - pivot) + pivot;
    }

}
