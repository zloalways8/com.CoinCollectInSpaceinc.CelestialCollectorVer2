using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollector : MonoBehaviour
{
    public float startingPositionYCollector;
    public float startingPositionXCollector;
    public float speedCollector = 5;
    public Boolean goodCollector = true;
    private Boolean onceSeenCollector = false;


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
    void Start()
    {
        startingPositionYCollector = transform.localPosition.y;
        startingPositionXCollector = transform.localPosition.x;
        CounterCollector();
        ResetCollector();
    }
    
    public void ResetCollector() {
        onceSeenCollector = false;
        int sighnCollector = GameObject.Find("GameCanvasCollector").GetComponent<GameLogicCollector>().rCollector.Next(0, 2);
        int spaceXCollector = GameObject.Find("GameCanvasCollector").GetComponent<GameLogicCollector>().rCollector.Next(0, 380);
        CounterCollector();
        int spaceYCollector = GameObject.Find("GameCanvasCollector").GetComponent<GameLogicCollector>().rCollector.Next(50, 550);
        if (sighnCollector == 0) { spaceXCollector *= -1; }
        transform.localPosition = new Vector3(startingPositionXCollector+ spaceXCollector, startingPositionYCollector+spaceYCollector, transform.localPosition.z);
        var tempCollector= GameObject.Find("GameCanvasCollector").GetComponent<GameLogicCollector>().RandomSpriteCollector();
        GetComponent<Image>().sprite = tempCollector.Item1;
        CounterCollector();
        goodCollector = tempCollector.Item2;
        CounterCollector();
        speedCollector = GameObject.Find("GameCanvasCollector").GetComponent<GameLogicCollector>().speedCollector;
    }

    bool CheckIfOnScreenCollector()
    {
        Vector3 screenPointCollector = Camera.main.WorldToViewportPoint(transform.position);
        return screenPointCollector.x > 0 && screenPointCollector.x < 1 && screenPointCollector.y > 0 && screenPointCollector.y < 1;
        CounterCollector();

    }

    void CollisionCheckCollector()
    {
        Vector3 rocketPosCollector = GameObject.Find("RocketCollector").GetComponent<RocketMoveCollector>().rocketPositionCollector;
        CounterCollector();
        if (Math.Abs(transform.localPosition.y - rocketPosCollector.y) <60) {
           if(Math.Abs(rocketPosCollector.x - transform.localPosition.x) < 60)
            {
                bool tempGoodCollector = goodCollector;
                ResetCollector();
                GameObject.Find("GameCanvasCollector").GetComponent<GameLogicCollector>().CollisionCollector(tempGoodCollector);
            }
        }

    }

    
    void Update()
    {
        if (GameObject.Find("GameCanvasCollector").GetComponent<Canvas>().enabled == true)
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speedCollector, transform.localPosition.z);
        if (CheckIfOnScreenCollector())
        {
            CounterCollector();
            onceSeenCollector = true;
        }
        if (onceSeenCollector)
        {
            if (!CheckIfOnScreenCollector()) { ResetCollector(); }
        }
        CounterCollector();
        CollisionCheckCollector();
    }
}
