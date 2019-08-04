using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    
    void Update()
    {
        Destroy(this.gameObject, 2);
    }
}
