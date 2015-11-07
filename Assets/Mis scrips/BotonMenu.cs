using UnityEngine;
using System.Collections;

public class BotonMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Jugar(){
		Application.LoadLevel(1); //se puede cambiar por el numero de la escena de file-builsetting 		
	}
}
