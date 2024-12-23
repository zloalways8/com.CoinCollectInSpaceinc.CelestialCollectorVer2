using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptCollector : MonoBehaviour
{
    public float TimeLeftCollector = 120;
    public bool TimerOnCollector = false;


    public Text TimerTxtCollector;


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


    void Update()
    {
        if (TimerOnCollector)
        {
            if (TimeLeftCollector > 1)
            {
                TimeLeftCollector -= Time.deltaTime;
                UpdateTimerCollector(TimeLeftCollector);
            }
            else
            {
                CounterCollector(Time.deltaTime);
                GetComponent<JumpCanvasCollector>().JumpCollector("loseCollector");
            }
        }
    }

    public void RefreshTimerCollector()
    {
        TimeLeftCollector = 82;

        if (GameObject.Find("DeleteTimerOffButtonCollector").GetComponent<ButtonComponentCollector>().currentStateCollector)
        {
            CounterCollector(Time.deltaTime);
            TimerOnCollector = true;
        } else TimerOnCollector = false;
     
        TimerTxtCollector.text = "";
    }
    void UpdateTimerCollector(float currentTimeCollector)
    {
        currentTimeCollector -= 1;
        TimerTxtCollector.text = (int)currentTimeCollector+"SEC";
    }
}
