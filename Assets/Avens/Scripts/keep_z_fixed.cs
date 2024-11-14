using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keep_z_fixed : MonoBehaviour
{
    public GameObject thisObject;
    void Update()
    {
        // Keep the z rotation at 0 while allowing changes to x and y
        Vector3 rotation = thisObject.transform.rotation.eulerAngles;
        rotation.z = 0;
        thisObject.transform.rotation = Quaternion.Euler(rotation);
    }
}
