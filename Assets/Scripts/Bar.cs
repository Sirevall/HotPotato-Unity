using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public void GetBarRunner(GameObject runner)
    {
        transform.SetParent(runner.transform.GetChild(3).GetChild(0).transform);
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(90, 0, 0);
    }
}
