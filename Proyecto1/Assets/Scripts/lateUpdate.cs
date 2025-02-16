using UnityEngine;

public class lateUpdate : MonoBehaviour
{
    private void onEnable()
    {
        Debug.Log("Enable");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.Translate(0,0,0.1f*Time.deltaTime*5);
    }
}
