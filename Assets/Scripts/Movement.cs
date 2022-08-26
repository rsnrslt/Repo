using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {

        transform.position += Vector3.forward * horizontalSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            FirstMoneyMove();
        }
        
    }
    public void FirstMoneyMove()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit , Mathf.Infinity))
        {
            GameObject firstCube = MoneyRush.instance.cubes[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstCube.transform.localPosition.y;
            hitVec.z = firstCube.transform.localPosition.z;
            firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVec, Time.deltaTime*verticalSpeed);
        }
        
    }
}
