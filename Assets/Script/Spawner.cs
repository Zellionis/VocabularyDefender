using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mob1;
    public float Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject spawn(GameObject _mob, int index)
    {
        GameObject mob = Object.Instantiate<GameObject>(_mob);
        if (mob.GetComponent<monster>())
            mob.GetComponent<monster>().target = Target;

        if (index < 4)
            mob.transform.position = transform.position;
        else
            mob.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f);
        
        return mob;
    }
}
