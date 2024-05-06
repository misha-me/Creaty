using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int keyCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Key"))
        {
            keyCount++;
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("Finish"))
        {
            Debug.Log("FINISH!");
        }
    }
}
