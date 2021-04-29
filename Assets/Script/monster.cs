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
    public float timeToNextSpawn = 2;
    public bool IsDead = false;
    [SerializeField] int scoreDrop = 20;
    private float timeDespawn = 2;

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

      if (IsDead)
      {
          timeDespawn -= Time.deltaTime;
          if(timeDespawn <= 0)
              Destroy(this.gameObject);

      }
    }

    public void Damage(int _damage)
    {
        Hp -= _damage;

        if (Hp <= 0)
        {
            Player.Score += scoreDrop;
            IsDead = true;
            speed = 0;
            GetComponent<Animator>().SetBool("dead",true);
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    
    
}
