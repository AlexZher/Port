﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The event manager
/// </summary>
public class EventManager : MonoBehaviour
{
    #region Fields

    // save lists of invokers and listeners
    static List<Box> invokers = new List<Box> ();
    static List<UnityAction<int>> listeners = new List<UnityAction<int>> ();

    #endregion

    #region Public methods

    /// <summary>
    /// Adds the given script as an invoker
    /// </summary>
    /// <param name="invoker">the invoker</param>
    public static void AddInvoker(Box invoker)
    {
        // add invoker to list and add all listeners to invoker
        invokers.Add(invoker);
        foreach (UnityAction<int> listener in listeners)
        {
            invoker.AddListener(listener);
        }
    }

    /// <summary>
    /// Adds the given event handler as a listener
    /// </summary>
    /// <param name="handler">the event handler</param>
    public static void AddListener(UnityAction<int> handler)
    {       
        // add listener to list and to all invokers
        listeners.Add(handler);
        foreach (Box invoker in invokers)
        {
            invoker.AddListener(handler);
        }
    }

    #endregion
}
