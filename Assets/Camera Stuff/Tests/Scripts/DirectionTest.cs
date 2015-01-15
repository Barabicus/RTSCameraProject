using UnityEngine;
using System.Collections;

public class DirectionTest : MonoBehaviour {

    public Transform follow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        Debug.Log((follow.position - transform.position).normalized);
        transform.position += (follow.position - transform.position).normalized * 2f * Time.deltaTime;
    }
}
