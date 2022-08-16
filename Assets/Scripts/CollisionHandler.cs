using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem explosionVFX;


    void OnTriggerEnter(Collider other) {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        explosionVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControler>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
