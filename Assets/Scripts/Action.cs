using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Action : MonoBehaviour
{
    [SerializeField]
    private GameObject panelPlay;
    [SerializeField]
    private TMP_Text Text_Player_Action;
    [SerializeField]
    private TMP_Text Text_Player_Health;
    [SerializeField] 
    private TMP_Text Text_Enemy_Action;
    [SerializeField]
    private TMP_Text Text_Enemy_Health;

    private string Player_Action;
    private int Player_Health = 3;

    private int Enemy_Health = 3;
    private int Enemy_Action_Number;

    private System.Random rand = new System.Random();

    // Update is called once per frame
    void Update()
    {
        if (string.IsNullOrEmpty(Player_Action))
        {
            panelPlay.SetActive(true);
        } 
        else
        {
            panelPlay.SetActive(false);
            Text_Player_Action.SetText(Player_Action);
        }
    }

    public void SendAction(string ActionInput)
    {
        Player_Action = ActionInput;
    }

    public void ConfirmAction()
    {
        if (!string.IsNullOrEmpty(Player_Action))
        {
            Enemy_Action_Number = rand.Next(1, 4);

            switch (Enemy_Action_Number)
            {
                case 1:
                    Text_Enemy_Action.SetText("Espada");

                    Player_Health--;
                    break;
                case 2:
                    Text_Enemy_Action.SetText("Escudo");

                    Enemy_Health++;
                    break;
                case 3:
                    Text_Enemy_Action.SetText("Poção");

                    Enemy_Health += 2;
                    break;
            }

            string tempAction = Player_Action.ToLower();
            switch (tempAction)
            {
                case "espada":
                    Enemy_Health--;
                    break;
                case "escudo":
                    Player_Health++;
                    break;
                case "pocao":
                    Player_Health += 2;
                    break;
            }

            Text_Player_Health.SetText("x" + Player_Health);
            Text_Player_Action.SetText("");
            Text_Enemy_Health.SetText("x" + Enemy_Health);
            Enemy_Action_Number = 0;
            Player_Action = "";
        }
    }
}
