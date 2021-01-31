using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = target.transform.position;
    }
}
