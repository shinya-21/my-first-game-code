using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected GameObject environment;
    protected GameObject secondFloor;
    protected GameObject thirdFloor;
    protected GameObject[] firstDoor = new GameObject[2];
    protected GameObject secondDoor;
    protected GameObject finalDoor;

    protected GameObject canvas;
    protected GameObject textPanel;
    protected GameObject ui;
    protected Image fadeImage;

    protected GameObject cinemachineOrCamera;
    protected GameObject virtualCamera;

    protected GameObject lemon;
    protected Animator lemonAnimator;
    protected PlayerController2 lemonController;

    protected EnemyManager enemyManager;

    protected bool fadeIn;
    protected bool fadeOut;
    protected float fadeInSpeed = 2f;

    [SerializeField] GameObject gameOverText;

    protected virtual void Start()
    {
        environment = GameObject.Find("Environment");
        secondFloor = environment.transform.Find("Second Floor").gameObject;
        thirdFloor = environment.transform.Find("Third Floor").gameObject;
        finalDoor = thirdFloor.transform.Find("Door_03 (3)").gameObject;

        canvas = GameObject.Find("Canvas");
        fadeImage = canvas.transform.Find("Fade").gameObject.GetComponent<Image>();
        textPanel = canvas.transform.Find("TextPanel").gameObject;
        ui = canvas.transform.Find("UI").gameObject;

        cinemachineOrCamera = GameObject.Find("Cinemachine or Camera");
        virtualCamera = cinemachineOrCamera.transform.Find("VirtualCamera").gameObject;

        lemon = GameObject.Find("Lemon");
        lemonAnimator = lemon.GetComponent<Animator>();
        lemonController = lemon.GetComponent<PlayerController2>();

        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    private void Update()
    {
        FadeOutStart();
    }

    public IEnumerator GameOverEvent()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Opening Scene");
        asyncLoad.allowSceneActivation = false;
        yield return new WaitForSeconds(1);

        textPanel.SetActive(true);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(3);

        fadeOut = true;
        yield return new WaitForSeconds(3);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        asyncLoad.allowSceneActivation = true;
    }

    protected void NotPlayable()
    {
        lemonController.Playable = false;
        lemonAnimator.SetBool("IsIdle", true);
    }

    protected void Playable()
    {
        lemonController.Playable = true;
        lemonAnimator.SetBool("IsIdle", false);
    }

    protected virtual void FadeInStart()
    {
        if (fadeIn & fadeImage.color.a > 0)
        {
            fadeImage.color -= new Color(0, 0, 0, fadeInSpeed * Time.deltaTime);
        }
    }

    protected void FadeOutStart()
    {
        if (fadeOut & fadeImage.color.a < 1)
        {
            fadeImage.color += new Color(0, 0, 0, fadeInSpeed * Time.deltaTime);
        }
    }

    protected void FirstDoorOpen()
    {
        firstDoor[0] = secondFloor.transform.Find("Door_03").gameObject;
        firstDoor[1] = secondFloor.transform.Find("Door_03 (2)").gameObject;

        foreach (GameObject door in firstDoor)
        {
            Destroy(door);
        }
    }

    protected void SecondsDoorOpen()
    {
        secondDoor = thirdFloor.transform.Find("Door_03 (2)").gameObject;

        Destroy(secondDoor);
    }

    protected void FinalDoorOpen()
    {
        finalDoor.SetActive(false);
        enemyManager.BossEnemy.SetActive(true);
    }

    protected void FirstEnemyEvent()
    {
        enemyManager.FirstEnemy.SetActive(true);
    }

    protected void FirstEnemyListEvent()
    {
        enemyManager.MiniEnemyCountText.text = enemyManager.FirstEnemyList.Count.ToString();

        foreach (GameObject enemySetActive in enemyManager.FirstEnemyList)
        {
            enemySetActive.SetActive(true);
        }
    }

    protected void Event6()
    {
        enemyManager.MiniEnemyCountText.text = enemyManager.SecondsEnemyList.Count.ToString();

        foreach (GameObject enemySetActive in enemyManager.SecondsEnemyList)
        {
            enemySetActive.SetActive(true);
        }
    }

    protected void Event7()
    {
        enemyManager.EnemyCountText.text = "1";
        enemyManager.Enemy1.SetActive(true);
    }

    protected void Event9()
    {
        enemyManager.EnemyCountText.text = "1";
        enemyManager.Enemy2.SetActive(true);
    }

    protected void Event12()
    {
        enemyManager.MiniEnemyCountText.text = enemyManager.ThirdEnemyList.Count.ToString();

        foreach (GameObject enemySetActive in enemyManager.ThirdEnemyList)
        {
            enemySetActive.SetActive(true);
        }
    }
}