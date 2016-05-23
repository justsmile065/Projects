using UnityEngine;
using System.Collections;

public class Times : MonoBehaviour 
{

    public float timer, couldown;

	void Update ()
	{
        	if (timer <= 0)
        	{
            		print("Shot");
            		timer = couldown;
        	}

        	if ( timer > 0)
        	{
            		timer -= Time.deltaTime;
        	}
        
	}
}
