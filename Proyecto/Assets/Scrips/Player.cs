using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


	public GameObject player;
	public GameObject DragonDere;
	public GameObject DragonIzq;
	private Zombie[] Z;
	
	
	private Animator anim;
	private Animator animDragonDere;
	private Animator animDragonIzq;


	private int Vida = 3;
	public GameObject[] Vidas;

	public Text CajaPuntos;
	public Text CajaCooldown;
	private int puntos = 0;


	private int framesTornado = 0;
	private int cooldownTornado = 0;

	private string miradaPlayer = "Dere";
	private bool ataque = false;
	//Para botones de movil
	private bool ataqueDere = false;
	private bool ataqueIzq = false;


	void Awake(){
		anim = GetComponent<Animator> ();
		animDragonDere = DragonDere.GetComponent<Animator> ();
		animDragonIzq = DragonIzq.GetComponent<Animator> ();
	}
		
	void FixedUpdate(){
		if (anim.GetBool ("AttackIzq") == true) {
			anim.SetBool ("AttackIzq", false);
		}
		if (anim.GetBool ("AttackDere") == true) {
			anim.SetBool ("AttackDere", false);
		}
		if (animDragonDere.GetBool ("AttackDragonDere") == true) {
			animDragonDere.SetBool ("AttackDragonDere", false);
		}
		if (animDragonIzq.GetBool ("AttackDragonIzq") == true) {
			animDragonIzq.SetBool ("AttackDragonIzq", false);
		}

	}

	void Update () {
		tornado ();

		//Controles Cadena
		if ((Input.GetKey(KeyCode.S)) && (miradaPlayer == "Dere")){
			animDragonDere.SetBool ("AttackDragonIzq" , true);
			ataque = true;
		}
		if ((Input.GetKey(KeyCode.S)) && (miradaPlayer == "Izq")){
			animDragonIzq.SetBool ("AttackDragonDere" , true);
			ataque = true;
		}

		//Controles katana	
		if (Input.GetKey(KeyCode.A) || ataqueIzq) {
			anim.SetBool ("AttackIzq", true);
			miradaPlayer = "Izq";
			ataque = true;
		}
		if (Input.GetKey(KeyCode.D) || ataqueDere) {
			anim.SetBool ("AttackDere", true);
			miradaPlayer = "Dere";
			ataque = true;
		}

		//Controles tornado
		if (anim.GetBool ("AttackTornado") == false && cooldownTornado <= 0){
			if (Input.GetKey(KeyCode.W)|| Input.acceleration.y > 0.3f) {
				anim.SetBool ("AttackTornado", true);
				ataque = true;
				framesTornado = 0;
				cooldownTornado = 1000;
			}	
		}

		ataqueDere = false;
		ataqueIzq = false;
	}

	private void cadena(){

		if (cooldownTornado != 0) {
			cooldownTornado = cooldownTornado - 1;
		} else {
			CajaCooldown.text = " ";
		}
		CajaCooldown.text = "" + cooldownTornado;		

		if (ataque &&  anim.GetBool ("AttackTornado") == true){
			if(framesTornado == 17){
				ataque = false;
				anim.SetBool ("AttackTornado", false);
			}
			else{
				framesTornado = framesTornado + 1;			
			}	
		}else{
			ataque = false;

		}

	}

	private void tornado (){
		//Ataque del tornado marcado por el culdaun y su tiempo de daño

		if (cooldownTornado != 0) {
			cooldownTornado = cooldownTornado - 1;
		} else {
			CajaCooldown.text = " ";
		}
		CajaCooldown.text = "" + cooldownTornado;		

		if (ataque &&  anim.GetBool ("AttackTornado") == true){
			if(framesTornado == 17){
				ataque = false;
				anim.SetBool ("AttackTornado", false);
			}
			else{
				framesTornado = framesTornado + 1;			
			}	
		}else{
			ataque = false;

		}
	}


	public void perderVida(){
		if (Vida == 1) {
			Destroy (Vidas[2]);
			muerte ();
		}
		else {
			if (Vida == 3) {
				Destroy (Vidas [0]);
			} else {
				Destroy (Vidas [1]);
			}
			Vida -= 1;
		}
	}

	public void BotonDere(){
		ataqueDere = true;
	}
	
	public void BotonIzq(){
		ataqueIzq = true;
	}


	public void muerte(){
		SceneManager.LoadScene("Muerte", LoadSceneMode.Single);
	}

	public void SumarPuntos (){
		puntos += 10;
		CajaPuntos.text = "Puntos: " + puntos;
	}
		
	public bool getAtaque(){
		return ataque;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.gameObject.tag == "Zombie") && (ataque)){
			
			Z = other.gameObject.GetComponents<Zombie> ();
			foreach(Zombie Zombi in Z){
				Zombi.MatarZombie ();
				Zombi.transform.Translate (0, -1f, 0);
				Destroy (other.gameObject, 3);
				SumarPuntos ();
			}


		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if ((other.gameObject.tag == "Zombie") && (ataque)){

			Z = other.gameObject.GetComponents<Zombie> ();
			foreach(Zombie Zombi in Z){
				Zombi.MatarZombie ();
				Zombi.transform.Translate (0, -1f, 0);
				Destroy (other.gameObject, 3);
				SumarPuntos ();
			}
		}
	}



}
