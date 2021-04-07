using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenResolution : MonoBehaviour
{
    // Start is called before the first frame update

    public bool maintainWidth = true;

    [Range(-1,1)]
    public int adaptPos;

    float defaultWidth;
    float defaultHeight;

    Vector3 CamPos;
    void Start()
    {
        CamPos = Camera.main.transform.position;

        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        defaultHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (maintainWidth)
        {
            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;

            Camera.main.transform.position = new Vector3(CamPos.x, adaptPos * (defaultHeight - Camera.main.orthographicSize), CamPos.z);
        }
        else
        {
            Camera.main.transform.position = new Vector3(adaptPos * (defaultWidth - Camera.main.orthographicSize* Camera.main.aspect), CamPos.y, CamPos.z);
        }
    }
}
