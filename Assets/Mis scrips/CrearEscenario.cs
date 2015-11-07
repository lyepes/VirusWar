using UnityEngine;
using System.Collections;

public class CrearEscenario : MonoBehaviour {
	public GameObject Escenario;
    public int MaxEnemy = 10;

	// Use this for initialization
	void Start () {
		Generar ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Generar(){
        if (MaxEnemy >= 0)
        {
            MaxEnemy = MaxEnemy - 1;
            Instantiate(Escenario, transform.position, transform.rotation);
            InvokeRepeating("Generar", 30, 30);//42
        }      
	}
}
