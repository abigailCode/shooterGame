using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointerController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject goal;
    [SerializeField] TMP_Text distance;


    void Update()
    {
        float x = target.transform.position.x;
        float z = target.transform.position.z;
        float y = target.transform.position.y;
        gameObject.transform.position = new Vector3(x, y + 2f, z);

        gameObject.transform.LookAt(goal.transform);

        distance.text = Vector3.Distance(target.transform.position, goal.transform.position).ToString("F2") +" m";

    }
}
