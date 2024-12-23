using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonComponentCollector : MonoBehaviour
{

    public Sprite onStateCollector;
    public Sprite offStateCollector;
    public bool currentStateCollector = false;
    public Button counterpartCollector;



    private Tuple<double,bool> CounterCollector(double numberCollector=1.2)   {     
        bool checkCollector = false;
        double resultCollector =numberCollector;
        if (numberCollector > Time.time)
        {
            checkCollector = true;
            resultCollector -= 25;
        }
        return Tuple.Create(resultCollector, checkCollector);
    }



    private void Start()
    {
        if (currentStateCollector)
        {
            CounterCollector();
            GetComponent<Image>().sprite = onStateCollector;
        }
        else GetComponent<Image>().sprite = offStateCollector;
    }


    public void ClickCollector(bool directCollector = true)
    {
        currentStateCollector = !currentStateCollector;
        if (currentStateCollector)
        {
            CounterCollector();
            GetComponent<Image>().sprite = onStateCollector;
        }
        else GetComponent<Image>().sprite = offStateCollector;
        CounterCollector();
        if (directCollector) counterpartCollector.GetComponent<ButtonComponentCollector>().ClickCollector(false);
    }

}
