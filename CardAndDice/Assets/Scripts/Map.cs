using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

   // public string[] ZoneNames;


    public Button ZoneButton;
    public GameObject Marker;

    public GameObject MapPanel;


    void Start()
    {
      
        if(GameFileManager.GameFile == null)
        {
            GameFileManager.Load();
        }

        Build();
    }

   
    public void Build()
    {
        Vector2Int location = new Vector2Int(GameFileManager.GameFile.X, GameFileManager.GameFile.Y);
        Random.InitState(GameFileManager.GameFile.Seed);


        for(int x = -4; x < 5; x++)
        {
            for (int y = -4; y < 5; y++)
            {
                if(location != new Vector2Int(x, y))
                {

                    int level = 10-(Mathf.Abs(x) + Mathf.Abs(y));


                    Zone zone = EquipmentManager.instance.Get(level);

                    if(x ==0 && y == 0)
                    {
                        zone = EquipmentManager.instance.Castle;
                    }

                    var btn = Instantiate(ZoneButton, MapPanel.transform);
                    btn.GetComponent<Image>().sprite = zone.Sprite;

                    int X = x;
                    int Y = y;

                    btn.onClick.AddListener(delegate { SetNewLocation(new Vector2Int(X, Y), zone.Get()); });

                    if(Mathf.Abs(location.x - x)<=1 && Mathf.Abs(location.y - y) <= 1)
                    {
                        btn.interactable = true;
                    }
                    else
                    {
                        btn.interactable = false;
                    }

                }
                else
                {
                    Instantiate(Marker, MapPanel.transform);
                }
               
            }
        }



        Random.InitState((int)System.DateTime.Now.Ticks);
    }



    public void SetNewLocation(Vector2Int location,List<Equipment> opponent)
    {
        GameFileManager.GameFile.X = location.x;
        GameFileManager.GameFile.Y = location.y;
        GameFileManager.GameFile.Opponent = opponent;
        SceneManager.LoadScene("Battle");
        GameFileManager.Save();


    }


}
