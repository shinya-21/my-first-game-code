using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event5 : GameManager
{
    [SerializeField] GameObject event5Text1;
    [SerializeField] GameObject event5Text2;
    [SerializeField] GameObject event5Camera;


    protected override void Start()
    {
        base.Start();

        StartCoroutine(EventStart());
    }

    IEnumerator EventStart()
    {
        NotPlayable();
        yield return new WaitForSeconds(0.5f);

        textPanel.SetActive(true);
        event5Text1.SetActive(true);
        yield return new WaitForSeconds(1f);

        virtualCamera.SetActive(false);
        event5Camera.SetActive(true);
        yield return new WaitForSeconds(5f);

        event5Text1.SetActive(false);
        event5Text2.SetActive(true);
        yield return new WaitForSeconds(5f);

        event5Camera.SetActive(false);
        textPanel.SetActive(false);
        event5Text2.SetActive(false);
        virtualCamera.SetActive(true);
        Playable();
        Destroy(event5Text1);
        Destroy(event5Text2);
        Destroy(event5Camera);
        Destroy(this.gameObject);
    }
}