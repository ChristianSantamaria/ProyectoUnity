using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
	public bool ZombieDere;
	public bool ZombieIzq;
	public float VelocidadAtaque = 0;

	public bool Spawn = true;
	public Player Jugador;


	private bool AtaqueZombie;
	private Animator anim;
	private Vector3 posicion;
	private bool ZombieMuerte = false;


	void Awake(){
		anim = GetComponent<Animator> ();
	}
		

	void Start ()
	{
		anim.SetBool("Correr", true);	
	}
	

	void Update ()
	{
		if (!Spawn) {
			posicion = transform.position;

			if (ZombieDere) {
				if (posicion.x >= (-1.5) || ZombieMuerte) {
					anim.SetBool ("Correr", false);

					if (VelocidadAtaque != 0 && !ZombieMuerte) {
						VelocidadAtaque -= Time.deltaTime;
					}

					if (VelocidadAtaque <= 0 && !ZombieMuerte) {
						Jugador.perderVida ();
						VelocidadAtaque = 1;
					}

				} else {
					transform.Translate (Vector2.right * 5f * Time.deltaTime);
					transform.eulerAngles = new Vector2 (0, 0);
					float move = Input.GetAxis ("Horizontal");
					anim.SetFloat ("Velocidad", move);
				}	
			}
		
			
			if (ZombieIzq) {
				if (posicion.x <= (1.5) || ZombieMuerte) {
					anim.SetBool ("Correr", false);	

					if (VelocidadAtaque != 0 && !ZombieMuerte) {
						VelocidadAtaque -= Time.deltaTime;
					}
					if (VelocidadAtaque <= 0 && !ZombieMuerte) {
						Jugador.perderVida ();
						VelocidadAtaque = 1;
					}
				} else {
					transform.Translate (Vector2.left * 5f * Time.deltaTime);
					transform.eulerAngles = new Vector2 (0, 0);
					float move = Input.GetAxis ("Horizontal");
					anim.SetFloat ("Velocidad", move);
				}	
		

			}
		}
	}

	public void esZombie(){
		Spawn = false;
	}

	public void MatarZombie(){
		ZombieMuerte = true;
		anim.SetBool ("Muerte", true);
	}
		
}