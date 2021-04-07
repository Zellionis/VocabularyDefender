using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Spawner[] spawns = new Spawner[3];
    public GameObject[] Prefabs;
    public List<GameObject> Mobs;
    public int Wave;
    public int NumberWords;
    public float TimeSpawn;
    int CurrentN = 0;
    float CurrTime = 0;
    void Start()
    {
        CurrTime = TimeSpawn;
        CurrentN = NumberWords;
    }

    // Update is called once per frame
    void Update()
    {
        int ran = Random.Range(0, Prefabs.Length);

        if(CurrentN - Prefabs[ran].GetComponent<monster>().Hp < 0)
        {
            ran = 0;
        }

        if (CurrTime <= 0 && CurrentN > 0)
        {
            CurrentN -= Prefabs[ran].GetComponent<monster>().Hp;
            Mobs.Add(spawns[Random.Range(0, 3)].spawn(Prefabs[ran]));
            
            CurrTime = TimeSpawn;
        }

        CurrTime -= Time.deltaTime;
    }

    public void NextWave()
    {
        Wave++;
        foreach (GameObject Mob in Mobs)
        {
            Destroy(Mob);
        }
        Mobs.Clear();
    }
}
