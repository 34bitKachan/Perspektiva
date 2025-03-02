using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveSettingsGame
{
    public int _indexScreenResolutions;
    public int _levelSmoothing;
    public bool _isFullScreen;
    public float _mouseSensivity;
    private static string pathSave = Application.persistentDataPath + "/SettingsGame.json";
    public SaveSettingsGame(int indexScreenResolutions, int levelSmoothing, bool isFullScreen)
    {
        _indexScreenResolutions = indexScreenResolutions;
        _levelSmoothing = levelSmoothing;
        _isFullScreen = isFullScreen;
    }

    public float setSensivityMouse
    {
        set
        {
            _mouseSensivity = value;
            PlayerPrefs.SetFloat("SENSIVITY_MOUSE", _mouseSensivity);
        }
    }

    public static float getSensivityMouse()
    {
        return PlayerPrefs.GetFloat("SENSIVITY_MOUSE", 5f);
    }

    public static async void AsyncWriteSaveSettngs(SaveSettingsGame saveSettings)
    {
        string jsonSaveSettings = JsonUtility.ToJson(saveSettings);
        await File.WriteAllTextAsync(pathSave, jsonSaveSettings);
    }

    public static SaveSettingsGame ReadSaveSettings()
    {
        string fileContext;
        Debug.Log(pathSave);
        if (File.Exists(pathSave))
            fileContext = File.ReadAllText(pathSave);
        else return null;

        return JsonUtility.FromJson<SaveSettingsGame>(fileContext);
    }
}
