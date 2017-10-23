using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoMuerte : MonoBehaviour {

	public Texture2D[] frames;
	private int fps = 35;

	void Update () {


		int index = (int)(Time.time * fps) % frames.Length;
		GetComponent<RawImage> ().texture = frames [index];

		if (Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene("Escena", LoadSceneMode.Single);
		}
	}
}
