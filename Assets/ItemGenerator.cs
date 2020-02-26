using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
	public GameObject CarPrefab;
	public GameObject CoinPrefab;
	public GameObject ConePrefab;
	private GameObject unitychan;
	private float originalPos;
	private float posRange = 3.4f;

	// Use this for initialization
	void Start () {
		this.unitychan = GameObject.Find ("unitychan");
		this.originalPos= unitychan.transform.position.z;
		itemgenerate ();
	}

	// Update is called once per frame
	void Update () {
		if (unitychan.transform.position.z - this.originalPos >= 15) {
			this.originalPos = unitychan.transform.position.z;
			itemgenerate ();
		}
	}

	void itemgenerate(){
		for (float i = unitychan.transform.position.z + 40; i <= unitychan.transform.position.z + 40; i += 15) {
			int num = Random.Range (1, 11);
			if (num <= 2) {
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject cone = Instantiate (ConePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {
				for (int j = -1; j <= 1; j++) {
					int item = Random.Range (1, 11);
					int offsetZ = Random.Range (-5, 6);
					if (1 <= item && item <= 6) {
						GameObject coin = Instantiate (CoinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
					} else if (7 <= item && item <= 9) {
						GameObject car = Instantiate (CarPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}
	}
}
		
