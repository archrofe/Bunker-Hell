using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [Header("Bools")]
    public bool optionsBool;
    public bool loadBool;
    public bool options;
    public bool fullscreenBool;
    public bool makeFullscreen;
    public bool inGame;
    public bool pauseBool;
    public bool showPause;
    public bool musicPlay;

    [Header("GameObjects")]
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject loadMenu;
    public GameObject optionsPanel;
    public GameObject controlsPanel;

    [Header("Resolutions and Fullscreen")]
    public int index;
    public int[] resX, resY;
    public Dropdown resDropdown;
    public Toggle fullscreenToggle;

    [Header("Keys")]
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode heldKey;
    public Text forwardText, backwardText, leftText, rightText, jumpText;

    [Header("Music & Brightness")]
    public Slider volumeSlider;
    public Light brightness;
    public Slider brightSlider;
    public Toggle mute;
    private AudioSource music;

    [Header("Buttons")]
    public Button optionsButton;
    public Button controlsButton;

    public void Awake()
    {
        music = GetComponent<AudioSource>();
        if (musicPlay)
        {
            music.Play();
            musicPlay = false;
            
        }

    }

    public void OnGUI()
    {
        #region Keys
        Event e = Event.current;

        if (forward == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);

                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump))
                {
                    forward = e.keyCode;
                    heldKey = KeyCode.None;
                    forwardText.text = forward.ToString();
                }
                else
                {
                    forward = heldKey;
                    heldKey = KeyCode.None;
                    forwardText.text = forward.ToString();
                }
            }
        }

        if (backward == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);

                if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == right || e.keyCode == jump))
                {
                    backward = e.keyCode;
                    heldKey = KeyCode.None;
                    backwardText.text = backward.ToString();
                }
                else
                {
                    backward = heldKey;
                    heldKey = KeyCode.None;
                    backwardText.text = backward.ToString();
                }
            }
        }

        if (left == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);

                if (!(e.keyCode == backward || e.keyCode == forward || e.keyCode == right || e.keyCode == jump))
                {
                    left = e.keyCode;
                    heldKey = KeyCode.None;
                    leftText.text = left.ToString();
                }
                else
                {
                    left = heldKey;
                    heldKey = KeyCode.None;
                    leftText.text = left.ToString();
                }
            }
        }

        if (right == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);

                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == forward || e.keyCode == jump))
                {
                    right = e.keyCode;
                    heldKey = KeyCode.None;
                    rightText.text = right.ToString();
                }
                else
                {
                    right = heldKey;
                    heldKey = KeyCode.None;
                    rightText.text = right.ToString();
                }
            }
        }

        if (jump == KeyCode.None)
        {
            if (e.isKey)
            {
                Debug.Log("Key Code" + e.keyCode);

                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == forward))
                {
                    jump = e.keyCode;
                    heldKey = KeyCode.None;
                    jumpText.text = jump.ToString();
                }
                else
                {
                    jump = heldKey;
                    heldKey = KeyCode.None;
                    jumpText.text = jump.ToString();
                }
            }
        }
        #endregion
    }

    public void Start()
    {
        inGame = false;
        mute.enabled = true;
        #region Music and Brightness
        if (music != null && volumeSlider != null)
        {
            if (PlayerPrefs.HasKey("Volume"))
            {
                Load();
            }
            volumeSlider.value = music.volume;
        }
        if (brightness != null && brightSlider != null)
        {
            brightSlider.value = brightness.intensity;
        }
        #endregion
        #region Resolution
        index = PlayerPrefs.GetInt("Res", 3);
        int fullWindow = PlayerPrefs.GetInt("FullWindow", 1);
        if (fullWindow == 0)
        {
            makeFullscreen = false;
            fullscreenToggle.isOn = false;
        }
        else
        {
            makeFullscreen = true;
            fullscreenToggle.isOn = true;
        }
        resDropdown.value = index;
        Screen.SetResolution(resX[index], resY[index], makeFullscreen);
        #endregion
        #region Key Set Up
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));

        forwardText.text = forward.ToString();
        backwardText.text = backward.ToString();
        leftText.text = left.ToString();
        rightText.text = right.ToString();
        jumpText.text = jump.ToString();
        #endregion
    }

    public void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            mainMenu.SetActive(true);
            TogglePause();
        }


        if (mute.isOn)
        {
            if (volumeSlider.value != music.volume)
            {
                music.volume = volumeSlider.value;
            }
        }
        if (!mute.isOn)
        {
            music.volume = volumeSlider.minValue;
        }
        if (brightSlider.value != brightness.intensity)
        {
            brightness.intensity = brightSlider.value;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        inGame = true;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Volume", music.volume);
        PlayerPrefs.SetFloat("Brightness", brightness.intensity);
        PlayerPrefs.SetString("Forward", forward.ToString());
        PlayerPrefs.SetString("Backward", backward.ToString());
        PlayerPrefs.SetString("Left", left.ToString());
        PlayerPrefs.SetString("Right", right.ToString());
        PlayerPrefs.SetString("Jump", jump.ToString());

        PlayerPrefs.SetInt("Res", index);
        if (fullscreenBool)
        {
            PlayerPrefs.SetInt("FullWindow", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FullWindow", 0);
        }
    }

    public void Toggle()
    {
        Screen.fullScreen = !Screen.fullScreen;

        fullscreenBool = !fullscreenBool;
    }

    public void ResChange()
    {
        index = resDropdown.value;
        Screen.SetResolution(resX[index], resY[index], fullscreenBool);
    }

    public void Default()
    {
        brightSlider.value = brightSlider.maxValue;
        volumeSlider.value = volumeSlider.maxValue;
        #region Default Keys
        forward = KeyCode.W;
        backward = KeyCode.S;
        left = KeyCode.A;
        right = KeyCode.D;
        jump = KeyCode.Space;

        forwardText.text = forward.ToString();
        backwardText.text = backward.ToString();
        leftText.text = left.ToString();
        rightText.text = right.ToString();
        jumpText.text = jump.ToString();
        #endregion
    }

    public void Load()
    {
        music.volume = PlayerPrefs.GetFloat("Volume");
        brightness.intensity = PlayerPrefs.GetFloat("Brightness");
        #region Keys
        forwardText.text = PlayerPrefs.GetString("Forward");
        backwardText.text = PlayerPrefs.GetString("Backward");
        leftText.text = PlayerPrefs.GetString("Left");
        rightText.text = PlayerPrefs.GetString("Right");
        jumpText.text = PlayerPrefs.GetString("Jump");
        #endregion
    }

    public void ShowOptions()
    {
        ToggleOptions();

    }

    public bool ToggleOptions()
    {

        if (options)
        {
            optionsButton.interactable = true;
            controlsButton.interactable = false;
            optionsPanel.SetActive(true);
            controlsPanel.SetActive(false);
            options = false;
            return false;
        }
        else
        {
            optionsButton.interactable = false;
            controlsButton.interactable = true;
            optionsPanel.SetActive(false);
            controlsPanel.SetActive(true);
            options = true;
            return true;
        }
    }

    public void ShowLoadMenu()
    {
        ToggleLoadMenu();
    }

    public bool ToggleLoadMenu()
    {
        if (loadBool)
        {
            mainMenu.SetActive(true);
            loadMenu.SetActive(false);
            loadBool = false;
            return false;
        }
        else
        {
            mainMenu.SetActive(false);
            loadMenu.SetActive(true);
            loadBool = true;
            return true;
        }
    }

    public void ShowOptionsMenu()
    {
        ToggleOptionsMenu();
    }

    public bool ToggleOptionsMenu()
    {
        if (optionsBool)
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            optionsBool = false;
            return false;
        }
        else
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            optionsBool = true;
            return true;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    #region Controls
    public void Forward()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None))
        {
            heldKey = forward;
            forward = KeyCode.None;
            forwardText.text = forward.ToString();
        }
    }

    public void Backward()
    {
        if (!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None))
        {
            heldKey = backward;
            backward = KeyCode.None;
            backwardText.text = backward.ToString();
        }
    }

    public void Left()
    {
        if (!(backward == KeyCode.None || forward == KeyCode.None || right == KeyCode.None || jump == KeyCode.None))
        {
            heldKey = left;
            left = KeyCode.None;
            leftText.text = left.ToString();
        }
    }

    public void Right()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || forward == KeyCode.None || jump == KeyCode.None))
        {
            heldKey = right;
            right = KeyCode.None;
            rightText.text = right.ToString();
        }
    }

    public void Jump()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || forward == KeyCode.None))
        {
            heldKey = jump;
            jump = KeyCode.None;
            jumpText.text = jump.ToString();
        }
    }

    #endregion

    public void Resume()
    {
        TogglePause();
    }

    public bool TogglePause()
    {
        if (pauseBool)
        {
            if (!showPause)
            {
                Time.timeScale = 1;
                pauseBool = false;
                mainMenu.SetActive(false);
            }
            else
            {
                showPause = false;
                mainMenu.SetActive(true);
            }
            return false;
        }
        else
        {
            Time.timeScale = 0;
            pauseBool = true;
            mainMenu.SetActive(true);
            return true;
        }
    }
}
