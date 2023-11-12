using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private float offset = -10f;

    [SerializeField]
    private Transform cible;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // après Update
        // la caméra bouge après les déplacements du perso
        Vector3 posCam = new Vector3(cible.position.x, cible.position.y, offset);
        Vector3 newPos = Vector3.Lerp(transform.position, posCam, 15f *Time.deltaTime);

        transform.position = posCam;

    }
}
