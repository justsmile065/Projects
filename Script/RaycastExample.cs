using UnityEngine;
using System.Collections;

public class RaycastExample : MonoBehaviour
{
	void Start ()
    	{
	
	}

	void Update ()
    	{
        	if ( Input.GetMouseButtonDown(0))
        	{
            		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            		RaycastHit RHit;

            		if (Physics.Raycast(ray, out RHit, Mathf.Infinity))
            		{
                		if (RHit.transform.tag == "DestroyedObject")
                		{
                    			Destroy(RHit.transform.gameObject);
                		}
           		}
        	}
	}
}
