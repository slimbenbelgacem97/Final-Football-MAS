using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scriptname : MonoBehaviour
{
   public GameObject playerobject;

  private void Update()
    {
        transform.position = new Vector3(playerobject.transform.position.x, transform.position.y, playerobject.transform.position.z);
    }
    public void changename(string name)
    {
        GetComponent<TextMeshPro>().text = name;
    }
}
