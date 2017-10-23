using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragones : MonoBehaviour {

	public Player jugador;
	private Zombie[] Z;

	void Start(){
		jugador = jugador.GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.gameObject.tag == "Zombie") && (jugador.getAtaque())){
			Z = other.gameObject.GetComponents<Zombie> ();
			foreach(Zombie Zombi in Z){
				Zombi.MatarZombie ();
				Destroy (other.gameObject, 4);
				jugador.SumarPuntos ();
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if ((other.gameObject.tag == "Zombie") && (jugador.getAtaque())){
			Z = other.gameObject.GetComponents<Zombie> ();
			foreach(Zombie Zombi in Z){
				Zombi.MatarZombie ();
				Destroy (other.gameObject, 4);
				jugador.SumarPuntos ();
			}
		}
	}
}
