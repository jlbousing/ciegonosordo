using UnityEngine;
using System.Collections;

public class EnemigoControl : MonoBehaviour {

	public GameObject player;
	public float speed;
	private bool giro;

	void Start () {
		giro = false;
	}

	// Update is called once per frame
	void FixedUpdate () {




		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (this.transform.position, player.transform.position, step);

		if(player.transform.position.x < this.transform.position.x){
			//SE MUEVE HACIA LA DERECHA
			if (!giro) {
				Girar ();
				giro = true;
			}
		}
	
	}

	void OnCollisionEnter2D(Collision2D objeto){

		if (objeto.gameObject.tag == "Player") {

			//Debug.Log ("MATO AL PERSONAJE");
		}
	}

	void Girar(){

		var escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}
}
