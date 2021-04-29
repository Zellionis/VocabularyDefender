using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject fireball = null;
    [SerializeField] private GameObject cristal1 = null;
    [SerializeField] private GameObject cristal2 = null;
    [SerializeField] private GameObject cristal3 = null;

    [SerializeField] private TMP_Text LifeField = null;
    [SerializeField] private TMP_Text ScoreField = null;

    public int Hp;
    public static int Score;
    public int combo = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LifeField.text = Hp.ToString();
        ScoreField.text = Score.ToString();
    }

    public void Fire(List<GameObject> _monsterList)
    {
        GameObject temp = null;
        
        temp = GameObject.Instantiate(fireball,cristal1.transform.parent);
        temp.transform.position = cristal1.transform.position;
        temp.GetComponent<Fireball>().targetList = _monsterList;

        if (combo >= 2)
        {
            temp = GameObject.Instantiate(fireball,cristal2.transform.parent);
            temp.transform.position = cristal2.transform.position;
            temp.GetComponent<Fireball>().targetList = _monsterList;
        }

        if (combo == 3)
        {
            temp = GameObject.Instantiate(fireball,cristal3.transform.parent);
            temp.transform.position = cristal3.transform.position;
            temp.GetComponent<Fireball>().targetList = _monsterList;
        }

    }

    public void Damage(int _damage)
    {
        Hp -= _damage;

        if (Hp <= 0)
        {
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals("Enemy"))
            return;
        
        Damage(other.GetComponent<monster>().Hp*2);
        Destroy(other.gameObject);
    }
}
