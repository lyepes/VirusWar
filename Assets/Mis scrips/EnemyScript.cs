using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    public int energy = 5;
    public GameObject target;
    public GameObject balas;
    public GameObject explosion;
    public AudioSource audio;
    public Animator animacion;
    public GameObject[] puntosGuia;
    Vector3 targetActual;
    public int indiceTargetActual;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Disparar", 3, 3);
        targetActual = puntosGuia[indiceTargetActual].transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
        //Vector3 direccion = (target.transform.position - transform.position);
        //transform.rotation = Quaternion.LookRotation (direccion, Vector3.up);
       //-- transform.position += transform.forward * 3 * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x, transform.position.y * 3 * Time.deltaTime, transform.position.z);
        targetActual = puntosGuia[indiceTargetActual].transform.position - transform.position;
        //Vector3 dir = puntosGuia[indiceTargetActual].transform.position - transform.position;}
        transform.position = Vector3.MoveTowards(transform.position, puntosGuia[indiceTargetActual].transform.position, 0.5f);
        if (Vector3.SqrMagnitude(targetActual) < 10)
        {
            indiceTargetActual++;
            if (indiceTargetActual > puntosGuia.Length-1)
            {
                indiceTargetActual = 0;
            }
        }
        //moviento real
        //transform.position = new Vector3(transform.position.x + 3 * Time.deltaTime, transform.position.y, transform.position.z);
        
            animacion.SetBool("Caminar", true);
            animacion.SetBool("Disparo", false);
            animacion.SetBool("Defeat", false);
        
    }

    void OnTriggerEnter(Collider other)
    {
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

    public void Hitted()
    {
        audio.Play();
        energy--;
        if (energy <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            animacion.SetBool("Caminar", false);
            animacion.SetBool("Disparo", false);
            animacion.SetBool("Defeat", true);
        }
    }

    public void Disparar()
    {
        //Instantiate crea objetos en el area(mundo)        
        Instantiate(balas, transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
        
            animacion.SetBool("Caminar", false);
            animacion.SetBool("Disparo", true);
            animacion.SetBool("Defeat", false);
        
    }
}