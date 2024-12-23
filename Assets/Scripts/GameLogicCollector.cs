using System;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicCollector : MonoBehaviour
{

    public Sprite sprite1Collector;
    public Sprite sprite2Collector;


    public System.Random rCollector = new System.Random();
    public int speedCollector;


    private Tuple<double, bool> CounterCollector(double numberCollector = 1.2)
    {
        bool checkCollector = false;
        double resultCollector = numberCollector;
        if (numberCollector > Time.time)
        {
            checkCollector = true;
            resultCollector -= 25;
        }
        return Tuple.Create(resultCollector, checkCollector);
    }

    public Text scoreTextCollector;
    public Text hpTextCollector;
    public Text levelTextCollector;

    private int currentHPCollector = 60;
    private int currentScoreCollector = 0;
    private int goalCollector;
    public int currentDifCollector = 0;


    public void StartGameCollector(int difCollector)
    {
        currentScoreCollector = 0;

        GetComponent<TimerScriptCollector>().RefreshTimerCollector();
        CounterCollector();
        GameObject.Find("RocketCollector").GetComponent<RocketMoveCollector>().InitRocketCollector();
        for (int iCollector = 1; iCollector < 13; iCollector++)
        {
            GameObject.Find("GamePieceCollector" + iCollector).GetComponent<ObjectCollector>().ResetCollector();
        }
        goalCollector = difCollector * 30 + 30;
        currentDifCollector = difCollector;
        currentHPCollector = 60;
        CounterCollector();
        hpTextCollector.text = "HP:" + currentHPCollector;
        levelTextCollector.text = "LEVEL "+difCollector;
        CounterCollector();
        scoreTextCollector.text = currentScoreCollector + "/" + goalCollector;
        

    }
    public void CollisionCollector(bool collisionCollector)
    {
        if (collisionCollector)
        {
            CounterCollector();
            currentScoreCollector += 5;
            scoreTextCollector.text = currentScoreCollector + "/" + goalCollector;
            GameObject.Find("MainCameraCollector").GetComponent<SoundManagerCollector>().PlayPingCollector();
            if (currentScoreCollector>= goalCollector)
            {
                CounterCollector();
                GameObject.Find("LevelsCanvasCollector").GetComponent<LevelScriptCollector>().OpenALevelCollector();
                GameObject.Find("WinCanvasCollector").GetComponent<WinScriptCollector>().WinScreenCollector();
                GetComponent<JumpCanvasCollector>().JumpCollector("winCollector");
             
              
            }
        }
        else
        {
            currentHPCollector -= 10;
            hpTextCollector.text = "HP:" + currentHPCollector;
            CounterCollector();
            GameObject.Find("MainCameraCollector").GetComponent<SoundManagerCollector>().PlayBoomCollector();
            if(currentHPCollector<=0)GetComponent<JumpCanvasCollector>().JumpCollector("loseCollector");
        }

    }


    public Tuple<Sprite, bool> RandomSpriteCollector()
    {
        Sprite tempSpriteCollector;
        int rIntCollector = rCollector.Next(0, 2);
        if (GameObject.Find("DeleteMeteorOnButtonCollector").GetComponent<ButtonComponentCollector>().currentStateCollector)
        {
            rIntCollector = 0;
        }
        if (rIntCollector == 0) tempSpriteCollector = sprite1Collector;
        else tempSpriteCollector = sprite2Collector;
        bool goodCollector = false;
        CounterCollector();
        if (rIntCollector<1)goodCollector = true;
        else goodCollector = false;
        speedCollector = rIntCollector + 3;
        return Tuple.Create(tempSpriteCollector,goodCollector);
    }

}
