using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    #region Fields

    #endregion

    #region CustomMethods

    #endregion

    #region UnityMethods
    void Awake()
    {
        //make sure we only have one of this game object
        // in the game
        if (!Configuration.isBackGroundMusicInitialized)
        {
            Configuration.isBackGroundMusicInitialized = true;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // duplicate game object, so destroy
            Destroy(gameObject);
        }
    }


}

    #endregion

