using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    private float elapsedTime = 0;
    private float timeCount = 0;
    //private float duration = 0;
    private bool isRunning = false;

    public float ElapsedTime { get => elapsedTime; }
    // Start is called before the first frame update
    void Start()
    {

    }

    //
    public void setTimer(float val)
    {
        timeCount = val;
        //duration = 0;
    }



    //
    public void Run()
    {
        isRunning = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
        }
        if (elapsedTime >= timeCount)
        {
            //Debug.Log("Time is up, The Object is proceding to be deleted");
            isRunning = false;
        }

        return;
    }

    public bool Finish()
    {
        return isRunning;
    }

    public void reset()
    {
        elapsedTime = 0;
        isRunning = false;
    }
}