using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpring : MonoBehaviour
{

    [SerializeField] private GameObject ballPrefab;

    public void InstantiateBall()
    {
        // Instantiate the same transform of this game object
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }
}
