using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
