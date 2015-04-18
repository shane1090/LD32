using UnityEngine;
using System.Collections;

public class BallCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Enemy") {
			EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth> ();

			if (enemyHealth != null) {
				enemyHealth.TakeDamage();
			}
		}
	}
}
