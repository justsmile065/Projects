using UnityEngine;
using System.Collections;

public class OverlapeSphere : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit RHit;
            if (Physics.Raycast(ray, out RHit, Mathf.Infinity))
            {
                Collider[] col = Physics.OverlapSphere(RHit.point, 15);

                foreach( var i in col)
                {
                    if ( i.attachedRigidbody)
                    {
                        i.attachedRigidbody.AddForce((RHit.point - i.transform.position)* 100);
                    }
                }
            }
        }
    }
}
