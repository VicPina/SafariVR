using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up, 15 * Time.deltaTime, 0);
    }
}
