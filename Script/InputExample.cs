using UnityEngine;
using System.Collections;

public class InputExample : MonoBehaviour
{
	void Update ()
    {
        transform.position -= new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Mouse ScrollWheel"));
    }
}
