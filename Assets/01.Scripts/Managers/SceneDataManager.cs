using UnityEngine;

public class SceneDataManager : MonoSingleton<SceneDataManager>
{
    private int _storyLevel;

    public int StoryLevel
    {
        get => _storyLevel;
        set
        {
            _storyLevel = value;
        }
    }
}
