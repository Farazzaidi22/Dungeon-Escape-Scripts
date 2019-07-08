using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
    public int Health { get; set; }
    public GameObject acidprefab;

    //when you want to call child's start but it'd collide with parent's start
    //for initializing something additional you want in child's start
    public override void Init()
    {
        //base is for grabbing the parent class
        base.Init(); //this line means run normally (no additional initializing is made in the child's start)

        Health = base.health;
    }

    public override void Movement()
    {
        //stay still
    }

    public override void Update()
    {
        //do nothing
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        Health = Health - 1;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            //this is type-casting
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }

    public void Attack()
    {
        Instantiate(acidprefab, transform.position, Quaternion.identity);
    }
}
