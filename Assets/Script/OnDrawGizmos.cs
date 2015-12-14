using UnityEngine;
using System.Collections;

public class OnDrawGizmos : MonoBehaviour {

	void OnDrawGizmosYellow()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawCube(transform.position, new Vector3(1,1,1));
	}
}
