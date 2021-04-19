using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject FirstEnemy { get; set; }
    public GameObject Enemy1 { get; set; }
    public GameObject Enemy2 { get; set; }
    public GameObject BossEnemy { get; set; }

    public List<GameObject> FirstEnemyList { get; set; } = new List<GameObject>();
    public List<GameObject> SecondsEnemyList { get; set; } = new List<GameObject>();
    public List<GameObject> ThirdEnemyList { get; set; } = new List<GameObject>();

    public Text MiniEnemyCountText { get; set; }
    public Text EnemyCountText { get; set; }
    public Text BossEnemyCountText { get; set; }

    GameObject enemyParentObject;
    GameObject firstEnemyListObject;
    GameObject secondsEnemyListObject;
    GameObject thirdEnemyListObject;

    GameObject canvas;
    GameObject ui;

    void Start()
    {
        enemyParentObject = GameObject.Find("Enemy");

        FirstEnemy = enemyParentObject.transform.Find("mini e").gameObject;
        Enemy1 = enemyParentObject.transform.Find("e1").gameObject;
        Enemy2 = enemyParentObject.transform.Find("e2").gameObject;
        BossEnemy = enemyParentObject.transform.Find("Boss e").gameObject;

        firstEnemyListObject = enemyParentObject.transform.Find("First Enemy List").gameObject;
        secondsEnemyListObject = enemyParentObject.transform.Find("Seconds Enemy List").gameObject;
        thirdEnemyListObject = enemyParentObject.transform.Find("Third Enemy List").gameObject;

        canvas = GameObject.Find("Canvas");
        ui = canvas.transform.Find("UI").gameObject;

        MiniEnemyCountText = ui.transform.Find("mini enemy").transform.
            Find("mini enemy1 4").gameObject.GetComponent<Text>();

        EnemyCountText = ui.transform.Find("enemy").transform.
            Find("enemy1 4").gameObject.GetComponent<Text>();

        BossEnemyCountText = ui.transform.Find("boss enemy").transform.
            Find("boss enemy1 3").gameObject.GetComponent<Text>();

        EnemyListPreparation();
    }

    void EnemyListPreparation()
    {
        foreach (Transform enemy in firstEnemyListObject.transform)
        {
            FirstEnemyList.Add(enemy.gameObject);
        }

        foreach (Transform enemy in secondsEnemyListObject.transform)
        {
            SecondsEnemyList.Add(enemy.gameObject);
        }

        foreach (Transform enemy in thirdEnemyListObject.transform)
        {
            ThirdEnemyList.Add(enemy.gameObject);
        }
    }
}
