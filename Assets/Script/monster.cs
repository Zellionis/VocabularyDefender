using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    // Start is called before the first frame update
    public int Hp;
    public float speed;
    public float target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(target < transform.position.x)
      {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
      }  
    }

    public void Damage(int _damage)
    {
        Hp -= _damage;
        
        if(Hp <= 0)
            Destroy(this.gameObject);
    }
}
