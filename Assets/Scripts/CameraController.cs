using UnityEngine;
using System.Collections; 

public class CameraController : MonoBehaviour {
    
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();

        }
    }


    public GameObject player;        

private Vector3 offset;       
    
void Start()
{
    
    offset = transform.position - player.transform.position;
}


void LateUpdate()
{
    
    transform.position = player.transform.position + offset;
}
}




