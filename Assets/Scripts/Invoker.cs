using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Invoker : MonoBehaviour
{
    private MessageEvent messageEvent;// = new MessageEvent();
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.GetComponent<Timer>();
        if (timer == null)
        {
            timer = gameObject.AddComponent<Timer>();
        }
        timer.setTimer(3);
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finish())
        {
            messageEvent.Invoke();
            timer.reset();
            timer.setTimer(2);
            timer.Run();
        }
    }

    void Awake()
    {
        messageEvent = new MessageEvent();
    }

    public void AddNoArgumentListener(UnityAction listener)
    {
        messageEvent.AddListener(listener);
    }
}
