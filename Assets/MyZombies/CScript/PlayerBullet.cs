using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int attack = 1;

    public Vector3 speed;

    // Use this for initialization
    void Awake()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Zombie>().Hurt(attack);
            //PoolManage.Instance.Recover("PlayerBullet", this.gameObject);
        }
        if (!other.CompareTag("Player"))
        {
            PoolManage.Instance.Recover("PlayerBullet", this.gameObject);
        }

    }

    void Update()
    {
        speed = this.GetComponent<Rigidbody>().velocity;
    }
}
