using UnityEngine;

public class DifficultySelection
{
    public static int difficulty = 0;
    private static readonly string difficulty0 = "easy";
    private static readonly string difficulty1 = "medium";
    private static readonly string difficulty2 = "hard";

    public static string GetDifficultyName()
    {
        return GetSpecificDifficultyName(difficulty);
    }
    public static string GetSpecificDifficultyName(int x)
    {
        switch (x)
        {
            case 0:
                return difficulty0;
            case 1:
                return difficulty1;
            case 2:
                return difficulty2;
        }
        return "error";
    }
}
