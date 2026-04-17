using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Canvas titleCanvas;
    [SerializeField] private Canvas difficultyCanvas;
    [SerializeField] private Canvas highScoreCanvas;

    private void Awake()
    {
        SetActiveCanvas(0);
    }

    public void SetActiveCanvas(int canvas)
    {
        titleCanvas.gameObject.SetActive(false);
        difficultyCanvas.gameObject.SetActive(false);
        highScoreCanvas.gameObject.SetActive(false);
        switch (canvas)
        {
            case 0:
                titleCanvas.gameObject.SetActive(true);
                break;
            case 1:
                difficultyCanvas.gameObject.SetActive(true);
                break;
            case 2:
                highScoreCanvas.gameObject.SetActive(true);
                break;
        }
    }
}
