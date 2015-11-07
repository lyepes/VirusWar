using UnityEngine;
using System.Collections;

public class BalaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject,5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * 10 * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") {
			Destroy(gameObject);
			other.gameObject.GetComponent<EnemyScript>().Hitted();

		}
	}
}
