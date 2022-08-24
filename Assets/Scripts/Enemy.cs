using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
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
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject fx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
        hitPoints--;
        if(hitPoints < 1) { KillEnemy(); }
    }
}
