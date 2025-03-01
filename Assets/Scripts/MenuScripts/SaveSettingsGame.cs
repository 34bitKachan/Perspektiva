
using System;

[Serializable]
public class SaveSettingsGame
{
    public int _indexScreenResolutions;
    public int _levelSmoothing;
    public bool _isFullScreen;

    public SaveSettingsGame(int indexScreenResolutions, int levelSmoothing, bool isFullScreen)
    {
        _indexScreenResolutions = indexScreenResolutions;
        _levelSmoothing = levelSmoothing;
        _isFullScreen = isFullScreen;
    }
}
