using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsGameManager : MonoBehaviour
{
    List<string> _listScreenResolutions = new List<string>();
    Resolution[] _ScreenRes;

    [SerializeField] TMP_Dropdown _dropdownScreenResolutions;
    [SerializeField] TMP_Dropdown _dropdownSmoothing;
    [SerializeField] Toggle _tooggleFullScreen;
    
    [SerializeField]
    SaveSettingsGame saveSettingsGame;

    private void Awake()
    {
        _ScreenRes = Screen.resolutions;
        Resolution currentRes = Screen.currentResolution;
        int indxCurrentRes = 0;
        bool isCurrentScreen = false;

        foreach (Resolution screen in _ScreenRes)
        {
            _listScreenResolutions.Add(screen.width + "x" + screen.height);
            Debug.Log(screen.width + "x" + screen.height);
            if (currentRes.width == screen.width && currentRes.height == screen.height && !isCurrentScreen)
                isCurrentScreen = true;
            else if(!isCurrentScreen) indxCurrentRes++;
        }
        Debug.Log("index resolutions " + indxCurrentRes);
        _dropdownScreenResolutions.ClearOptions();
        _dropdownScreenResolutions.AddOptions(_listScreenResolutions);
        _dropdownScreenResolutions.value = indxCurrentRes;
        Debug.Log("AntiAling" + QualitySettings.antiAliasing);
        QualitySettings.antiAliasing = 0;
        string pathFileSettings = Application.persistentDataPath + "/SettingsGame.json";
        string fileContext = "";

        if (File.Exists(pathFileSettings))
            fileContext = File.ReadAllText(pathFileSettings);
        else return;

        saveSettingsGame = JsonUtility.FromJson<SaveSettingsGame>(fileContext);
        _dropdownSmoothing.value = saveSettingsGame._levelSmoothing;
        QualitySettings.antiAliasing = getAntiAlisaingDropDown();

        Screen.fullScreen = saveSettingsGame._isFullScreen;
        _tooggleFullScreen.isOn = saveSettingsGame._isFullScreen;
        _dropdownScreenResolutions.value = saveSettingsGame._indexScreenResolutions;

    }


    public void OnSettingsApply()
    {
        Screen.fullScreen = _tooggleFullScreen.isOn;
        int indx = _dropdownScreenResolutions.value;
        Screen.SetResolution(_ScreenRes[indx].width, _ScreenRes[indx].height, _tooggleFullScreen.isOn);
        QualitySettings.antiAliasing = getAntiAlisaingDropDown();
        Debug.Log("Video apply");

        SaveSettingsGame saveSettings = new SaveSettingsGame(indx, _dropdownSmoothing.value, _tooggleFullScreen.isOn);
        string jsonSaveSettings = JsonUtility.ToJson(saveSettings);

        File.WriteAllText(Application.persistentDataPath + "/SettingsGame.json", jsonSaveSettings);
        Debug.Log(Application.persistentDataPath + "/SettingsGame.json");
    }

    private int getAntiAlisaingDropDown()
    {
        int value = _dropdownSmoothing.value;
        if (value == 0)
            return 0;
        if (value == 1)
            return 2;
        if (value == 2)
            return 3;
        return 4;
    }

}



