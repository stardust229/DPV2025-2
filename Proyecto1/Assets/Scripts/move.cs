using UnityEngine;

public class move : MonoBehaviour
{

    public float velocidad;
    public float movimientoVer, movimientoHor;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHor = Input.GetAxis("Horizontal");
        movimientoVer = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHor,0,movimientoVer);

        rb.AddForce(movimiento*velocidad);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Finish") {
            // Si hacemos Destroy(this) estaríamos destruyendo este script
            Destroy(collision.gameObject);
        }
        Debug.Log(collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision) {
        Debug.Log("Exited");
    }

    private void OnCollisionStay(Collision collision) {
        Debug.Log("Staying on collision");
    }

    private void OnTriggerEnter(Collider other) {
        // recibe un objeto COllider, no trigger. Un collider es la cosa que 
        // delimita el objeto y qué lo toca
        if(other.gameObject.tag == "Finish") {
            Destroy(other.gameObject);
        }

    }
}
