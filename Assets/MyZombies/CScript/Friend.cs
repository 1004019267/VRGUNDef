using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    AudioSource audioSou;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float attackRange = 3;
    public float attackRate = 1;
    public float speed = 200;

    float attackInterval;
    float t;

    Transform target;
    int layermask;
    // Use this for initialization
    void Awake()
    {
        audioSou = this.GetComponent<AudioSource>();
    }
    void Start()
    {
        attackInterval = 1f / attackRate;
        layermask = 1 << LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Collider[] colls = Physics.OverlapSphere(transform.position, attackRange, layermask);
            if (colls.Length > 0)
            {
                target = colls[0].transform;
            }
        }
        else
        {
            transform.LookAt(target);
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > attackRange || target.GetComponent<Zombie>().IsAlive == false)
            {
                target = null;
            }
            if (Time.time - t > attackInterval)
            {
                t = Time.time;
                Fire();
            }
        }
    }
    void Fire()
    {
        var go = PoolManage.Instance.Get("PlayerBullet");
        go.transform.position = firePoint.position;
        go.transform.rotation = firePoint.rotation;
        go.GetComponent<Rigidbody>().velocity = firePoint.forward * speed;
        audioSou.Play();
    }
        
}
