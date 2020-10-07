using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private int sceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        menuButton.onClick.AddListener(LoadGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
