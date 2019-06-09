using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public Transform firePoint;
    public GameObject bullerPrefab;
    [Header("射速")]
    public float fireRate = 3f;
    [Header("子弹速度")]
    public int butterSpeed=10;

    public string bulletName;
    protected float fireInterval;
    protected float lastFireTime;
    AudioSource audioSou;
    void Awake()
    {
        audioSou = this.GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start () {
        fireInterval = 1f / fireRate;
        lastFireTime = -fireInterval;
        PoolManage.Instance.CreatePool(bulletName, bullerPrefab);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void FireGo()
    {
        if (Time.time-lastFireTime>fireInterval)
        {
            lastFireTime = Time.time;
            var go = PoolManage.Instance.Get(bulletName);
            audioSou.Play();
            go.transform.position = firePoint.position;
            go.transform.rotation = firePoint.rotation;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * butterSpeed;
        }
    }
}
