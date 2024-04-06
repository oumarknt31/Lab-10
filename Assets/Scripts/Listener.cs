using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoker invoker = Camera.main.GetComponent<Invoker>();
        if (invoker != null)
        {
            invoker.AddNoArgumentListener(PrintMessage);
        }
        else
        {
            Debug.Log("Invoker not accessible");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrintMessage()
    {
        Debug.Log("Roger");
    }
}
