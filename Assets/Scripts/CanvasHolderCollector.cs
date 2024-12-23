using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;


public class CanvasHolderCollector : MonoBehaviour
{
    public Canvas loadingCanvasCollector;
    public Canvas menuCanvasCollector;
    public Canvas settingsCanvasCollector;
    public Canvas bonusCanvasCollector;
    public Canvas gameCanvasCollector;
    public Canvas winCanvasCollector;
    public Canvas loseCanvasCollector;
    public Canvas difChoiceCanvasCollector;
    int currentLevelCollector = 1;

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


    public bool activeCollector = true;

    Timer tCollector;

    public Stack<string> currentStackCollector;


    void Start()
    {    
        menuCanvasCollector.enabled = false; 
        settingsCanvasCollector.enabled = false;
        CounterCollector();
        bonusCanvasCollector.enabled = false;
        gameCanvasCollector.enabled = false;
        winCanvasCollector.enabled = false;
        difChoiceCanvasCollector.enabled = false;
        loseCanvasCollector.enabled = false;
        currentStackCollector = new Stack<string>();
        CounterCollector();
        currentStackCollector.Push("menuCollector");

        HideTimerCollector();
    }

 
    public void EndLoadCollector()
    {
        loadingCanvasCollector.enabled = false;
        menuCanvasCollector.enabled = true;
        CounterCollector(2);
    }




    public void HideTimerCollector()
    {
        tCollector = new Timer(1500);
        tCollector.AutoReset = false;
        CounterCollector(2);
        tCollector.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tCollector.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
             CounterCollector(3);
            EndLoadCollector();
        }
        finally
        {
             CounterCollector(11);
            tCollector.Enabled = false;
        }
    }

    public void MoveBackCollector()
    {
        bool bonusMove = false;
        if (currentStackCollector.Peek() == "bonusCollector")
        {
            CounterCollector(1);
            bonusMove = true;
        }
        currentStackCollector.Pop();
        if (currentStackCollector.Peek() == "gameCollector"&&bonusMove==true)
        {
            gameCanvasCollector.GetComponent<GameLogicCollector>().StartGameCollector(currentLevelCollector);
        }
        MoveCollector(currentStackCollector.Peek(), true);
    }
    public void MoveCollector(string destinationCollector, bool backmoveCollector = false, int difCollector =0)
    {
        if(difCollector>0) currentLevelCollector=difCollector;
        menuCanvasCollector.enabled = false;
        settingsCanvasCollector.enabled = false;
         CounterCollector(13);
        bonusCanvasCollector.enabled = false;
        gameCanvasCollector.enabled = false;
        loseCanvasCollector.enabled = false;
        winCanvasCollector.enabled = false;
        difChoiceCanvasCollector.enabled = false;

        if (destinationCollector == "winCollector")
        {
            winCanvasCollector.enabled = true;
            backmoveCollector = true;
        }

        if (destinationCollector == "loseCollector")
        {
            loseCanvasCollector.enabled = true;
            loseCanvasCollector.GetComponent<WinScriptCollector>().WinScreenCollector();
            backmoveCollector = true;
        }


         CounterCollector();

        if (destinationCollector == "menuCollector")
        {
            menuCanvasCollector.enabled = true;
            activeCollector = false;
        }
        else if (destinationCollector == "settingsCollector")
        {
            settingsCanvasCollector.enabled = true;
        }
        else if (destinationCollector == "levelsCollector")
        {
            CounterCollector(1);
            difChoiceCanvasCollector.enabled = true;
            difChoiceCanvasCollector.GetComponent<LevelScriptCollector>().ActivateButtonsCollector();
        }
        else if (destinationCollector == "gameCollector")
        {
             CounterCollector(25);
            gameCanvasCollector.enabled = true;          
            if (!backmoveCollector) gameCanvasCollector.GetComponent<GameLogicCollector>().StartGameCollector(currentLevelCollector);
        }
        else if (destinationCollector == "bonusCollector")
        {
            bonusCanvasCollector.enabled = true;
        }
        if (!backmoveCollector) { currentStackCollector.Push(destinationCollector); }
         CounterCollector();
     
    }

    void Update()
    {



        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackCollector.Count == 1)
                    {
                         CounterCollector();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackCollector();
                    }

                }
            }
            catch (Exception eCollector)
            {

            }
        }
    }


}
