using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainMenu : MonoBehaviour
{

    public GameObject ContinueAdventureButton;


    void Start()
    {

        if (GameFileManager.Exists("Adventure"))
        {
            ContinueAdventureButton.SetActive(true);
        }
        else
        {
            ContinueAdventureButton.SetActive(false);
        }
        
    }

   
    public void ContinueAdventure()
    {
        GameFileManager.Load();
        SceneManager.LoadScene("Map");

    }

    public void NewAdventure()
    {

        GameFile gameFile = new GameFile();
        gameFile.X = -4;
        gameFile.Y = -4;
        gameFile.Equipment = EquipmentManager.instance.Player.Get();//StartingSet(10);

        GameFileManager.GameFile = gameFile;
        GameFileManager.Save();
        SceneManager.LoadScene("Map");
    }

}
