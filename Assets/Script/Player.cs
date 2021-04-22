using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject fireball = null;
    [SerializeField] private GameObject cristal1 = null;
    [SerializeField] private GameObject cristal2 = null;
    
    public int Hp;
    public int Score;
    public int Solid;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(GameObject _monster)
    {
        GameObject temp = null;
        
        temp = GameObject.Instantiate(fireball,cristal1.transform.parent);
        temp.transform.position = cristal1.transform.position;
        temp.GetComponent<Fireball>().target = _monster;
        
        /*temp = GameObject.Instantiate(fireball,cristal2.transform.parent);
        temp.transform.position = cristal2.transform.position;
        temp.GetComponent<Fireball>().target = _monster;*/


    }
}
