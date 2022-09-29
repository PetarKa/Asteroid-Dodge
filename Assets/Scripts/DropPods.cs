using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPods : MonoBehaviour
{
    public GameObject particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Instantiate(particle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-0.5f, gameObject.transform.position.z), Quaternion.identity);

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (gameObject.transform.position.y < -4)
        {
            Destroy(gameObject);
        }
    }

}
