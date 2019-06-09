using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBullet : MonoBehaviour
{
    public GameObject effectPrefab;
    public int damage = 3;
    public float bombRange = 3;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Zombie>().Hurt(damage);
        }
        Collider[] cols = Physics.OverlapSphere(transform.position, bombRange);
        foreach (var item in cols)
        {
            if (item.CompareTag("Enemy"))
            {
                item.GetComponent<Zombie>().Hurt(damage);
            }
        }
        PlayEffect();
        PoolManage.Instance.Recover("BoomBullet",this.gameObject);      
    }
    void PlayEffect()
    {
       Destroy (Instantiate(effectPrefab, transform.position, transform.rotation),1.5f);
    }
}
