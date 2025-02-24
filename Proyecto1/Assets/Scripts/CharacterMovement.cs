using UnityEngine;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float velocidad;
    public float gravedad;
    public Vector3 direccion;
    public CharacterController cc;
    public float velocidadOriginal;

    // Store original colors as [Renderer, Color]
    private Dictionary<Renderer, Color> originalColors = new Dictionary<Renderer, Color>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.cc = this.gameObject.GetComponent<CharacterController>();
        this.velocidadOriginal = velocidad;
        
        Renderer[] allRenderers = GetComponentsInChildren<Renderer>(true);
        foreach (Renderer renderer in allRenderers)
        {
            originalColors.Add(renderer, renderer.sharedMaterial.color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        direccion = Vector3.zero; // reiniciamos, para que se recalcule en base en mi posicion actual
        direccion.y -= gravedad; // lo normalizamos 
        direccion.x = Input.GetAxisRaw("Horizontal")*velocidad;
        direccion.z = Input.GetAxisRaw("Vertical")*velocidad;
        
        //this.transform.position += direccion*Time.deltaTime;
        cc.Move(direccion*Time.deltaTime);
    }

    public void setVelocity(float velocidad)
    {
        this.velocidad = velocidad;
    }

    public void resetVolocity()
    {
        this.velocidad = velocidadOriginal;
    }

    public void paint(Color newColor)
    {
        // Get all Renderers in the parent and children (including inactive ones)
        Renderer[] allRenderers = GetComponentsInChildren<Renderer>(true);

        foreach (Renderer renderer in allRenderers)
        {
            renderer.material.color = newColor;
        }
    }

    public void resetColors()
    {
        foreach (var pair in originalColors)
        {
            Renderer renderer = pair.Key;
            Color originalColor = pair.Value;
            renderer.material.color = originalColor;
        }
    }

}
