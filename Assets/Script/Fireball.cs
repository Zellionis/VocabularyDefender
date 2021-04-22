using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject target = null;

    [SerializeField] private float speed = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position,0.02f * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0,0,Vector3.Angle((target.transform.position - transform.position).normalized,transform.right));
    }
}
