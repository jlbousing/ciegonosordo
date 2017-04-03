using UnityEngine;
using System.Collections;

public class EnemyVolador : MonoBehaviour {


	float amplitudX = 8f;
	float amplitudY=6f;
	float omegaX=1f;
	float omegaY=5f;
	float index;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		index += Time.deltaTime;
		float x = amplitudX * Mathf.Cos (omegaX * index);
		float y= Mathf.Abs(amplitudY*Mathf.Sin(omegaY*index));
		transform.localPosition = new Vector3 (x, y, 0);
	}
}
