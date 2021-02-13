using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

using System;

public class player : BehaviorDesigner.Runtime.Tasks.Action
{
    
    public float speedTanslation;
    public float speedRotation = 5f;
    public GameObject[] monjoueurs;
    GameObject ballon;
   
   
    
    
    

    public override void OnAwake()
    {
        
        speedTanslation = 5f;
        GetComponent<Animation>().Stop();
        ballon = GameObject.FindGameObjectWithTag("Ball");


    }

    // Start is called before the first frame update

    public override void OnStart()
    {

        GetComponent<Animation>()["change_sense"].speed = 1.0f;
        GetComponent<Animation>()["repose"].speed = 1.0f;
        GetComponent<Animation>()["shoot"].speed = 3.5f;
        GetComponent<Animation>()["run"].speed = 1.2f;
        GetComponent<Animation>().Play("repose");
        monjoueurs = GameObject.FindGameObjectsWithTag("player");
        
    }

    // Update is called once per frame
    public override TaskStatus OnUpdate()
    {
        float botton_move_x = 0f;
        float botton_move_z = 0f;
        float botton_shoot = 10f;
        float demande = Input.GetAxis("demande");
        botton_move_x = Input.GetAxis("Vertical");
        botton_move_z = Input.GetAxis("Horizontal");
        botton_shoot = Input.GetAxis("shoot");
        

        
        if(demande != 0)
        {
            DemandeBall();
        }
        else if (botton_shoot != 0)
        {
            for (int i = 0; i < 100; i++)
            {
                botton_move_x = Input.GetAxis("Vertical");
            }
            Shoot(botton_shoot);
        }
        else if (botton_move_x != 0)
        {
            Mouvement(botton_move_x);
        }
        else
        {
            GetComponent<Animation>().Play("repose");
        }
        Rotation(botton_move_z);
       
        //ballon.transform.Rotate(0f, y * speed1, 0f);
        
        return TaskStatus.Running;

    }  
    private void DemandeBall()
    {
        if (Ballon.player_have_ball != null && Ballon.player_have_ball.tag.Equals("player"))
        {
            Ballon.player_have_ball.SendMessage("demande_ballon", gameObject);
        }
    }


    private void Shoot(float force)
    {
        if (gameObject.Equals(Ballon.player_have_ball))
        {
            Debug.Log(force);
            System.Random aleatoire = new System.Random();
            int y = aleatoire.Next(0, (int)force);
            ballon.transform.rotation = transform.rotation;/*force + */


            //=====================
            float f = 0;
            float power = 0;
            //if(Input.GetButtonUp("shoot"))
            //{
            //    f = Time.time;
            //}
            //if(Input.GetButtonDown("shoot"))
            //{
            //    power = Time.time - f;
            //}force+(float)Math.Pow( 10,power)
            Debug.Log("force=" + power);
            //======================
            ballon.transform.TransformVector (new Vector3(Input.acceleration.x, 0f,0f ));
            Ballon.player_have_ball = null;
        }
        GetComponent<Animation>().Play("shoot");
    }
     
    private void Mouvement(float x)
    {
          if (x > 0)
        {
            GetComponent<Animation>().Play("run");
            if (gameObject.Equals(Ballon.player_have_ball))
            {
                ballon.transform.Rotate(x * speedTanslation * Time.deltaTime, 0f, 0f);
            }
            transform.Translate(0f, 0f, x * speedTanslation * Time.deltaTime);

        }
        else if (x < 0)
        {
            GetComponent<Animation>().Play("steps_behind");
            if (gameObject.Equals(Ballon.player_have_ball))
            {
                ballon.transform.Rotate(x * speedTanslation * Time.deltaTime, 0f, 0f);
            }
            transform.Translate(0f, 0f, x * speedTanslation * Time.deltaTime);
        }
       // Debug.Log(x);
    }
    private void Rotation(float z)
    {
        transform.Rotate(0f,z * speedRotation, 0f);
    }
}
