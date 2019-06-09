using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    NavMeshAgent agent;
    [Header("追击目标")]
    public GameObject target;
    Animator animator;
    [Header("血量值")]
    public int hp;
    [Header("特效预制体")]
    public GameObject effectPrefab;
    [Header("攻击力")]
    public int attack;
    public bool IsAlive
    {
        get
        {
            if (hp < 0)
            {
                return false;
            }
            return true;
        }
    }
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("PlayerHp");
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        animator = this.GetComponent<Animator>();
    }
    float atkTime = 1;
    // Update is called once per frame
    void Update()
    {
        atkTime += Time.deltaTime;
        animator.Play("Zombie_Walk");
        if (ReachTarget())
        {
            if (atkTime >= 1)
            {
                atkTime = 0;
                animator.Play("Zombie_Eating");
                target.GetComponent<PlayerHurt>().TakeHurt(attack);
            }
        }
    }
    //判断是否到达目标
    public bool ReachTarget()
    {
        if (agent.isActiveAndEnabled)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                return true;
            }
        }
        return false;
    }
    public void Hurt(int bulletHurt)
    {
        if (hp > 0)
        {
            hp -= bulletHurt;
            if (hp <= 0)
            {
                var go = Instantiate(effectPrefab);
                go.transform.position = transform.position + transform.up * 1.5f;
                Destroy(go.gameObject, 2f);
                Destroy(this.gameObject);
                target.GetComponent<PlayerHurt>().AddScore();
                ZombieFactory.Zombief.zombieCount--;
            }
        }
    }
}
