using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZombieSpawn : MonoBehaviour
{
	public GameObject EnemyDere;
	public GameObject EnemyIzq;
	public float SpawnTime;
	private int AumentoSpawn = 0;
	private float AumentoVelocidad = 2.5f;
	private Zombie Z;

	private int Zombies = 10;
	private int ContZombies = 0;

	private int oleada = 1;
	public Text CajaOleada;


	void Update ()
	{
		SpawnTime -= Time.deltaTime;

		if (SpawnTime <= 0) {
			int Direccion = Random.Range (0, 2);
			if (ContZombies < Zombies){
				CajaOleada.text = "";	
				if (Direccion == 0){
					GameObject ZombieNuevo = Instantiate (EnemyDere);

					Z = ZombieNuevo.GetComponent<Zombie> ();
					Z.esZombie();
					ZombieNuevo.transform.localScale = new Vector3(3,3,0.5f);
					ZombieNuevo.transform.Translate (0, 3.3f, 0);
					AumentoSpawn += 5;
				}
				else{
					GameObject ZombieNuevo = Instantiate (EnemyIzq);

					Z = ZombieNuevo.GetComponent<Zombie> ();
					Z.esZombie();
					ZombieNuevo.transform.localScale = new Vector3(3,3,0.5f);
					ZombieNuevo.transform.Translate (0, 3.3f, 0);
					AumentoSpawn += 5;
				}
				if (AumentoSpawn < 15) {
					SpawnTime = 4;
				} else if(AumentoSpawn >= 15 && AumentoSpawn < 20) {
					SpawnTime = 3;
				} else if(AumentoSpawn >= 20 && AumentoSpawn < 25) {
					SpawnTime = 2;
				} else if(AumentoSpawn >= 25 && AumentoSpawn < 30) {
					SpawnTime = 1;
					AumentoVelocidad = 3;
				} else if(AumentoSpawn >= 30) {
					SpawnTime = 0.5f;
					AumentoVelocidad = 4;
				}
				ContZombies += 1;
			}
			else{
				ContZombies = 0;
				AumentoSpawn = 0;
				SpawnTime = 5;
				float aux = Mathf.Round(Zombies * 1.25f);
				Zombies = (int)aux;
				oleada += 1;
				CajaOleada.text = "Oleada: " + oleada;			
			}

		}
	}
}

