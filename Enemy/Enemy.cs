using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject diamondPrefab;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform PointA, PointB;

    protected Animator anim;
    protected SpriteRenderer Enemy_Sprite;
    protected Vector3 CurrentPosition;
    protected Player player;

    protected bool isHit = false;
    protected bool isDead = false;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        Enemy_Sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        if(isDead == false)
        {
            Movement();
        }
        
    }

    public virtual void Movement()
    {
        if (CurrentPosition == PointA.position)
        {
            Enemy_Sprite.flipX = true;
        }
        else
        {
            Enemy_Sprite.flipX = false;
        }

        if (transform.position == PointA.position)
        {
            CurrentPosition = PointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == PointB.position)
        {
            CurrentPosition = PointA.position;
            anim.SetTrigger("Idle");
        }

        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, CurrentPosition, speed * Time.deltaTime);
        }

        float distace = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if(distace > 2)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            Enemy_Sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            Enemy_Sprite.flipX = true;
        }
    }
}
