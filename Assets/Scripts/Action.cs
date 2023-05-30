using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Action : MonoBehaviour
{
    // Recebe o GameObject da UI para ativar ou desativar ele
    [SerializeField]
    private GameObject panelPlay;
    // Recebe o texto da UI da ação e vida do player e do inimigo
    [SerializeField]
    private TMP_Text Text_Player_Action;
    [SerializeField]
    private TMP_Text Text_Player_Health;
    [SerializeField] 
    private TMP_Text Text_Enemy_Action;
    [SerializeField]
    private TMP_Text Text_Enemy_Health;

    // Define a variável da ação do player que será usada para verificação do comando e a vida do jogador
    private string Player_Action;
    private int Player_Health = 3;

    // Define a variável da ação do inimigo e a vida do mesmo
    private int Enemy_Health = 3;
    private int Enemy_Action_Number;

    // Define uma variavel para gerar números aleátorios
    private System.Random rand = new System.Random();

    
    void Update()
    {
        // Verifica se a ação do player ja foi escolhida ou não para exibir o painel de ajuda
        if (string.IsNullOrEmpty(Player_Action))
        {
            panelPlay.SetActive(true);
        } 
        else
        {
            // caso definido a ação do player o painel some e mostra na UI a ação do player
            panelPlay.SetActive(false);
            Text_Player_Action.SetText(Player_Action);
        }
    }

    // Função que sera chamada toda vez que aparecer as Imagens Target da espada, escudo e poção
    // Sendo assim ela precisa ser pública e ter um parametro que é passado na propria Unity
    public void SendAction(string ActionInput)
    {
        Player_Action = ActionInput;
    }

    // Função que sera chamada toda vez que aparecer a Imagem Target do joia
    public void ConfirmAction()
    {
        // Verifica se o player fez uma ação para executar o resto da função
        if (!string.IsNullOrEmpty(Player_Action))
        {
            // Vai escolher a ação do inimigo entre os números 1, 2 e 3 e depois definir a ação dele
            // e executar os comandos para executar a ação
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
            
            // Vai pegar a ação do player e executar ela também de acordo com o que foi escolhido
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

            // Após as duas ações forem executadas a vida do player e do inimigo serão atualizadas e 
            // a ação do player e do inimigo voltarão a serem vazias
            Text_Player_Health.SetText("x" + Player_Health);
            Text_Player_Action.SetText("");
            Text_Enemy_Health.SetText("x" + Enemy_Health);
            Enemy_Action_Number = 0;
            Player_Action = "";
        }
    }
}
