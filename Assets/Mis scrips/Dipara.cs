using UnityEngine;
using System.Collections;

public class Dipara : MonoBehaviour {

	Transform balaPrefab; 
	public Rigidbody proyectil;
	public int velocidad;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1")){
							Rigidbody bala = (Rigidbody) Instantiate (proyectil, 
			                                          transform.position, 
			                                          Quaternion.identity);
			                                 /*	transform.position,
			                                    transform.rotation);*/
			//bala.AddForce(transform.forward * 8000);
			bala.velocity = transform.TransformDirection(new Vector3( 0, 0, velocidad ));
			Physics.IgnoreCollision(bala.GetComponent<Collider>(), 
			                        GetComponent<Collider>());
			//Destroy(bala);
		}
	}
}
