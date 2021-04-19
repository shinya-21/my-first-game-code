using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event6 : GameManager
{
    
    [SerializeField] GameObject enemyText;
    [SerializeField] MainAudioDirector mainAudioScript;

    GameObject life;
    GameObject enemyUI;

    BoxCollider colli;

    protected override void Start()
    {
        base.Start();

        colli = GetComponent<BoxCollider>();

        life = ui.transform.Find("Life").gameObject;
        enemyUI = ui.transform.Find("enemy").gameObject;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Lemon")
        {
            StartCoroutine(EventStart());
        }
    }

    IEnumerator EventStart()
    {
        mainAudioScript.audioEvent = true;
        NotPlayable();
        yield return new WaitForSeconds(0.5f);

        textPanel.SetActive(true);
        enemyText.SetActive(true);
        yield return new WaitForSeconds(3f);

        enemyUI.SetActive(true);
        life.SetActive(true);
        Event6();
        colli.enabled = false;
        yield return new WaitForSeconds(3f);

        textPanel.SetActive(false);
        enemyText.SetActive(false);
        Playable();
        Destroy(this.gameObject);
    }
}
