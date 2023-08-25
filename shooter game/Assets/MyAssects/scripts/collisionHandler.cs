using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class collisionHandler : MonoBehaviour
{
    [SerializeField]float reloadSceneTimer =1.5f;
    [SerializeField] ParticleSystem hitParticle;
    
    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(this.name+" collided with"+other.gameObject.name);

        
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{this.name} ** Trigggered by** {other.gameObject.name}");
        startCrashSequence();
        
    }
    void startCrashSequence()
    {
        GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<BoxCollider>().enabled =false;
        hitParticle.Play();
        GetComponent<controlsHandler>().enabled =false;
        Invoke("reloadScene", reloadSceneTimer);
    }

    void reloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
