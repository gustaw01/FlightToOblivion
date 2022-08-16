using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;

    bool isTransitioning = false;
    bool isCollisionDiabled = false;

    void OnTriggerEnter(Collider other) {
        if (isTransitioning || isCollisionDiabled) { return; }
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        }
}
