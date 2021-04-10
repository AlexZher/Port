using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HighlightManager : MonoBehaviour
{

    [SerializeField]
    Material mat;
    Texture texture;

    public static HighlightManager instance;
    public List<GameObject> listOfCurrentBoxes = new List<GameObject>();
    bool isHighlighted = false;
    int indexOfHighlightedBox;

    void SetTexture(int index, Texture texture)
    {
        if (listOfCurrentBoxes[index].transform.childCount != 0)
        {
            listOfCurrentBoxes[index].transform.Find("CubeLeft").GetComponent<Renderer>().material.mainTexture = texture;
            listOfCurrentBoxes[index].transform.Find("CubeRight").GetComponent<Renderer>().material.mainTexture = texture;
        }
        else
        {
            listOfCurrentBoxes[index].GetComponent<Renderer>().material.mainTexture = texture;
        }
    }
    public void AddToListOfCurrentBoxes(GameObject box)
    {
        listOfCurrentBoxes.Add(box);
    }

    public void RemoveFromListAndReHighlight(GameObject box)
    {
        int indexOfCurrentBox = listOfCurrentBoxes.IndexOf(box);

        //listOfCurrentBoxes[indexOfCurrentBox].GetComponent<Renderer>().material.mainTexture = null;
        SetTexture(indexOfCurrentBox, null);
        
        listOfCurrentBoxes.Remove(box);

        if (indexOfCurrentBox == indexOfHighlightedBox)
        {
            if (listOfCurrentBoxes.Count != 0) // if there are boxes on line
            {
                if (indexOfCurrentBox != 0) // if it isn't the first box
                    indexOfHighlightedBox--;
                else                        // if it is the first box
                    indexOfHighlightedBox = 0;

                //listOfCurrentBoxes[indexOfHighlightedBox].GetComponent<Renderer>().material.mainTexture = texture;
                SetTexture(indexOfHighlightedBox, texture);
                isHighlighted = true;
            }
            else
            {
                isHighlighted = false;
            } 
        }
        else
        {
            indexOfHighlightedBox--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        texture = mat.mainTexture;
    }

    // Update is called once per frame
    void Update()
    {
        // default highlight
        if (Configuration.isGameInAutoMode)
        {
            return;
        }
        if ((!isHighlighted) && (listOfCurrentBoxes.Count != 0))
        {
            //listOfCurrentBoxes[0].GetComponent<Renderer>().material.mainTexture = texture;
            SetTexture(0, texture);
            indexOfHighlightedBox = 0;
            isHighlighted = true;
        }

        // change highlighted box
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (indexOfHighlightedBox - 1 >= 0) // if there is available to highlight box 
            {
                //listOfCurrentBoxes[indexOfHighlightedBox].GetComponent<Renderer>().material.mainTexture = null;
                SetTexture(indexOfHighlightedBox, null);

                indexOfHighlightedBox += -1;

                //listOfCurrentBoxes[indexOfHighlightedBox].GetComponent<Renderer>().material.mainTexture = texture;
                SetTexture(indexOfHighlightedBox, texture);

            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (indexOfHighlightedBox + 1 < listOfCurrentBoxes.Count) // if there is available to highlight box 
            {
                //listOfCurrentBoxes[indexOfHighlightedBox].GetComponent<Renderer>().material.mainTexture = null;
                SetTexture(indexOfHighlightedBox, null);

                indexOfHighlightedBox += 1;

                //listOfCurrentBoxes[indexOfHighlightedBox].GetComponent<Renderer>().material.mainTexture = texture; 
                SetTexture(indexOfHighlightedBox, texture);
            }
        }

        //change box's direction
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (listOfCurrentBoxes.Count != 0) // cant move if there is no boxes on line
            {
                ChangeDirection(Directions.left);
                RemoveFromListAndReHighlight(listOfCurrentBoxes[indexOfHighlightedBox]);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (listOfCurrentBoxes.Count != 0) // cant move if there is no boxes on line
            {
                ChangeDirection(Directions.right);
                RemoveFromListAndReHighlight(listOfCurrentBoxes[indexOfHighlightedBox]);
            }
        }
    }

    private void ChangeDirection(Directions direction)
    {
        Vector3 newDirection;

        switch (direction)
        {
            case Directions.forward: 
                newDirection = Vector3.back;
                break;
            case Directions.left:
                newDirection = Vector3.left;
                break;
            case Directions.right:
                newDirection = Vector3.right;
                break;
            default:
                newDirection = Vector3.back;
                break;
        }

        listOfCurrentBoxes[indexOfHighlightedBox].GetComponent<Box>().direction = newDirection;
        
    }
}

