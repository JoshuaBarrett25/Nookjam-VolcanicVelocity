using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    EventSystem m_EventSystem;
    public GameObject optionButton;
    public GameObject MenuButton;

    void Start()
    {
        m_EventSystem = EventSystem.current;
    }
    public void OptionTransition()
    {
        m_EventSystem.SetSelectedGameObject(optionButton);
    }
    public void MenuTransition()
    {
        m_EventSystem.SetSelectedGameObject(MenuButton);
    }
    public void LoadScene()
    {

        SceneManager.LoadScene(1);
    }
    public void ReturnScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ScoreScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
