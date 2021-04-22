using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public List<GameObject> targetList;
    private GameObject target = null;
    
    [SerializeField] private float speed = 0;
    
    void Start()
    {
        target = targetList[0];
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var _target in targetList)
        {
            if (_target != null)
            {
                target = _target;
                break;
            }
        }
        
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position,0.02f * speed * Time.deltaTime);
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed); 
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.tag.Equals("Enemy"))
            return;
        
        other.gameObject.GetComponent<monster>().Damage(1);
        Destroy(this.gameObject);
    }
}
