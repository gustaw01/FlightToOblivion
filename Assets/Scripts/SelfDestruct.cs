using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] float destroyTime = 2f;

    void Start() {
        Destroy(gameObject, destroyTime);
    }
}
