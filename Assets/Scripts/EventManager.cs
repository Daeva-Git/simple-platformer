using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static ArrayList eventListeners = new ArrayList();

    public static void RegisterListener(EventListener eventListener)
    {
        eventListeners.Add(eventListener);
    }

    private void Update ()
    {
        
    }
}
