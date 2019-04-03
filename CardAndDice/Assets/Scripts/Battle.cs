using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{

    public DataDisplay LeftHealth;
    public DataDisplay RightHealth;
    public DataDisplay LeftDefence;
    public DataDisplay RightDefence;
    public DataDisplay LeftActions;
    public DataDisplay RightActions;
    public DataDisplay LeftPower;
    public DataDisplay RightPower;
    public GameObject LeftMarker;
    public GameObject RightMarker;
    public GameObject LeftBuffs;
    public GameObject RightBuffs;

    public Entity Left;
    public Entity Right;

    Entity Attacker;
    Entity Defender;

    public GameObject HandDisplay;
    public Button CardButton;
    public Text BuffText;

    bool PlayersTurn = false;

   
    private void Start()
    {
        int dis = (Mathf.Abs(GameFileManager.GameFile.X) + Mathf.Abs(GameFileManager.GameFile.Y));
        Debug.Log(dis);
        Right.Equipment = GameFileManager.GameFile.Opponent.ToArray(); // EquipmentManager.instance.Get(GameFileManager.GameFile.Zone, dis);
        Left.Equipment = GameFileManager.GameFile.Equipment.ToArray();
        Left.SetUp();
        Right.SetUp();
        UpdateDisplay();
        Next();
    }

    public void Next()
    {
        PlayersTurn = !PlayersTurn;
        if (PlayersTurn)
        {
            LeftMarker.SetActive(true);
            RightMarker.SetActive(false);

            Attacker = Left;
            Defender = Right;
            BeginTurn();
        }
        else
        {
            RightMarker.SetActive(true);
            LeftMarker.SetActive(false);
          
            Attacker = Right;
            Defender = Left;
            BeginTurn();
        }
       

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Right.HealthPoints = 0;
            CheckBattleState();
        }
    }

    void DisplayHand()
    {
        for(int i = HandDisplay.transform.childCount; i > 0; i--)
        {
            Destroy(HandDisplay.transform.GetChild(i-1).gameObject);
        }

        foreach(Card card in Attacker.Hand)
        {
            if (card != null)
            {
                var btn = Instantiate(CardButton, HandDisplay.transform);
                btn.GetComponent<CardButton>().Display(card);

                if(card.Cost> Attacker.Actions || !PlayersTurn || card.PowerRequired > Attacker.PowerPoints)
                {
                    btn.interactable = false;
                }
         
                btn.onClick.AddListener(delegate { Play(card); });
                btn.onClick.AddListener(delegate { Destroy(btn.gameObject); });
            }
        }
    }



    void DisplayBuffs(Entity entity,GameObject display)
    {
        for (int i = display.transform.childCount; i > 0; i--)
        {
            Destroy(display.transform.GetChild(i - 1).gameObject);
        }

        foreach(Buff buff in entity.Buffs)
        {
            var txt = Instantiate(BuffText, display.transform);
            txt.text = buff.Description.AddColour();
        }
    }

    public void Play(Card card)
    {

        new CardEffect(Attacker,Defender,card);

       
        ExpireCardBuffs();
        //if (card.Buff != null)
        //{
        //    if (card.Buff.Offensive)
        //    {
        //        Defender.StoreBuff(card.Buff);
        //    }
        //    else
        //    {
        //        Attacker.StoreBuff(card.Buff);
        //    }
        //}

        Attacker.StoreBuffs(card.Buffs.Where(x => !x.Offensive).ToArray());
        Defender.StoreBuffs(card.Buffs.Where(x => x.Offensive).ToArray());

        Attacker.Spend(card);
        UpdateDisplay();
        DisplayHand();
        CheckBattleState();
    }

    public void ExpireCardBuffs()
    {
        foreach (Buff buff in Attacker.Buffs)
        {
            if (buff.Period == Period.Card)
            {
                Attacker.SpentBuffs.Add(buff);
            }
        }
        Attacker.CleanBuffs();
    }

    public void ExpireBuffs()
    {
        foreach (Buff buff in Attacker.Buffs)
        {
            if (buff.Period == Period.Turn || buff.Period == Period.Card)
            {
                Attacker.SpentBuffs.Add(buff);
            }
        }
        Attacker.CleanBuffs();
    }



    public void EndTurn()
    {
        Attacker.ClearHand();
        Attacker.Actions = 0;
        Attacker.TickBuffs();
        ExpireBuffs();
        Next();
    }

    public void BeginTurn()
    {
        Attacker.BeginTurn();
        Attacker.DrawHand();
        DisplayHand();
        UpdateDisplay();

        if (!PlayersTurn)
        {
            Invoke("AiAction", 2f);
        }

    }

    void UpdateDisplay()
    {

        LeftHealth.Set(Left.HealthPoints);
        RightHealth.Set(Right.HealthPoints);
        LeftDefence.Set(Left.Defence);
        RightDefence.Set(Right.Defence);
        LeftActions.Set(Left.Actions);
        RightActions.Set(Right.Actions);
        LeftPower.Set(Left.PowerPoints);
        RightPower.Set(Right.PowerPoints);
        DisplayBuffs(Left, LeftBuffs);
        DisplayBuffs(Right, RightBuffs);
    }

    void AiAction()
    {

        var options = Attacker.Hand.Where(x => x.Cost <= Attacker.Actions).Where(x=>x.PowerRequired <= Attacker.PowerPoints).ToArray();
        if(options.Count() == 0)
        {
            EndTurn();
        }
        else
        {
            Play(options[Random.Range(0, options.Count())]);
            Invoke("AiAction", 2f);
        }

    }

    void CheckBattleState()
    {
        if (Right.HealthPoints <= 0)
        {
            GameFileManager.GameFile.Loot = Right.Equipment;
            GameFileManager.Save();

            if(GameFileManager.GameFile.X == 0 && GameFileManager.GameFile.Y == 0)
            {
                //SceneManager.LoadScene("Win");
                scene = "Win";
                Invoke("Change", 2f);
            }
            else
            {
                scene = "Loot";
                // SceneManager.LoadScene("Loot");
                Invoke("Change", 2f);
            }
        }

        if (Left.HealthPoints <= 0)
        {
            GameFileManager.Delete();
            //SceneManager.LoadScene("Lose");
            scene = "Lose";
            Invoke("Change", 2f);
        }
     }

    string scene;

    private void Change()
    {
        SceneManager.LoadScene(scene);
    }
}
