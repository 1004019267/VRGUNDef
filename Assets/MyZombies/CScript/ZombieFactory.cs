using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
    private static ZombieFactory zombief;
    public static ZombieFactory Zombief
    {
        get
        {
            return zombief;
        }
    }
    public GameObject[] zombiePre;
    public Transform[] zombieFac;
    public int wave = 10;
    public int zombieCount;
    // Use this for initialization
    void Awake()
    {
        zombief = this;
        zombieFac = transform.GetComponentsInChildren<Transform>();
    }
    void Start()
    {
        for (int i = 1; i < zombieFac.Length; i++)
        {
            zombieCount++;
            var go = Instantiate(zombiePre[Random.Range(0, zombiePre.Length)]);
            go.transform.position = zombieFac[i].position;
        }
        wave--;
    }
    // Update is called once per frame
    float time;
    void Update()
    {
        time += Time.deltaTime;
        if (wave > 0 && time >= 10)
        {
            wave--;
            time = 0;
            for (int i = 1; i < zombieFac.Length; i++)
            {
                zombieCount++;
                var go = Instantiate(zombiePre[Random.Range(0, zombiePre.Length)]);
                go.transform.position = zombieFac[i].position;
            }
        }
    }

    public bool IsGameEnd()
    {
        if (wave<=0&&zombieCount<=0)
        {
            return true;
        }
        return false;
    }
}
