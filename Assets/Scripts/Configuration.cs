using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Configuration 
{
    #region Fields
    // timer support
    public static float TimerDurationOnEasyLevel = 1.5f;
    public static float TimerDurationOnMediumLevel = 1.5f;
    public static float TimerDurationOnHardLevel = 1f; 

    // animation speed support 0.9, 0.99

    public static float AnimationSpeedOnEasyLevel = 0.9f;
    public static float AnimationSpeedOnMediumLevel = 0.9f;
    public static float AnimationSpeedOnHardLevel = 1.12f;

    // box movement speed support
    public static float SpeedOnEasyLevel = 4f;
    public static float SpeedOnMediumLevel = 4f; 
    public static float SpeedOnHardLevel = 5f;

    // spawner queue support секундочку
    public static int[] QueueOnEasyLevel = new int[] {
        0,1,6,3,2,7,0,1,3,2,0,1,6,7,3,2,2,3,1,0,7,0,1,2,3,
        0,1,6,3,2,7,0,1,3,2,0,1,6,7,3,2,2,3,1,0,7,0,1,2,3,
        0,1,6,3,2,7,0,1,3,2,0,1,6,7,3,2,2,3,1,0,7,0,1,2,3
    };
    public static int[] QueueOnMediumLevel = new int[] {
        4,0,6,2,4,1,3,0,7,2,1,2,3,0,3,7,4,6,4,6,7,3,1,4,2,0,2,1,4,3,0,7,6,2,1,2,3,0,3,7,4,6,4,
        4,0,6,2,4,1,3,0,7,2,1,2,3,0,3,7,4,6,4,6,7,3,1,4,2,0,2,1,4,3,0,7,6,2,1,2,3,0,3,7,4,6,4,
        4,0,6,2,4,1,3,0,7,2,1,2,3,0,3,7,4,6,4,6,7,3,1,4,2,0,2,1,4,3,0,7,6,2,1,2,3,0,3,7,4,6,4,
        4,0,6,2,4,1,3,0,7,2,1,2,3,0,3,7,4,6,4,6,7,3,1,4,2,0,2,1,4,3,0,7,6,2,1,2,3,0,3,7,4,6,4
    };
    public static int[] QueueOnHardLevel = new int[] {
        0,1,2,5,4,3,4,6,1,3,5,7,0,2,3,1,5,7,4,2,6,0,7,6,7,6,7,6,7,6,0,1,2,5,4,3,0,6,2,4,7,5,1,3,
        0,1,2,5,4,3,4,6,1,3,5,7,0,2,3,1,5,7,4,2,6,0,7,6,7,6,7,6,7,6,0,1,2,5,4,3,0,6,2,4,7,5,1,3,
        0,1,2,5,4,3,4,6,1,3,5,7,0,2,3,1,5,7,4,2,6,0,7,6,7,6,7,6,7,6,0,1,2,5,4,3,0,6,2,4,7,5,1,3,
        0,1,2,5,4,3,4,6,1,3,5,7,0,2,3,1,5,7,4,2,6,0,7,6,7,6,7,6,7,6,0,1,2,5,4,3,0,6,2,4,7,5,1,3,
        0,1,2,5,4,3,4,6,1,3,5,7,0,2,3,1,5,7,4,2,6,0,7,6,7,6,7,6,7,6,0,1,2,5,4,3,0,6,2,4,7,5,1,3
    };
    // score support

    public static int pointsPerRightBucketOnEasyLevel = 4;
    public static int pointsPerRightBucketOnMediumLevel = 6;
    public static int pointsPerRightBucketOnHardLevel = 9;

    public static int pointsPerWrongBucketOnEasyLevel = -1;
    public static int pointsPerWrongBucketOnMediumLevel = -2;
    public static int pointsPerWrongBucketOnHardLevel = -2;

    public static int pointsPerDestroyBoxOnEasyLevel = -3;
    public static int pointsPerDestroyBoxOnMediumLevel = -4;
    public static int pointsPerDestroyBoxOnHardLevel = -4;

    public static int pointsPerSkippedBoxOnEasyLevel = 1;
    public static int pointsPerSkippedBoxOnMediumLevel = 2;
    public static int pointsPerSkippedBoxOnHardLevel = 2;

    
    //состояние игры support
    public static int actualBoxesLeft;
    public static int actualPoints;
    public static bool isGameInAutoMode;
    public static bool isGameOver;
    public static bool isGameConvertsPoints;
    public static bool isGameInAutoEnding;
    public static bool isGameInProgress;
    public static bool isBackGroundMusicInitialized = false;
    // id support
    // 0...5 - разноцветные корзины
    // 6 - черная коробка
    // 7 - void
    // 8 - destroyer
    // 9 - 
    #endregion

}