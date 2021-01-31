using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ship_controls : MonoBehaviour
{
    public float speed;
    public float manuverability;
    public GameObject cameraRotate;
    public GameObject spray;

    private float Sail;
    private float Tack;
    private bool act = true;

    private void Start()
    {
        spray.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (act = true)
            {
                act = false;
            }
            else
            {
                act = true;
            }
        }


        if (act==true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(act==false)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //camera system
        float h = 10 * Input.GetAxis("Mouse X");
        cameraRotate.transform.Rotate(0, h, 0);

        if (cameraRotate.transform.localRotation.y > .6f)
        {
            cameraRotate.transform.Rotate(0, -h, 0);
        }

        if (cameraRotate.transform.localRotation.y < -.6f)
        {
            cameraRotate.transform.Rotate(0, -h, 0);
        }

        Cursor.visible = false;

        //Movement system
        Sail = Input.GetAxis("Vertical") * speed;
        Tack = Input.GetAxis("Horizontal") * manuverability;

        if(Sail > 0)
        {
            spray.SetActive(true);
        }
        else
        {
            spray.SetActive(false);
        }

        if (Sail < 0)
        {
            Sail = 0;
        }

        transform.position -= transform.forward * Sail * Time.deltaTime;
        transform.Rotate(0, Tack * Time.deltaTime, 0);
    }
}
