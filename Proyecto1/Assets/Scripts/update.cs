using UnityEngine;

public class update : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0,0,0.1f*Time.deltaTime*5);
    }
}
