using UnityEngine;
using System.Collections;

public class CamaraController : MonoBehaviour {

	public GameObject jugador;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (jugador.transform.position.x, jugador.transform.position.y, -10);
	}
}
