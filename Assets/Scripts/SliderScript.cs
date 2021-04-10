using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderScript : MonoBehaviour
{
    #region Fields
    Slider slider;
    #endregion

    #region CustomMethods

    #endregion
	
    #region UnityMethods

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        //print(AudioManager.audioSource.volume);
        
        slider.value = AudioManager.audioSource.volume;
    }

    #endregion
}