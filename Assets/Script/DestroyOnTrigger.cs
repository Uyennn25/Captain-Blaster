using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    void ontriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
