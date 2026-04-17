using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Canvas titleCanvas;
    [SerializeField] private Canvas difficultyCanvas;

    private void Awake()
    {
        SetActiveCanvas(0);
    }

    public void SetActiveCanvas(int canvas)
    {
        titleCanvas.gameObject.SetActive(false);
        difficultyCanvas.gameObject.SetActive(false);
        switch (canvas)
        {
            case 0:
                titleCanvas.gameObject.SetActive(true);
                break;
            case 1:
                difficultyCanvas.gameObject.SetActive(true);
                break;
        }
    }
}
