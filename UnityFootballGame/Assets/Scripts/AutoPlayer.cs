using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorDesigner.Runtime.Tasks{
    [TaskCategory("AgentSystem")]
    public class SuivreBallon : Action
    {
        
        //[Tooltip("Search area")]
        private NavMeshAgent nav ;
        private IDictionary<string, float> ScoresActions = new Dictionary<string, float>();



        private GameObject ballon;
        private Vector3 prevDir;
        private GameObject[] joueur_mon_equipe;


        public override void OnStart()
        {
            base.OnStart();
            //initialisation d'animation
            GetComponent<Animation>().Stop();
            GetComponent<Animation>()["run"].speed = 1.0f;
            GetComponent<Animation>()["repose"].speed = 2.5f;
            GetComponent<Animation>().Play("repose");
            // fin initialisation d'animation

            //initialisation des score du joueur
            ScoresActions["deplacementAvent"] = 0;
            ScoresActions["deplacementArrier"] = 0;
            ScoresActions["deplacementDroit"] = 0;
            ScoresActions["deplacementGouche"] = 0;
            ScoresActions["Shoot"] = 0f;
            
            //fin initialisation des score du joueur
            ballon = GameObject.FindGameObjectWithTag("Ball");

            joueur_mon_equipe = GameObject.FindGameObjectsWithTag("player");
            nav = GetComponent<NavMeshAgent>();
            GetComponent<Animation>().Play("repose");

        }

        
        public override TaskStatus OnUpdate()
        {
            caluclule_score();
            if (PlusProcheJoueur() == gameObject &&   (Ballon.player_have_ball == null  || (!Ballon.player_have_ball.tag.Equals("player") && !Ballon.player_have_ball.tag.Equals("user") )) )
            {//|| )
                GetComponent<Animation>().Play("run");
                    nav.SetDestination(ballon.transform.position);
            }
            else if(Ballon.player_have_ball == gameObject)
            {
                GetComponent<Animation>().Play("repose");
                float maxscore = 0;
                string action = "";
                // Quand on utilise foreach pour énumérer les éléments du dictionnaire,
                // ces éléments sont récupérés en tant que des objets de type KeyValuePair.
                // Recherche la meilleur action en utilisant la score du chaque action 
                foreach (KeyValuePair<string, float> kvp in ScoresActions )
                {
                    if (kvp.Value > maxscore)
                    {
                        action = kvp.Key;
                       // Debug.Log(action);
                    }
                }

               // execution l'action
                switch (action)
                {
                    case "deplacementAvent":
                        Debug.Log("deplacementAvent");
                        break;
                    case "deplacementArrier":
                        Debug.Log("deplacementArrier");
                        break;
                    case "deplacementDroit":
                        Debug.Log("deplacementDroit");
                        break;
                    case "Shoot":
                        { Shoot();  Debug.Log("ce"); }
                        break;
                    case "deplacementGouche":
                        Debug.Log("deplacementGouche");
                        break;
                }

                //if (action.Equals("shoot"))
                //{
                //    shoot();
                //}

            }
            else
            { GetComponent<Animation>().Play("repose");
                nav.SetDestination(transform.position);
             }
         return TaskStatus.Running;
        }

        public override void OnReset()
        {
            base.OnReset();

        }
        public void caluclule_score()
        {
            calucle_score_shoot();
        }

        public void calucle_score_shoot()//cette methode permet du modifier la score du shoot
        {
            if (transform.position.x >=-20 && transform.position.x <=19 && transform.position.z >=-3 && transform.position.z <=28)
            {
                ScoresActions["Shoot"] =0.5f;
                
            }
            else{

               // ScoresActions["Shoot"] = 0f;
            }
        }

       

        public GameObject PlusProcheJoueur()
        { GameObject playerobject = gameObject;
            Vector3 aux =  ballon.transform.position - transform.position;
            for (int i=0; i< joueur_mon_equipe.Length; i++)
            {
                if ((ballon.transform.position - joueur_mon_equipe[i].transform.position).magnitude < aux.magnitude)
                {
                    aux = ballon.transform.position - joueur_mon_equipe[i].transform.position;
                    playerobject = joueur_mon_equipe[i];
                }
            }
            return playerobject;
        }



        // implementaion les action
        private void Shoot()
        {   Debug.Log("shoot");
            Vector3 aux = GameObject.Find("Goal_ad").transform.position - ballon.transform.position;
            ballon.transform.Translate(aux*Time.deltaTime*aux.magnitude);
             
        }


    }
}