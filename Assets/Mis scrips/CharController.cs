using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharController : MonoBehaviour {

	public int vidas;
	private Transform myTransform;
	//public CharacterController charC;
	public Text textoDeVidas;
	public GameObject balas;
	//float speed = 10;
	public Image barraVida;
	public int maxEnergy;
    public AudioClip[] sonidos;
    public AudioSource audio;


	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

		float porcentajeEnergia = vidas * 0.1f / maxEnergy * 0.1f;
		barraVida.GetComponent<RectTransform> ().localScale = new Vector3(porcentajeEnergia,1,1);


		if (Time.timeScale == 0) {
			return;
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			//charC.Move(-myTransform.forward);
			myTransform.position = new Vector3(myTransform.position.x,myTransform.position.y + 0.4f,myTransform.position.z);
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
		//	charC.Move(myTransform.forward);
			myTransform.position = new Vector3(myTransform.position.x,myTransform.position.y - 0.4f,myTransform.position.z);
		}

		/*if (Input.GetKey (KeyCode.LeftArrow)) {
			myTransform.position -= myTransform.forward;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			myTransform.position += myTransform.forward;
		}*/

       
		if (Input.GetMouseButtonDown(0)) {
			Disparar();
		}
	
	}

	public void Disparar()
	{
		//Instantiate crea objetos en el area(mundo)
        audio.clip = sonidos[0];
        audio.Play();
		Instantiate (balas, myTransform.position, myTransform.rotation);
	}

	public void Hitted()
	{
		vidas = vidas - 1;

		textoDeVidas.text = "Vidas: " + vidas;
		if (vidas<=0) {
			//Destroy(gameObject);
			Application.LoadLevel(1);
		}
	}

    void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.name == "pCube4" || other.gameObject.name == "pCube11" || other.gameObject.name == "pCube12" ||
            other.gameObject.name == "pCube13" || other.gameObject.name == "pCube14" || other.gameObject.name == "pCube15" ||
            other.gameObject.name == "pCube16" || other.gameObject.name == "pCube17")
        {
            Hitted();
            Destroy(other.gameObject);           
        }
        if (other.gameObject.tag == "Enemy")
        {
            Hitted();                       
        }
    }



}
