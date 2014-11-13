using UnityEngine;
using System.Collections;

public class NavMeshMoveRandomly : MonoBehaviour {

    NavMeshAgent navMesh;

	// Use this for initialization
    void Start()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
    void Update()
    {

    }
}
