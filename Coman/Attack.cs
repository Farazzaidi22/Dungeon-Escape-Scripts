using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool CanAttack = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamagable hit = other.GetComponent<IDamagable>();

        if( hit != null)
        {
            if(CanAttack == true)
            {
                hit.Damage();
                CanAttack = false;
                StartCoroutine(ResetCanAttack());
            }
        }
    }

    IEnumerator ResetCanAttack()
    {
        yield return new WaitForSeconds(0.5f);
        CanAttack = true;
    }
}
