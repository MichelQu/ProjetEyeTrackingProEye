using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using Tobii.G2OM;

public class DestroyET : MonoBehaviour, IGazeFocusable
{
    bool targeted = false;
    float timer = 0;

    //The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus) // S'il l'objet a le focus des yeux alors 
        {
            targeted = true;
        }
        else // Si l'objet a perdu le focus de l'oeil
        {
            targeted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targeted)
        {
            // On incémente le temps 
            timer += Time.deltaTime;
            if (timer > 0.6f)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            timer = 0f;
        }
    }
}
