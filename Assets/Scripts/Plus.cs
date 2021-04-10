using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Plus : MonoBehaviour
{
    #region Fields
    
    #endregion

    #region CustomMethods

    #endregion

    #region UnityMethods

    void Start()
    {
        
    }

    
    void Update()
    {
        Color alpha = gameObject.GetComponent<Text>().color;
        alpha.a += Time.deltaTime;
        if (alpha.a >= 1)
        {
            return;
        }
        else
        {
            gameObject.GetComponent<Text>().color = alpha;
        }
    }

    #endregion
}