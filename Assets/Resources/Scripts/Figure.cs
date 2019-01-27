using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    public bool _touched = false;
    public int heat = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.gameObject.CompareTag("Ground"))
        {
            _touched = true;
            Debug.Log("Check: " + other.collider.gameObject.name);
        }
    }
}
