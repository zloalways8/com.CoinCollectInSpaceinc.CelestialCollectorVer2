
using System;
using UnityEngine;


public class RocketMoveCollector : MonoBehaviour
{

    public Vector3 rocketPositionCollector;
    private float screenWidthCollector;

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
    public void InitRocketCollector()
    {
        screenWidthCollector = Camera.main.orthographicSize * Camera.main.aspect;
        rocketPositionCollector = transform.localPosition;
        CounterCollector();
    }


    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touchCollector = Input.GetTouch(0);
            Vector3 touchPositionCollector = Camera.main.ScreenToWorldPoint(touchCollector.position);
            touchPositionCollector.z = 0; 

            transform.position = new Vector3(touchPositionCollector.x, transform.position.y, transform.position.z);
            rocketPositionCollector = transform.localPosition;
        }

        float paddleWidth = GetComponent<Renderer>().bounds.extents.x;
        float screenLeft = -screenWidthCollector + paddleWidth;
        float screenRight = screenWidthCollector - paddleWidth;

        Vector3 paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, screenLeft, screenRight);
        transform.position = paddlePosition;
        
    }
}

