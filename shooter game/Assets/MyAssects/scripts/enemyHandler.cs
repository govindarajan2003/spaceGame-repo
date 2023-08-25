 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem destructionFX;
    [SerializeField] ParticleSystem hitParticle;

    
    
    scoreHandler scoreHandler;
    [SerializeField] int scorePerHit = 25;
    [SerializeField] int smallEnemyHealth = 3; 
    GameObject parent;
    

    void Awake()
    {
       this.gameObject.AddComponent<Rigidbody>();
       this.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
    void Start()
    {
        scoreHandler = FindObjectOfType<scoreHandler>();
        parent = GameObject.FindWithTag("spawnAtRuntime");
        
    }
    void OnParticleCollision(GameObject other)
    {
        ScoreHandler();

        
        if(smallEnemyHealth <1)
        {
            KillEnemy();
        }
        
        
    }

    void KillEnemy()
    {
        scoreHandler.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(destructionFX.gameObject, transform.localPosition, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        Destroy(this.gameObject);    

    }

    void ScoreHandler()
    {
        GameObject vfx = Instantiate(hitParticle.gameObject, transform.localPosition, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        smallEnemyHealth --;
        
        Debug.Log($"smul enemy ** {smallEnemyHealth}");
        
        
    }
}
