using UnityEngine;
using System.Collections;

public class SmoothMove : MonoBehaviour
{

    public Vector3 startPoint;
    public Vector3 endPoint;

    public bool lerp = true;


    // Update is called once per frame
    void Update()
    {
        if (lerp)
            Lerp();
        else
            Smooth();
    }

    void Lerp()
    {

    }

    void Smooth()
    {

    }
}
