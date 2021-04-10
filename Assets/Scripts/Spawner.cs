using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBox;

    [SerializeField]
    GameObject prefabDualBox;

    [SerializeField]
    Material[] materials;

    float TimerDuration;

    List<int> queue;

    Timer timer;

    int countOfDifferentColors;

    void Start()
    {
        switch (SpawnerUtils.difficulty)
        {
            case Difficulty.Easy:
                TimerDuration = Configuration.TimerDurationOnEasyLevel;
                queue = Configuration.QueueOnEasyLevel.ToList<int>();
                countOfDifferentColors = 4;
                break;
            case Difficulty.Medium:
                TimerDuration = Configuration.TimerDurationOnMediumLevel;
                queue = Configuration.QueueOnMediumLevel.ToList<int>();
                countOfDifferentColors = 5;
                break;
            case Difficulty.Hard:
                TimerDuration = Configuration.TimerDurationOnHardLevel;
                queue = Configuration.QueueOnHardLevel.ToList<int>();
                countOfDifferentColors = 6;
                break;
        }

        timer = GetComponent<Timer>();
        timer.Duration = TimerDuration;
        timer.Run();
    }
    int[] GetTwoRandomNumbers()
    {
        int a = Random.Range(0, countOfDifferentColors);
        int b = Random.Range(0, countOfDifferentColors);
        if (a != b)
        {
            return new int[] { a, b };
        }
        else
        {
            if (a == 0)
                return new int[] { a + 1, b };
            else
                return new int[] { a - 1, b };
        }
    }
    void Update()
    {
        if (timer.Finished)
        {
            //если в очереди ещё что-то есть то создать
            if (queue.Count != 0)
            {
                GameObject box;

                if (queue[0] != 7)
                {
                    // create the common box
                    box = Instantiate(prefabBox, transform.position, Quaternion.identity) as GameObject;

                    box.GetComponent<Renderer>().material.color = materials[queue[0]].color;
                    box.GetComponent<Box>().color = new Color[] { Color.black, materials[queue[0]].color};
                    box.GetComponent<Box>().Id = new int[] {-1, queue[0] };
                }
                else
                {
                    box = Instantiate(prefabDualBox, transform.position, Quaternion.identity) as GameObject;
                    int[] id = GetTwoRandomNumbers();
                    box.transform.Find("CubeRight").GetComponent<Renderer>().material.color = materials[id[0]].color;
                    box.transform.Find("CubeLeft").GetComponent<Renderer>().material.color = materials[id[1]].color;
                    box.GetComponent<Box>().Id = id;
                    box.GetComponent<Box>().color = new Color[] { materials[id[0]].color, materials[id[1]].color};
                }

                HighlightManager.instance.AddToListOfCurrentBoxes(box);
               
                queue.RemoveAt(0);

                //restart timer
                timer.Duration = TimerDuration;
                timer.Run();
            }
        }
    }

}
