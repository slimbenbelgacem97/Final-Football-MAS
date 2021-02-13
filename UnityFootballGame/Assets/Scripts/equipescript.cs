using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipescript : MonoBehaviour
{
    public GameObject player;
    
   
    void Start()
    {
       
        
        
            GameObject instanceplayer = (GameObject)Instantiate(player);
            instanceplayer.transform.position = new Vector3(0f, 1f, -1f);

        instanceplayer.BroadcastMessage("changename", formation.nom);
               //nomjoueur.text = formation.nom;
            

      
    }
}
