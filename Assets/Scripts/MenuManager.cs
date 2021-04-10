using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class MenuManager : MonoBehaviour
{
    #region Fields
    //difficulty panel
    [SerializeField]
    Button easyButton;

    [SerializeField]
    Button mediumButton;

    [SerializeField]
    Button hardButton;

    [SerializeField]
    Button backDifficulty;

    //main menu panel
    [SerializeField]
    Button start;
    [SerializeField]
    Button help;
    [SerializeField]
    Button quit;
    [SerializeField]
    Button options;

    //help panel
    [SerializeField]
    Button backHelp;

    //options panel
    [SerializeField]
    Button backOptions;

    #endregion

    #region CustomMethods

    #endregion

    #region UnityMethods

    void Start()
    {
        easyButton.onClick.AddListener(()=> { SpawnerUtils.SetDifficulty(Difficulty.Easy); });
        easyButton.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); }); 

        mediumButton.onClick.AddListener(() => { SpawnerUtils.SetDifficulty(Difficulty.Medium); });
        mediumButton.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); });

        hardButton.onClick.AddListener(() => { SpawnerUtils.SetDifficulty(Difficulty.Hard); });
        hardButton.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); });

        backDifficulty.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); });
        start.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); });
        help.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); });
        quit.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); });
        options.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); });
        backHelp.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); });
        backOptions.onClick.AddListener(() => { AudioManager.Play(AudioClipName.MenuButtonClick); });
    }


    void Update()
    {
      
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}