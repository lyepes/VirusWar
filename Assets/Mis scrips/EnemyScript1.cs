using UnityEngine;
using System.Collections;

public class EnemyScript1 : MonoBehaviour {

	private Transform myTransform;
	private string direccion;
	public int rang;
    public GameObject balas;
    public int energy;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
		myTransform = transform;
        InvokeRepeating("Disparar", 1, 1);
		int ranDireccion = Random.Range (0, 2);
		rang = ranDireccion;
        //ranDireccion = 0;
		if (ranDireccion == 0) {
			direccion = "baja";
		} else {
			direccion = "diagBaja";
		}
        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		if(direccion == "baja"){
			myTransform.position = new Vector3(myTransform.position.x + 6 * Time.deltaTime,myTransform.position.y - 6 * Time.deltaTime,myTransform.position.z);
		}
		if(direccion == "sube"){
            myTransform.position = new Vector3(myTransform.position.x + 6 * Time.deltaTime, myTransform.position.y + 6 * Time.deltaTime, myTransform.position.z);
		}
		if(direccion == "diagBaja"){
			myTransform.position = new Vector3(myTransform.position.x + (6 + 3) * Time.deltaTime,myTransform.position.y - 6 * Time.deltaTime,myTransform.position.z);
		}
		if(direccion == "diagSube"){
			myTransform.position = new Vector3(myTransform.position.x + (6 - 3) * Time.deltaTime,myTransform.position.y + 6 * Time.deltaTime,myTransform.position.z);
		}

	}

	void OnTriggerEnter(Collider other)
	{
        //Debug.Log("COLISION: " + other.gameObject.name);
		//if (other.gameObject.tag == "Piso") {
       if(other.gameObject.name == "pCube1"){
           Debug.Log("PISO: " + other.gameObject.name);
			if(direccion == "baja"){
			    direccion = "sube";
			}
			if(direccion == "diagBaja"){ 
				direccion=  "diagSube";
			}
		}
		//if (other.gameObject.tag == "Techo") {
       if (other.gameObject.name == "pCube6")
       {
           Debug.Log("TECHO: " + other.gameObject.name);
			if (direccion == "sube") {
				direccion = "baja";
			}
			if (direccion == "diagBaja") {
				direccion = "diagSube";
			}
		}

       if (other.gameObject.tag == "Bala")
       {
           Hitted();
       }

       if (other.gameObject.tag == "Nano")
       {
           Instantiate(explosion, transform.position, transform.rotation);
           Destroy(gameObject);
       }
	}

    public void Disparar()
    {
        //Instantiate crea objetos en el area(mundo)
        Instantiate(balas, transform.position, Quaternion.identity);
    }

    public void Hitted()
    {
        energy--;
        if (energy <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
