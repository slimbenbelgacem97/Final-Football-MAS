using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    public class boitmessage :MonoBehaviour
    {
        float speedballon = 3f;    

        void demande_ballon(GameObject obj )
        {
            if (Ballon.player_have_ball == gameObject)
            {
                
                GameObject ballon = GameObject.FindGameObjectWithTag("Ball");
                Vector3 aux = obj.transform.position - ballon.transform.position;
                ballon.transform.Translate(speedballon*(new Vector3(aux.x,0f,aux.z))*Time.deltaTime);
                Quaternion rotation = new Quaternion(-obj.transform.rotation.x, 0f, -obj.transform.position.z, 0f);
                transform.SetPositionAndRotation(transform.position, rotation); ;
                Ballon.player_have_ball.GetComponent<Animation>().Play("pass");
                Ballon.player_have_ball = null;
            }
        }

    }
}
