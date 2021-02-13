using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public InputField input;

    
    private string nameplayer;
    public void play()
    {
       
        formation.nom =  input.text; 

       
        SceneManager.LoadScene(1);


        //  GameObject instanceplayer = (GameObject)Instantiate(equipe);
        //instanceplayer.transform.position = new Vector3(0f, 1f, -18f);
        //instanceplayer.transform.position = new Vector3(0f, 1f, -18f);

        // instanceplayer.SendMessage("changenom", nameplayer);
    }
    public void Exit()
    {
        

        Debug.Log("zfref");
        Application.Quit();
    }
}
