using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderBackGroundMusic : MonoBehaviour
{
    #region Fields
    [SerializeField] Slider slider;
    #endregion

    #region CustomMethods
    public void SetBackGroundVolume(float vol)
    {
        GameObject.FindGameObjectWithTag("BackGroundMusic").GetComponent<AudioSource>().volume = vol;
    }
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        //print(AudioManager.audioSource.volume);

        slider.value = GameObject.FindGameObjectWithTag("BackGroundMusic").GetComponent<AudioSource>().volume;
    }
    #endregion

    #region UnityMethods

    #endregion
}