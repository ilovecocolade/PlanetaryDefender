using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject EnemySmall;
    public GameObject EnemyMedium;
    public GameObject EnemyLarge;
    public float WarmUp;
    private int enemyCount;
    public float WaveWait;
    public int score;
    public Text ScoreText;
    public int waveCount;
    private GameObject enemy;
    public GameObject portal;
    private GameObject Player;
    private int d;
    private int h;
    private int phi;
    private float xPos;
    private float zPos;
    private Vector3 portalPos;
    private Vector3 direction;
    private float shipXpos;
    private float shipZpos;
    private float enemySmallVote;
    private float enemyMediumVote;
    private float enemyLargeVote;



    void Start()
    {

        score = 0;
        StartCoroutine(SpawnWave());
        Player = GameObject.FindGameObjectWithTag("GameController");

    }


    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(WarmUp);

        for (int n = 0; n < waveCount; n++)
        {

            enemyCount = (waveCount + 1) * 2;

            for (int i = 0; i <= enemyCount; i++)
            {

                enemySmallVote = Random.value;
                enemyMediumVote = Random.value;
                enemyLargeVote = Random.value;

                if (enemySmallVote >= enemyMediumVote && enemySmallVote >= enemyLargeVote) { enemy = EnemySmall; }
                else if (enemyMediumVote >= enemySmallVote && enemyMediumVote >= enemyLargeVote) { enemy = EnemyMedium; }
                else { enemy = EnemyLarge; }

                d = Random.Range(90, 110);
                h = Random.Range(-30, 80);
                phi = Random.Range(0, 360);

                xPos = d * Mathf.Sin(phi);
                zPos = d * Mathf.Cos(phi);

                portalPos = new Vector3(xPos, h, zPos);
                direction = Player.transform.position - portalPos;
                GameObject Portal = Instantiate(portal, portalPos, Quaternion.LookRotation(direction));

                shipXpos = 1.1f * d * Mathf.Sin(phi);
                shipZpos = 1.1f * d * Mathf.Cos(phi);

                Vector3 spawnPos = new Vector3(shipXpos, h, shipZpos);
                Vector3 shipDirection = Player.transform.position - spawnPos;

                GameObject Enemy = Instantiate(enemy, spawnPos, Quaternion.LookRotation(shipDirection));

                yield return new WaitForSeconds(5);

            }

            yield return new WaitForSeconds(WaveWait);

        }

    }

    public void IncreaseScore()
    {

        score++;
        ScoreText.text = "score: " + score.ToString();

    }


}