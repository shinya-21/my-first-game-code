using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEnemy
{
    [SerializeField] GameObject event4;

    protected override void Start()
    {
        base.Start();
    }


    protected override void Update()
    {
        base.Update();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "hand_trigger" &
            clipInfo[0].clip.name == "Cat|Action.Attack_Paw")
        {
            enemyAudio.PlayOneShot(enemyAudio.clip);

            DirectionEnemyFalls();
        }
    }

    protected override void EnemyDestroy()
    {
        StartCoroutine(EnemyDestroyStart());
    }

    IEnumerator EnemyDestroyStart()
    {
        blinking = true;
        yield return new WaitForSeconds(2f);

        event4.SetActive(true);
        Destroy(this.gameObject);
    }
}
