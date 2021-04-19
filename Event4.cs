using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4 : GameManager
{
    [SerializeField] GameObject event4Text1;
    [SerializeField] GameObject event4Text2;
    [SerializeField] GameObject event4Text3;
    [SerializeField] GameObject event4Camera1;
    [SerializeField] GameObject event4Camera2;
    [SerializeField] GameObject miniEnemyUI;

    protected override void Start()
    {
        base.Start();

        StartCoroutine(EventStart());
    }

    private void Update()
    {
        if (event4Camera2.activeSelf)
        {
            event4Camera2.transform.position -= new Vector3(0.3f * Time.deltaTime, 0, 0);
        }
    }

    IEnumerator EventStart()
    {
        NotPlayable();
        yield return new WaitForSeconds(1f);

        textPanel.SetActive(true);
        event4Text1.SetActive(true);
        FirstEnemyListEvent();
        yield return new WaitForSeconds(3f);

        virtualCamera.SetActive(false);
        event4Camera1.SetActive(true);
        yield return new WaitForSeconds(5f);

        event4Camera1.SetActive(false);
        event4Camera2.SetActive(true);
        yield return new WaitForSeconds(5f);

        event4Camera2.SetActive(false);
        event4Text1.SetActive(false);
        virtualCamera.SetActive(true);
        yield return new WaitForSeconds(1f);

        event4Text2.SetActive(true);
        miniEnemyUI.SetActive(true);
        yield return new WaitForSeconds(5f);

        event4Text2.SetActive(false);
        event4Text3.SetActive(true);
        yield return new WaitForSeconds(5f);

        event4Text3.SetActive(false);
        textPanel.SetActive(false);
        Playable();
        Destroy(event4Text1);
        Destroy(event4Text2);
        Destroy(event4Text3);
        Destroy(event4Camera1);
        Destroy(event4Camera2);
        Destroy(this.gameObject);
    }
}