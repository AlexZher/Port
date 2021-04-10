using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class AnimatingWindow : MonoBehaviour
{
    #region Fields
    
    float smoothness = 0;
    int direction = 1;
    float speed = 0.2f;
    Timer timer;
    #endregion

    #region CustomMethods

    #endregion
	
    #region UnityMethods

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = Random.Range(0f, .1f);
        timer.Run();
    }

    
    void Update()
    {
        if (timer.Finished)
        {
            if (smoothness + speed * direction >= 1 || smoothness + speed * direction <= 0)
            {
                direction *= -1;
            }
            else
            {
                smoothness += speed * direction;
                Material material = GetComponent<Renderer>().sharedMaterial;
                material.SetFloat("_Glossiness", smoothness);
            }
            timer.Duration = Random.Range(0f, .1f);
            timer.Run();
        }
    }

    #endregion
}