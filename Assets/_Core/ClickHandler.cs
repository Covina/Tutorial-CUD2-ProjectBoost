using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private SceneNavigationController sceneNavigationController;

    void Start()
    {
        sceneNavigationController = SceneNavigationController.instance;
    }

    public void GoToMainMenu()
    {
        sceneNavigationController.LoadMainMenu();
    }

    public void GoToNextLevel()
    {
        sceneNavigationController.LoadNextLevelInPack();
    }

    public void RetryLevel()
    {
        sceneNavigationController.ReloadLevel();
    }

    public void StartingLevelInPack(string levelPackName)
    {
        sceneNavigationController.LoadStartingLevelInPack(levelPackName);
    }

}
