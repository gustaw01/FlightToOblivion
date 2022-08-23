using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int pointsToScore = 50;
    [SerializeField] int hitPoints = 3;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        AddRigigdbody();
        parentGameObject = GameObject.FindWithTag("SpawnOnRunetime");
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddRigigdbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(pointsToScore);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
        if(hitPoints < 1) { KillEnemy(); }
    }
}
