using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int pointsToScore = 50;
    [SerializeField] int hitPoints = 3;

    ScoreBoard scoreBoard;

    void Start() {
       scoreBoard = FindObjectOfType<ScoreBoard>();
       
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(pointsToScore);
        scoreBoard.ShowScore();
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        hitPoints--;
        if(hitPoints < 1) { KillEnemy(); }
    }
}
