using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordArc;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordArc = transform.GetChild(1).GetComponent<Animator>();
    }


    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jump)
    {
        _anim.SetBool("Jumping", jump);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordArc.SetTrigger("ArcAnimation");
    }

    public void Death()
    {
        _anim.SetTrigger("Death");
    }
}
