using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	private Animator anim;
	private bool derecha;
	public float speed;
	private float valor;
	private Rigidbody2D rb;
	public bool speedRun;
	public GameObject Luz;
	private bool activo;
	private Light intensidad;
	bool movimiento;
	public int contEnemy;
	private int contBateria;
	public Image imgBateria;
	public Sprite[] vecImagenes;
	public Image imgIpod;
	private bool escondido;
	public GameObject generador;
	private SpawnControler sc;
	public GameObject posicion1;
	public GameObject posicion2;
	public GameObject posicion3;

	void Start () {
		anim = this.GetComponent<Animator> (); //SE INICIALIZA EL ANIMATOR
		derecha = true;
		rb = this.GetComponent<Rigidbody2D> (); //SE INICIALIZA EL RIGIDBODY
		activo = false;
		intensidad = Luz.GetComponent<Light> (); //SE INICIALIZA LA LUZ DEL DIRECTIONAL LIGHT
		movimiento=false;
		contEnemy = 0;
		contBateria = vecImagenes.Length - 1;
		imgBateria.sprite = vecImagenes [contBateria];
		escondido = false;
		sc = generador.GetComponent<SpawnControler> ();
	}
	
	// Update is called once per frame
	void Update () {

		ActualizarLinterna ();


		//CONDICIÓN PARA MOVERSE HACIA LA IZQUIERDA
		if (Input.GetAxis ("Horizontal") < 0) {
			movimiento = true;
			if (derecha) {
				Girar ();
				derecha = false;
			}

			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
			anim.SetFloat ("Move", speed);
		}

		//CONDICIÓN PARA MOVERSE HACIA LA DERECHA
		if (Input.GetAxis ("Horizontal") > 0) {


			movimiento = true;
			if (!derecha) {
				Girar ();
				derecha = true;
			}


			anim.SetBool ("running", speedRun); 
			anim.SetFloat ("Move", speed);
			transform.Translate (new Vector3(speed * Time.deltaTime,0,0));

		}

		//CONDICIÓN PARA MANTENERSE EN REPOSO
		if (Input.GetAxis ("Horizontal") == 0) {
			movimiento = false;
			anim.SetFloat ("Move", 0); //SE MANTIENE EN REPOSO
			anim.SetBool("flash",false);
		}

		if (Input.GetKey(KeyCode.E)) {

			if (escondido) {
				Debug.Log ("SE ESCONDE!!");
				sc.killAll ();

			}
		}

		if (Input.GetKey (KeyCode.LeftShift) && movimiento) {

			//Debug.Log ("SE ESTA TOCANDO SHIFT IZQUIERDO");
			anim.SetBool ("running", true); //SE ACTIVA LA ANIMACIÓN DE CORRER
			//anim.SetFloat ("Move", speed);
			float v = speed * Time.deltaTime * 2;
			transform.Translate (Vector3.right * v);

		} else {
			anim.SetBool ("running", false); //SE APAGA LA ANIMACIÓN DE CORRER
		}

		if (Input.GetButtonDown ("Jump")) {

			imgIpod.GetComponent<Animator> ().SetTrigger ("IpodTrigger");
			anim.SetBool ("flash", true); //SE ACTIVA LA ANIMACIÓN DE LA HABILIDAD
			if (contBateria > 0) {

				DispararLinterna ();

				contBateria--;
				if (contBateria > -1) {
					imgBateria.sprite = vecImagenes[contBateria];


				}
			}
		}
	}
		

	void Girar(){

		var escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}

	//METODO PARA ACTUALIZAR EL VALOR DE DIRECTIONAL LIGHT
	void ActualizarLinterna(){
		if (activo)
			intensidad.intensity = intensidad.intensity - 0.005f;

		if (intensidad.intensity <= 0) {
			activo = false;
		}
	}

	//METODO PARA ACTIVAR EL DIRECTIONAL LIGHT
	public void DispararLinterna(){

		if (!activo) {
			
			intensidad.intensity = 0.75f;
			activo = true;


		}
			
	}

	void OnTriggerEnter2D(Collider2D objeto){

		if (objeto.gameObject.tag == "enemy") {
			//Debug.Log ("APARECIÓ UNA LACRA "+getContEnemy());
			contEnemy++; //SE SUMA UN ENEMIGO 
		}

		if (objeto.gameObject.tag == "escondite") {

			escondido = true;
		}

		if (objeto.gameObject.tag == "puerta") {
			//transform.position = posicion1.transform.position;
		}
	}

	void OnTriggerExit2D(Collider2D objeto){

		if (objeto.gameObject.tag == "escondite") {
			
			//Debug.Log ("SE SALIO DEL ESCONDITE");
			escondido = false;
		}

		if (objeto.gameObject.tag == "puerta") {
			escondido = false;
		}
	}

	public int getContEnemy(){
		return this.contEnemy;
	}


}
