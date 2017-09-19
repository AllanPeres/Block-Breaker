using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip creck;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHits = 0;
	private LevelManager levelManager;
	private bool isBreakable;


	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(creck, transform.position, 0.3f);
		if (isBreakable){
			HandleHits();
		}
	}

	void HandleHits() {
		int maxHits = hitSprites.Length + 1;
		timesHits++;
		if (timesHits >= maxHits) {
			breakableCount--;
			if (levelManager.BrickDestroyed()) {
				Brick.breakableCount = 0;
			}
			GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites() {
		int spriteIndex = timesHits - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} 
	}
}
