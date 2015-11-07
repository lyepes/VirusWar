using UnityEngine;
using System.Collections;

public class Escenario : MonoBehaviour {

	public int speed = 6;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,45);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += transform.forward * 1 * Time.deltaTime;
		transform.position = new Vector3(transform.position.x + speed * Time.deltaTime ,transform.position.y,transform.position.z);
	}
}
