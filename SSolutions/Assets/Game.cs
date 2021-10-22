using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public RectTransform SelectionBar;
    public GameObject gameField;
    public GameObject menu;
    public Driver player1;
    public Driver player2;
    public Ball ball;
    public Text score1;
    public Text score2;
    public GameObject dividor;

    void Start()
    {
        dSwitchAll(false);
        ball.Scoring = Scoring;
        //menu.SetActive(true);
    }

    public void dSwitchAll(bool b)
    {
        gameField.SetActive(b);
        menu.SetActive(!b);
        player1.gameObject.SetActive(b);
        player2.gameObject.SetActive(b);
        ball.gameObject.SetActive(b);
        score1.gameObject.SetActive(b);
        score2.gameObject.SetActive(b);
        dividor.SetActive(b);
    }


    public void Scoring(int playerNumber)
    {
        if (playerNumber == 1)
        {
            score1.text = (int.Parse(score1.text) + 1).ToString();
            GoBall(2);
        }
        else
        {

            score2.text = (int.Parse(score1.text) + 1).ToString();
            GoBall(1);
        }

    }

    private void GoBall(int v)
    {
        if (v == 1)
        {
            ball.tr.position = player1.GetComponent<RectTransform>().position + new Vector3(-ball.tr.rect.width + player1.tr.rect.width / 2, 0, 0);

        }
        else
        {

            ball.tr.position = player2.tr.position + new Vector3(ball.tr.rect.width - player1.tr.rect.width / 2, 0, 0);
            ball.speed = -ball.speed;            

        }
    }

    public void HoverItem(RectTransform item)
    {
        print(item.gameObject.name);
        SelectionBar.position = item.position;
    }

    public void SelectItem(RectTransform item)
    {
        dSwitchAll(true);

        switch (item.gameObject.name)
        {
            case "SinglePlayer":
                player2.Setup(new MousePlayer());
                player1.Setup(new MousePlayer());
                break;

            case "PvP":

                player2.Setup(new MousePlayer());
                player1.Setup(new KeyPlayer());
                break;

            case "PvC":
                player2.Setup(new MousePlayer());
                player1.Setup(new CompPlayer(ball, player1));
                break;
        }
    }


}
