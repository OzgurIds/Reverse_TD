using System;
using System.Collections;
using UnityEngine;


public class Tower : MonoBehaviour

{
    public int damage;
    public float attackdelay;
    Zombie zombie;
    public int health;

    public Audio sounds;

    Coroutine Pew = null;

    void Awake()
    {
        sounds = GameObject.Find("Manager").GetComponent<Audio>();
        sounds.Invade.Play();
    }
    public void takedamage(int damage)
    {
        health -= damage;
    }

    void Update()
    {
        if (health <= 0)
        {
            if (tag == "Town_Hall")
            {
                sounds.Turret_Destroy.Play();
                sounds.Win.PlayDelayed(1f);
            }
            sounds.Turret_Destroy.Play();
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Zombie")
        {
            if (Pew == null)
            {
                zombie = other.GetComponent<Zombie>();
                Pew = StartCoroutine(Attack());
                sounds.Turret_Hit.Play();
            }
        }
    }
    //TODO: OnTriggerExit causes the code to reset, killing zombies faster than normal. use try/catch on OnTriggerStay 
    void OnTriggerExit2D(Collider2D other)
    {
        if (Pew != null)
        {
            StopCoroutine(Pew);
            Pew = null;
        }
    }
    IEnumerator Attack()
    {
        WaitForSeconds pew = new WaitForSeconds(attackdelay);
        while (enabled && zombie != null)
        {
            if (zombie == null)
            {
                yield return pew;
            }
            zombie.takedamage(damage);
            yield return pew;
        }
        yield return pew;
    }

}
