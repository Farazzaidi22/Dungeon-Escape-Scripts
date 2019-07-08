using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamagable
{
    public int Health { get; set; }
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
        base.Movement();
    }

    public void Damage()
    {
        if(isDead == true)
        {
            return;
        }

        Debug.Log("MossGaint::Damag()");

        Health = Health - 1;
        anim.SetTrigger("hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            //this is type-casting
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
}
