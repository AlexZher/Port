using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimationSpeed : MonoBehaviour
{
    #region Fields

    #endregion

    #region CustomMethods

    #endregion
	
    #region UnityMethods

    void Start()
    {
        
        switch(SpawnerUtils.difficulty)
        {
            case (Difficulty.Easy):
                gameObject.GetComponent<Animator>().SetFloat("SpeedScale", Configuration.AnimationSpeedOnEasyLevel);
                break;
            case (Difficulty.Medium):
                gameObject.GetComponent<Animator>().SetFloat("SpeedScale", Configuration.AnimationSpeedOnMediumLevel);
                break;
            case (Difficulty.Hard):
                gameObject.GetComponent<Animator>().SetFloat("SpeedScale", Configuration.AnimationSpeedOnHardLevel);
                break;
        }
    }

    
    void Update()
    {
        
    }

    #endregion
}