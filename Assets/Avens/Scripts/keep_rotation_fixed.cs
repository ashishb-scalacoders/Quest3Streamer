using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keep_rotation_fixed : MonoBehaviour
{
    public GameObject thisObject;

    // Public variables to control the locking of each axis
    public bool lockX = false;
    public bool lockY = false;
    public bool lockZ = false;

    void Update()
    {
        Vector3 rotation = thisObject.transform.rotation.eulerAngles;

        // Apply locking based on the boolean variables
        if (lockX)
        {
            rotation.x = 0;
        }
        if (lockY)
        {
            rotation.y = 0;
        }
        if (lockZ)
        {
            rotation.z = 0;
        }

        thisObject.transform.rotation = Quaternion.Euler(rotation);
    }
}
