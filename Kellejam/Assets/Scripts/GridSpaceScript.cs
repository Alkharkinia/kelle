using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpaceScript : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    public Color highlightColor = Color.yellow;
    public Color overlapColor = Color.red;

    private GameController gameController;
    private static bool buttonPressed = false;

    private void Start()
    {
        button.interactable = true;
    }

    public void SetSpace()
    {
        if (gameController != null && !buttonPressed)
        {
            buttonPressed = true;
            buttonText.text = gameController.GetPlayerSide();
            button.interactable = false;

            gameController.EndTurn();
        }
        else
        {
            Debug.LogError("GameController reference is null in GridSpaceScript or button already pressed!");
        }
    }

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

    public void HighlightButton(Color highlightColor)
    {
        var colors = button.colors;
        colors.normalColor = highlightColor;
        button.colors = colors;
        Debug.Log("HighlightButton called - Color changed to: " + highlightColor);
    }


    public void OverlapButton(Color overlapColor)
    {
        button.image.color = overlapColor;
        Debug.Log("OverlapButton called - Color changed to: " + overlapColor);
    }

}
