using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : Enemy
{
    [SerializeField] private BossController bossController;
    [SerializeField] protected int damage;


    public override void HurtSequence()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("dmgBoss"))
        {
            return;
        }
        anim.SetTrigger("damage");
    }
    public override void DeathSequence()
    {
        base.DeathSequence();
        bossController.ChangeStatus(BossStates.death);
        Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStates>().PlayerTakeDamage(damage);
        }
    }
}
