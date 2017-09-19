using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelMananager;

	void Start() {
		levelMananager = GameObject.FindObjectOfType<LevelManager>();
	}


	void OnTriggerEnter2D (Collider2D trigger) {
		Brick.breakableCount = 0;
		levelMananager.LoadLevel("Lose");
	}

}
