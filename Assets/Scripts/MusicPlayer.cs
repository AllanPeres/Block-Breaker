using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance = null;

	void Awake() {
		Debug.Log ("Music Player Awake " + GetInstanceID());
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Music Player Start " + GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
