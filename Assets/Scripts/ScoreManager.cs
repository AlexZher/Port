
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text[] textsOfBucket;

    [SerializeField] GameObject[] imagesOfEnd;
    int counterOfEmptyBuckets = 0;

    [SerializeField] GameObject panelOfEnd;
    [SerializeField] GameObject panelOfLose;
    [SerializeField] GameObject panelOfPlusMinusPoints;

    //score support
    GameObject highlightManager;
    [SerializeField] Text score;

    [SerializeField] Text boxesLeft;

    [SerializeField] Text plusPoints;
    [SerializeField] Text minusPoints;
    int newScoreShouldBe;
    Timer timerConvertPoints;

    int alreadyAddedBoxes;

    public static ScoreManager instance;
    string prefixsScore = "Score: ";
    string prefixsBoxes = "Boxes left: ";
    int pointsPerRightBucket;
    public static int pointsPerWrongBucket;
    public static int pointsPerDestroyBox;
    public static int pointsPerSkippedBox;

    void Start()
    {
        Configuration.isGameInAutoMode = false;
        Configuration.isGameOver = false;
        Configuration.isGameInAutoEnding = false;
        Configuration.isGameInProgress = true;
        alreadyAddedBoxes = 0;
        highlightManager = GameObject.FindGameObjectWithTag("highlighter");
        instance = this;
        // event manager support
        EventManager.AddListener(ChangeScoreOnBox);

        foreach (GameObject gmobj in imagesOfEnd)
        {
            gmobj.SetActive(false);
        }

        //score support
        switch (SpawnerUtils.difficulty)
        {
            case Difficulty.Easy:
                Configuration.actualBoxesLeft = Configuration.QueueOnEasyLevel.Length;
                boxesLeft.text = prefixsBoxes + Configuration.actualBoxesLeft;

                pointsPerRightBucket = Configuration.pointsPerRightBucketOnEasyLevel;
                pointsPerWrongBucket = Configuration.pointsPerWrongBucketOnEasyLevel;
                pointsPerDestroyBox = Configuration.pointsPerDestroyBoxOnEasyLevel;
                pointsPerSkippedBox = Configuration.pointsPerSkippedBoxOnEasyLevel;
                break;
            case Difficulty.Medium:
                Configuration.actualBoxesLeft = Configuration.QueueOnMediumLevel.Length;
                boxesLeft.text = prefixsBoxes + Configuration.actualBoxesLeft;

                pointsPerRightBucket = Configuration.pointsPerRightBucketOnMediumLevel;
                pointsPerWrongBucket = Configuration.pointsPerWrongBucketOnMediumLevel;
                pointsPerDestroyBox = Configuration.pointsPerDestroyBoxOnMediumLevel;
                pointsPerSkippedBox = Configuration.pointsPerSkippedBoxOnMediumLevel;
                break;
            case Difficulty.Hard:
                Configuration.actualBoxesLeft = Configuration.QueueOnHardLevel.Length;
                boxesLeft.text = prefixsBoxes + Configuration.actualBoxesLeft;

                pointsPerRightBucket = Configuration.pointsPerRightBucketOnHardLevel;
                pointsPerWrongBucket = Configuration.pointsPerWrongBucketOnHardLevel;
                pointsPerDestroyBox = Configuration.pointsPerDestroyBoxOnHardLevel;
                pointsPerSkippedBox = Configuration.pointsPerSkippedBoxOnHardLevel;
                break;
        }
        Configuration.actualPoints = 0;
    }

    void Update()
    {
        if (Configuration.isGameInProgress && (counterOfEmptyBuckets == imagesOfEnd.Length || Configuration.actualBoxesLeft == 0))
        {

            Configuration.isGameInAutoMode = true;
            Configuration.isGameInAutoEnding = true;
            Configuration.isGameInProgress = false;
            //bust current boxes
            Box[] tmp = GameObject.FindObjectsOfType<Box>();
            foreach (Box box in tmp)
            {
                box.Speed = 10f;
            }
            // stop spawner
            GameObject.FindGameObjectWithTag("Spawner").SetActive(false);

            highlightManager.SetActive(false);

        }

        if (Configuration.isGameInAutoEnding)
        {
            if (Configuration.isGameInAutoMode)
            {

                if (HighlightManager.instance.listOfCurrentBoxes.Count == 0)
                {
                    Configuration.isGameInAutoMode = false;

                    if (Configuration.actualBoxesLeft != 0)
                    {
                        newScoreShouldBe = Configuration.actualPoints + Configuration.actualBoxesLeft * pointsPerSkippedBox;
                        Configuration.isGameConvertsPoints = true;
                        panelOfPlusMinusPoints.SetActive(true);
                        plusPoints.text = "+" + Configuration.actualBoxesLeft;
                        minusPoints.text = "-" + Configuration.actualBoxesLeft;
                        timerConvertPoints = gameObject.AddComponent<Timer>();
                        timerConvertPoints.Duration = .08f;
                        timerConvertPoints.Run();
                        
                    }
                    else
                    {
                        Configuration.isGameConvertsPoints = false;
                        
                    }  
                }
            }

            if (Configuration.isGameConvertsPoints && timerConvertPoints.Finished)
            {
                UpdateBoxesLeftScore();
                UpdateScore(pointsPerSkippedBox);
                if (Configuration.actualPoints == newScoreShouldBe)
                {
                    panelOfPlusMinusPoints.SetActive(false);
                    Configuration.isGameConvertsPoints = false;
                }
                alreadyAddedBoxes ++;

                plusPoints.text = "+" + alreadyAddedBoxes * pointsPerSkippedBox;
                minusPoints.text = "-" + alreadyAddedBoxes;
                timerConvertPoints.Run();
                
            }

            if (!Configuration.isGameConvertsPoints && !Configuration.isGameInAutoMode)
            {
                //возврат настроек
                Configuration.isGameInAutoEnding = false;
                
                DecideWinOrLose();
            }
        }
    }

    public void ChangeScoreOnBox(int index)
    {
        int score = int.Parse(textsOfBucket[index].text);
        score--;
        if (score == 0)
        {
            textsOfBucket[index].text = "0";
            textsOfBucket[index].gameObject.SetActive(false);
            imagesOfEnd[index].SetActive(true);

            counterOfEmptyBuckets++;

            
            UpdateScore(pointsPerRightBucket);

        }
        else if (score > 0)
        {
            textsOfBucket[index].text = score.ToString();

            
            UpdateScore(pointsPerRightBucket);
        }

        UpdateBoxesLeftScore();


    }
    public void UpdateBoxesLeftScore()
    {
        Configuration.actualBoxesLeft--;
        boxesLeft.text = prefixsBoxes + Configuration.actualBoxesLeft;
    }
    public void UpdateScore(int points)
    {
        Configuration.actualPoints += points;
        score.text = prefixsScore + Configuration.actualPoints;
    }

    public void DecideWinOrLose()
    {
        Time.timeScale = 0;
        Configuration.isGameOver = true;
        if (counterOfEmptyBuckets != imagesOfEnd.Length)
        {
            panelOfLose.SetActive(true);
        }
        else
        {
            panelOfEnd.SetActive(true);
        }
        
    }
    public void GoToMenu()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
