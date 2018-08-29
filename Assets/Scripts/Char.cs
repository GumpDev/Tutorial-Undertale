using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour {

    [Header("CharConfig")]
    public float speed;
    [Header("Imports")]
    public Camera cam;

    private Vector3 goTo = new Vector3(0,0,-10);

	void Start () {
		
	}
	
	void Update () {
        #region Moviment
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (y == 1) //W
            transform.position += new Vector3(0, speed, 0);
        else if(x == 1) //D
            transform.position += new Vector3(speed, 0, 0);
        else if (y == -1) //S
            transform.position += new Vector3(0, -speed, 0);
        else if (x == -1) //A
            transform.position += new Vector3(-speed, 0, 0);
        #endregion
        #region Camera
        cam.transform.position = Vector3.LerpUnclamped(cam.transform.position, goTo, 2 * Time.deltaTime);

        if (Vector3.Distance(cam.transform.position, goTo) < 1)
        {
            if (transform.position.x > cam.transform.position.x + 12.5f)
            {
                goTo = new Vector3(cam.transform.position.x + 12.5f, cam.transform.position.y, -10);
            }
            else if(transform.position.x < cam.transform.position.x - 12.5f)
            {
                goTo = new Vector3(cam.transform.position.x - 12.5f, cam.transform.position.y, -10);
            }
            else if (transform.position.y > cam.transform.position.y + 5.5f)
            {
                goTo = new Vector3(cam.transform.position.x, cam.transform.position.y + 5.5f, -10);
            }
            else if (transform.position.y < cam.transform.position.y - 5.5f)
            {
                goTo = new Vector3(cam.transform.position.x, cam.transform.position.y - 5.5f, -10);
            }
        }
        #endregion
    }
}
