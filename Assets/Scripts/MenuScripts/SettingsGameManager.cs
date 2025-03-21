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
    [SerializeField] Slider _sliderMouseSensivity;
    [SerializeField] Slider _sliderSound;
    [SerializeField] Slider _sliderSoundEffects;
    [SerializeField] TMP_Text _textSound;
    [SerializeField] TMP_Text _textSoundEffects;
    [SerializeField] TMP_Text _textMouseSensivity;
    [SerializeField] TMP_Text _apply_text;

    [SerializeField] SaveSettingsGame saveSettingsGame = null;
    private Color _startColorApplyBtn;


    private void Update() {

        _textSoundEffects.text =_sliderSoundEffects.value.ToString("F2");
        _textSound.text =_sliderSound.value.ToString("F2");
        PlayerPrefs.SetFloat("SoundEffects", _sliderSoundEffects.value);
        PlayerPrefs.SetFloat("Sound", _sliderSound.value);

        Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
        
    }
    private void Start()
    {
        if( PlayerPrefs.GetFloat("SoundEffects") == 0)
        {
             PlayerPrefs.SetFloat("SoundEffects", 0.9f);
             PlayerPrefs.SetFloat("Sound", 0.9f);
        }

         _sliderSoundEffects.value = PlayerPrefs.GetFloat("SoundEffects");
       _sliderSound.value = PlayerPrefs.GetFloat("Sound");
        _ScreenRes = Screen.resolutions;
        Resolution currentRes = Screen.currentResolution;
        int indxCurrentRes = 0;
        bool isCurrentScreen = false;

        foreach (Resolution screen in _ScreenRes)
        {
            _listScreenResolutions.Add(screen.width + "x" + screen.height);
            if (currentRes.width == screen.width && currentRes.height == screen.height && !isCurrentScreen)
                isCurrentScreen = true;
            else if (!isCurrentScreen) indxCurrentRes++;
        }

        Debug.Log("index resolutions " + indxCurrentRes);
        _dropdownScreenResolutions.ClearOptions();
        _dropdownScreenResolutions.AddOptions(_listScreenResolutions);

        _startColorApplyBtn = _apply_text.color;

        saveSettingsGame = SaveSettingsGame.ReadSaveSettings();
        if (saveSettingsGame == null)
        {
            _dropdownScreenResolutions.value = indxCurrentRes;
            QualitySettings.antiAliasing = 0;
            _dropdownSmoothing.value = 0;
            _tooggleFullScreen.isOn = true;
            return;
        }
        _dropdownSmoothing.value = saveSettingsGame._levelSmoothing;
        QualitySettings.antiAliasing = getAntiAlisaingDropDown();
        Screen.fullScreen = saveSettingsGame._isFullScreen;
        _tooggleFullScreen.isOn = saveSettingsGame._isFullScreen;
        _dropdownScreenResolutions.value = saveSettingsGame._indexScreenResolutions;
        saveSettingsGame._mouseSensivity = SaveSettingsGame.getSensivityMouse();
        _sliderMouseSensivity.value = saveSettingsGame._mouseSensivity;

        
    }

    public void OnChangesInSettings ()
    {
        Debug.Log("Nachali");
        if (_dropdownScreenResolutions.value != saveSettingsGame._indexScreenResolutions)
            _apply_text.color = new Color(255, 255, 255, 255);
        else _apply_text.color = _startColorApplyBtn;
        if (_dropdownSmoothing.value != saveSettingsGame._levelSmoothing)
            _apply_text.color = new Color(255, 255, 255, 255);
        else _apply_text.color = _startColorApplyBtn;
        if (_tooggleFullScreen.isOn != saveSettingsGame._isFullScreen)
            _apply_text.color = new Color(255, 255, 255, 255);
        else _apply_text.color = _startColorApplyBtn;
        if (_sliderMouseSensivity.value != saveSettingsGame._mouseSensivity)
            _apply_text.color = new Color(255, 255, 255, 255);
        else _apply_text.color = _startColorApplyBtn;
    }

    public void OnTabSliderSensivity()
    {
        _textMouseSensivity.text = _sliderMouseSensivity.value.ToString("F2");
    }

    public void OnSettingsApply()
    {
        if (_apply_text.color == _startColorApplyBtn) return;
        int indx = _dropdownScreenResolutions.value;
        SaveSettingsGame saveSettings = new SaveSettingsGame(indx, _dropdownSmoothing.value, _tooggleFullScreen.isOn);
        float sensivity = _sliderMouseSensivity.value;

        Debug.Log(sensivity + "Sensivity okr");
        saveSettings.setSensivityMouse = sensivity;

        SaveSettingsGame.AsyncWriteSaveSettngs(saveSettings);
        Screen.fullScreen = _tooggleFullScreen.isOn;
        Screen.SetResolution(_ScreenRes[indx].width, _ScreenRes[indx].height, _tooggleFullScreen.isOn);
        QualitySettings.antiAliasing = getAntiAlisaingDropDown();
        _apply_text.color = _startColorApplyBtn;

        

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



