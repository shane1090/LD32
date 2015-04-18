using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public bool hit;

	AudioSource enemyAudio;
	Renderer renderer;

	void Awake () {
		enemyAudio = GetComponent<AudioSource> ();
		renderer = GetComponent<Renderer> ();
		hit = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage() {
		if (hit)
			return;

		renderer.material.color = Color.red;
		enemyAudio.Play ();

	}
}
