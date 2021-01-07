using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] float shrinker;
    [SerializeField] GameObject pickUpEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Vector3 originalSize = player.transform.localScale;

        player.transform.localScale *= shrinker;

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        

        yield return new WaitForSeconds(duration);

        player.transform.localScale = originalSize;

        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;

    }
}
