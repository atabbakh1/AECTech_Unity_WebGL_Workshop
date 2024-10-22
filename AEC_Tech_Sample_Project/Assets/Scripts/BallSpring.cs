using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpring : MonoBehaviour
{

    [SerializeField] private GameObject ballPrefab;

    public void InstantiateBall()
    {
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }
}
