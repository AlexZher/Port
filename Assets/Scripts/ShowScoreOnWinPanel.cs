using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScoreOnWinPanel : MonoBehaviour
{
    #region Fields
    [SerializeField]
    TextMeshProUGUI text;
    #endregion

    #region CustomMethods

    #endregion
	
    #region UnityMethods

    void Start()
    {
        text.text = "Your score is: " + Configuration.actualPoints;
    }

    #endregion
}