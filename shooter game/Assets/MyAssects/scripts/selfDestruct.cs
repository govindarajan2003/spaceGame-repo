using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    [SerializeField] float timeTillSelfDestruction = 3f;
    [SerializeField] AudioSource collisionSFX;
    void Start()
    {
        Destroy(this.gameObject, timeTillSelfDestruction);        
  
    }
}
