using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public GameObject GameEnd;
    public int hp = 30;
    int score;
    public TextMesh textScore;
    void Update()
    {
        if (ZombieFactory.Zombief.IsGameEnd())
        {
            GameEnd.SetActive(true);
            textScore.text = "游戏结束\n" + "得分: " + score;
            textScore.color = Color.red;
            textScore.transform.SetParent(GameEnd.transform);
            textScore.transform.localPosition = new Vector3(0, 0.3f, 0.3f);
        }
    }
    public void AddScore()
    {
        score++;
        textScore.text = "得分: " + score;
    }
    public void TakeHurt(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            if (hp <= 0)
            {
                //Destroy(this.gameObject);
                Time.timeScale = 0;
                GameEnd.SetActive(true);
                textScore.text = "游戏结束\n" + "得分: " + score;
                textScore.color = Color.red;
                textScore.transform.SetParent(GameEnd.transform);
                textScore.transform.localPosition = new Vector3(0, 0.3f, 0.3f);
            }
        }
    }
}
