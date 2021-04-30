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
    private float SpeedAdd = 0;
    void Start()
    {
        Wave = 1;
        CurrTime = TimeSpawn;
        CurrentN = NumberWords;
    }

    // Update is called once per frame
    void Update()
    {
        int ran;
        if (CurrTime <= 0)
        {
            int percent = Random.Range(0, 100);


            if (percent <= 80)
            {
                ran = Random.Range(0, 4);
            }
            else
            {
                ran = Random.Range(4, 7);
            }




            if (CurrentN - Prefabs[ran].GetComponent<monster>().Hp < 0)
            {
                while (CurrentN - Prefabs[ran].GetComponent<monster>().Hp < 0)
                {
                    ran--;
                }
            }


            if (CurrentN > 0)
            {
                CurrentN -= Prefabs[ran].GetComponent<monster>().Hp;
                int SpawnRan = Random.Range(0, 3);
                Mobs.Add(spawns[SpawnRan].spawn(Prefabs[ran], ran));
                Mobs[Mobs.Count - 1].GetComponent<SpriteRenderer>().sortingOrder = SpawnRan + (ran > 3 ? 2 : 1);
                Mobs[Mobs.Count - 1].GetComponent<monster>().speed += SpeedAdd;
                CurrTime = Mobs[Mobs.Count - 1].GetComponent<monster>().timeToNextSpawn;
            }

            if (CurrentN == 0)
            {
                if (Wave < 4)
                    NumberWords += 10;

                else if (Wave < 6)
                    SpeedAdd += 0.25f;

                else if (Wave < 8)
                    NumberWords += 10;

                else
                    SpeedAdd += 0.25f;

                CurrentN = NumberWords;
                Wave++;
            }

        }
        CurrTime -= Time.deltaTime;

    }
    
}
