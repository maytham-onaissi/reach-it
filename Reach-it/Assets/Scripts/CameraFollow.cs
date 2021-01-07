
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
 

    [SerializeField] GameObject player;

    
    
    Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
