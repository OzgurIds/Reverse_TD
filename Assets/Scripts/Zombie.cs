using System.Runtime.Versioning;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.SceneManagement;
public class Zombie : MonoBehaviour
{
    Transform target;
    public NavMeshAgent Agent;

    public Audio sounds;

    public int health = 3;
    public int damage = 1;
    float attackdelay = 1f;
    public float attackradius;

    Tower tower;
    private Coroutine Followcor;
    public void takedamage(int damage)
    {
        health -= damage;
    }
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Town_Hall").transform;
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
        Agent.SetDestination(target.position);
        sounds = GameObject.Find("Manager").GetComponent<Audio>();
        sounds.Zombie_Spawn.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Town" || other.tag == "Town_Hall")
        {
            Agent.SetDestination(other.transform.position);
            tower = other.GetComponent<Tower>();
            StartCoroutine(Attack());
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        StopCoroutine(Attack());
        Agent.isStopped = false;
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Town_Hall").transform;
            SceneManager.LoadScene("MainMenu");

            Agent.SetDestination(target.position);

        }
        else
        {
            Agent.SetDestination(target.position);
        }
    }
    IEnumerator Attack()
    {
        WaitForSeconds speed = new WaitForSeconds(attackdelay);
        while (enabled)
        {
            if (Agent.remainingDistance <= attackradius)
            {
                if (tower == null)
                {
                    yield return speed;
                }
                Agent.isStopped = true;
                Agent.velocity = Vector3.zero;
                sounds.Zombie_Hit.Play();
                tower.takedamage(damage);
            }
            yield return speed;
        }

    }
    void Update()
    {
        if (health <= 0)
        {
            sounds.Zombie_Destroy.Play();
            Destroy(gameObject);
        }

    }
}
