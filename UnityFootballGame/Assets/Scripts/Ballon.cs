using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public static GameObject player_have_ball;
    // Start is called before the first frame update
    void Start()
    {
        player_have_ball = null;
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag =="player" || collision.gameObject.tag =="user")
        {

            GameObject joueur = collision.gameObject;
            Ballon.player_have_ball = joueur;
            //Debug.Log(player_have_ball.tag);
        }
        else
        {
            Ballon.player_have_ball = null;
        }
    }
    private void Update()
    {
        if (player_have_ball != null)
        {
            GameObject pied = player_have_ball.transform.GetChild(0).gameObject;
           // Debug.Log(player_have_ball.tag);
            Vector3 aux = new Vector3(pied.transform.position.x , pied.transform.position.y, pied.transform.position.z); //- transform.position;
            transform.position = aux;
            //Vector3 rotation = new Vector3(player_have_ball.transform.rotation.x - transform.rotation.x, player_have_ball.transform.rotation.z - transform.rotation.z, player_have_ball.transform.rotation.z - transform.rotation.z);
            //transform.rotation = new Quaternion(rotation.x, rotation.y,rotation.z, 0f);

        }

    }
}
;