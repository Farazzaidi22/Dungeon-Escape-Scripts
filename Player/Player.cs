using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    public int Diamonds = 0;

    private Rigidbody2D _rigid;
    private PlayerAnimation _PlayerAnim;
    private SpriteRenderer _PlayerSprite;

    [SerializeField]
    private float _jumpforce = 5.0f;
    [SerializeField]
    private bool _grounded = false;
    [SerializeField]
    private LayerMask _ground;
    [SerializeField]
    private float _speed = 3.0f;

    private bool resetjump = false;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _PlayerAnim = GetComponent<PlayerAnimation>();
        _PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckForGrounded();

        if(Input.GetKeyDown(KeyCode.Mouse0) && _grounded == true)
        {
            _PlayerAnim.Attack();
        }
    }

    void Movement()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");

        if (HorizontalInput > 0)
        {
            _PlayerSprite.flipX = false;
        }
        else if (HorizontalInput < 0)
        {
            _PlayerSprite.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpforce);
            _grounded = false;
            resetjump = true;
            StartCoroutine(ResetJumpNeeded());
            _PlayerAnim.Jump(true);
        }

        _rigid.velocity = new Vector2(HorizontalInput * _speed, _rigid.velocity.y);
        _PlayerAnim.Move(HorizontalInput);
    }

    void CheckForGrounded()
    {
        //this is a bitshift operator (<<) use to detect the layer the ray is colliding with
        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);

        //this is another way of detecting the collosion b/w the layer and ray
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _ground.value);

        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

        if (hitInfo.collider != null)
        {
            Debug.Log("hit: " + hitInfo.collider.name);
            if (resetjump == false)
            {
                _grounded = true;
                _PlayerAnim.Jump(false);
            }
        }

    }

    IEnumerator ResetJumpNeeded()
    {
        yield return new WaitForSeconds(0.1f);
        resetjump = false;
    }

    public void Damage()
    {
        if(Health < 1)
        {
            return;
        }
        Debug.Log("Bc maro toh ni baap ko!");
        Health--;
        UIManager.Instance.UpdateLiveBars(Health);

        if(Health < 1)
        {
            _PlayerAnim.Death();
        }
    }

    public void AddGems(int amount)
    {
        Diamonds += amount;
        UIManager.Instance.UpdateGemCount(Diamonds);
    }


}
