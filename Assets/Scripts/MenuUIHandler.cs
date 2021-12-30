using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inputFieldText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = DataManager.Instance.GetBestProfile();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartToPlay()
    {
        RegisterPlayerName();
        SceneManager.LoadScene(1);
    } 

    void RegisterPlayerName()
    {
        DataManager.Instance.UserName = inputFieldText.text;
    } 



    public void Exit()
    {
        DataManager.Instance.SaveBestProfile();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
