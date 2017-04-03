using UnityEngine;
using System.Collections;

public class MusicaController : MonoBehaviour {

	public AudioClip[] vecAudio; //VECTOR PARA ALMACENAR LAS PISTAS
	private AudioSource As; //AUDIO SOURCE

	public GameObject player;
	private Player p;

	int clip=0;

	void Start () {
		p = player.GetComponent<Player> ();
		As = this.GetComponent<AudioSource> (); //SE INICIALIZA EL AUDIOSOURCE
		As.clip = vecAudio [clip];
		As.Play ();
	}
	

	void Update () {

//		Debug.Log (p.getContEnemy ());
		//SI NO HAY ENEMIGOS, ENTONCES SUENA UNA PISTA
		//SI HAY ENEMIGOS, SE DETIENE ESA PISTA Y SE REPRODUCE LA SIGUIENTE
		//VALIDAR QUE SI LA PISTA QUE SUENA ESTA EN LA ÚLTIMA POSICION, SIGA REPRODUCIENDO

		if (!As.isPlaying) 
		{			
			As.Play ();
		}

		if (p.getContEnemy () == 0) 
		{
			clip = 0;
			As.clip = vecAudio [clip];
		}


		if (p.getContEnemy () > 0 && p.getContEnemy()<=3) 
		{
			clip = 1;
			As.clip = vecAudio [clip];
			  
		}
		if (p.getContEnemy () > 3) 
		{
			clip = 2;
			As.clip = vecAudio [clip];

		}

		Debug.Log ("enemigos " + p.getContEnemy ());
		
	}


}
