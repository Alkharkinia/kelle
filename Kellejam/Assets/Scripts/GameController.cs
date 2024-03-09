using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;
    private GridSpaceScript playerButton;

    public Timer timer;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        timer.OnTimerExpired += OnTimerExpired;
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            GridSpaceScript gridSpace = buttonList[i].GetComponentInParent<GridSpaceScript>();
            if (gridSpace != null)
            {
                gridSpace.SetGameControllerReference(this);
                if (i == 0)
                {
                    playerButton = gridSpace;
                }
            }
            else
            {
                Debug.Log("GridSpaceScript component not found on parent of button " + i);
            }
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        
    }

    public void StartTimer()
    {
        timer.StartTimer();
    }

    public void OnTimerExpired()
    {
        SelectAndHighlightButtons();
        Debug.Log("Timer expired!");
    }

    
    
    private void SelectAndHighlightButtons()
    {
        
        int computerButtonIndex1;
        int computerButtonIndex2;
        do
        {
            computerButtonIndex1 = Random.Range(0, buttonList.Length);
            computerButtonIndex2 = Random.Range(0, buttonList.Length);
        } while (computerButtonIndex1 == computerButtonIndex2);

        
        GridSpaceScript computerButton1 = buttonList[computerButtonIndex1].GetComponentInParent<GridSpaceScript>();
        GridSpaceScript computerButton2 = buttonList[computerButtonIndex2].GetComponentInParent<GridSpaceScript>();

        
        computerButton1.HighlightButton(computerButton1.highlightColor);
        computerButton2.HighlightButton(computerButton2.highlightColor);

        
        if (playerButton != null)
        {
            

            if (playerButton == computerButton1)
            {
                
                playerButton.OverlapButton(playerButton.overlapColor);
                computerButton1.OverlapButton(computerButton1.overlapColor);
                computerButton2.HighlightButton(computerButton2.highlightColor);
                Debug.Log("Player-chosen button overlaps with a randomly chosen button.");
            }

            else if (playerButton == computerButton2)
            {

                playerButton.OverlapButton(playerButton.overlapColor);
                computerButton2.OverlapButton(computerButton2.overlapColor);
                computerButton1.HighlightButton(computerButton1.highlightColor);
                Debug.Log("Player-chosen button overlaps with a randomly chosen button.");


            }
        }
        else
        {
            Debug.LogError("Player button reference is null.");
        }
    }

}

