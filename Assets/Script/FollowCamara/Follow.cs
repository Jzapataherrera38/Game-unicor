using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject target;


    private float posX;
    private float posY;

    public float derechaMax;
    public float izquierdaMax;
    
    public float alturaMax;
    public float alturaMin;

    public float speed;
    public bool encendida = true;

    void Start()
    {
        posX = target.transform.position.x;
        posY = target.transform.position.y;
        float X = Mathf.Clamp(posX, izquierdaMax, derechaMax);
        float Y = Mathf.Clamp(posY, alturaMin, alturaMax);
        transform.position = new Vector3(X, Y, -1);

    }

    void Move_cam()
    {
        if (encendida)
        {
            if (target)
            {
                posX = target.transform.position.x;
                posY = target.transform.position.y;
                float X = Mathf.Clamp(posX, izquierdaMax, derechaMax);
                float Y = Mathf.Clamp(posY, alturaMin, alturaMax);
                transform.position = Vector3.Lerp(transform.position, new Vector3(X, Y, -1), speed * Time.deltaTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move_cam();
    }
}
