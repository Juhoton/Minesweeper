using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class Tile : MonoBehaviour
{
    public int x;
    public int y;
    public bool isMine = false;
    public bool isRevealed = false;
    public bool isFlagged = false;
    public int adjacentMines;

    public void Reveal()
    {
        if (isMine)
        {
            Debug.Log("Get slimed nerd");
            GetComponent<SpriteRenderer>().color = Color.red;
            isRevealed = true;
        }
        else
        {
            Debug.Log("Ei oo miinaa");
            GetComponent<SpriteRenderer>().color = Color.black;
            isRevealed = true;
        }
    }

    public void Flag()
    {
        if (isRevealed)
            return;
        if (isFlagged)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            isFlagged = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            isFlagged = true;
        }
    }

    public void ShowAdcjacentMines()
    {
        {
            if (isMine)
            {
                GetComponentInChildren<TextMeshPro>().text = "X";
            } else
            {
                GetComponentInChildren<TextMeshPro>().text = adjacentMines.ToString();
            }
        }
    }
    public void HideAdjacentMines()
    {
        GetComponentInChildren<TextMeshPro>().text = "";
    }
}