using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public AudioClip countAudio;

    protected Renderer rend;
    protected GameObject lemon;
    protected Animator lemonAnimator;
    protected AudioSource enemyAudio;
    protected AnimatorClipInfo[] clipInfo;
    protected EnemyManager enemyManager;

    protected bool blinking;
    protected float blinkingSeconds;

    protected virtual void Start()
    {
        rend = GetComponent<Renderer>();
        enemyAudio = GetComponent<AudioSource>();
        lemon = GameObject.Find("Lemon");
        lemonAnimator = lemon.GetComponent<Animator>();

        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    
    protected virtual void Update()
    {
        clipInfo = lemonAnimator.GetCurrentAnimatorClipInfo(0);

        BlinkingStart();
    }

    protected virtual void EnemyDestroy()
    {
        //継承先で処理を書く
    }

    protected void DirectionEnemyFalls()
    {
        Quaternion enemyQu = Quaternion.identity;
        Vector3 rote = lemon.transform.position - transform.position;
        enemyQu = Quaternion.LookRotation(rote);
        transform.rotation = enemyQu;

        Vector3 rotationAngles = transform.rotation.eulerAngles;
        rotationAngles.x -= 70f;
        Quaternion angleConversion = Quaternion.identity;
        angleConversion = Quaternion.Euler(rotationAngles);
        transform.rotation = angleConversion;

        EnemyDestroy();
    }

    protected void BlinkingStart()
    {
        if (blinking)
        {
            bool oddeven = Mathf.FloorToInt(Time.time * 4) % 2 == 0;
            rend.enabled = oddeven;
            blinkingSeconds += Time.deltaTime;

            if (blinkingSeconds >= 2)
            {
                blinkingSeconds = 0;
                rend.enabled = true;
                blinking = false;
            }
        }
    }
}
