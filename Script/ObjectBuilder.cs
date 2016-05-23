using UnityEngine;

using System.Collections;



public class ObjectBuilder : MonoBehaviour
{

    
    GameObject curentObject;

	

    void Update ()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        RaycastHit RHit;

        if (Physics.Raycast(ray, out RHit, Mathf.Infinity))
        {
            if(RHit.transform.tag == "cube")
            {
                if(Input.GetMouseButtonDown(0))
                {
                    curentObject = RHit.transform.gameObject;
                }
            }

            if (RHit.transform.tag == "terrain")
            {
                if(curentObject != null)
                {
                    curentObject.transform.position = RHit.point;
                }
            }

            Debug.Log(RHit.collider.gameObject.name);
        }


        if (curentObject != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                curentObject = null;
            }

        }
    }

}
