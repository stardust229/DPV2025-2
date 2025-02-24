using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(superVelocidad(other.gameObject));
            //Destroy(this.gameObject, 4.0f); // esto va a hacer que se destruya la esfera después de 4 segundos
        }
    }

    // una co-rutina
    IEnumerator superVelocidad(GameObject player)
    {
        // Esta es una forma de hacer que desaparezca la esfera:
        this.gameObject.GetComponent<MeshRenderer>().enabled = false; // esto haría que la esfera se deje de ver, pero sigue ahí
        this.gameObject.GetComponent<SphereCollider>().enabled = false; // esto apaga el collider

        player.GetComponent<CharacterMovement>().paint(this.gameObject.GetComponent<MeshRenderer>().material.color);
        player.GetComponent<CharacterMovement>().setVelocity(20.0f);
        yield return new WaitForSeconds(3.0f);
        player.GetComponent<CharacterMovement>().resetColors();
        player.GetComponent<CharacterMovement>().resetVolocity();
    }
}
