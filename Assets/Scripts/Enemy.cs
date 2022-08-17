using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int pointsToScore = 1;

    ScoreBoard scoreBoard;

    void Start() {
       scoreBoard = FindObjectOfType<ScoreBoard>(); 
    }

    void OnParticleCollision(GameObject other)
    {
        KillEnemy();
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
    }
}
