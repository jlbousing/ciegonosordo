using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnControler : MonoBehaviour {

	public Player player;
	public GameObject[] obj; //VECTOR PARA ALMACENAR LOS GameObjects
	private List<GameObject> listaEnemigos;
	public float distanciaInvoke;
	private float decision;
	private Vector3 posicionEnemigo;
	public float tiempoMin;
	public float tiempoMax;
	private float contTime = 0f;


	void Start () {
		listaEnemigos = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (contTime >= 15) 
		{
			Generar ();
			contTime = 0;

		}

		contTime += Time.deltaTime;
	}

	void Generar(){
		//SE SIGUE AL PERSONAJE
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);

		decision = Mathf.Floor(Random.value * 100f);
		GameObject objeto=null;



		if (decision < 50) {
			//Debug.Log ("La decision es " + decision);
			//INVOCA A LA IZQUIERDA
			int index=Random.Range(0,obj.Length);
			posicionEnemigo = new Vector3 (player.transform.position.x - 20, player.transform.position.y, player.transform.position.z);
			objeto = (GameObject)Instantiate (obj[index],posicionEnemigo,Quaternion.identity);
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
			//Debug.Log ("SE GENERO A LA IZQUIERDA");


		} else if (decision > 50) {

			//INVOCAR A LA DERECHA
			posicionEnemigo = new Vector3 (player.transform.position.x + 20, player.transform.position.y, player.transform.position.z);
			objeto = (GameObject)Instantiate (obj[Random.Range(0,obj.Length)],posicionEnemigo,Quaternion.identity);
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
			//Debug.Log ("SE GENERO A LA DERECHA");
		}

		listaEnemigos.Add (objeto); 
	}


	public void killAll()
	{
		//Debug.Log ("killall");
		foreach (GameObject gameO in listaEnemigos) {
			Destroy (gameO.gameObject);
		}
		listaEnemigos.Clear();
	}


}
