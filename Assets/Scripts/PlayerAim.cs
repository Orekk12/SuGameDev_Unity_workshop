using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private GameObject GFXObject;
    [SerializeField] private GameObject pivotObj;
    [SerializeField] private float Speed = 5f;

    private Vector3 defaultScale;
    public float angle;
    private void Start()
    {
        defaultScale = transform.localScale;
    } 

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pivotObj.transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Speed * Time.deltaTime);

        Vector3 aimScale = Vector3.one;
        //Vector2 aimPosition = Vector2.zero;

        if (Mathf.Abs(angle) > 90)
        {
            aimScale = new Vector3(defaultScale.x, -defaultScale.y, defaultScale.z);
            //aimPosition.x = -0.5f;

        }
        else
        {
            aimScale = new Vector3(defaultScale.x, defaultScale.y, defaultScale.z);
        }

        transform.localScale = aimScale;
        RotateBasedOnMousePos(angle, GFXObject);
    }

    private void RotateBasedOnMousePos(float angle, GameObject GFXobject)
    {
        if (Mathf.Abs(angle) < 90)
        {
            GFXobject.transform.localScale = new Vector3(defaultScale.x, defaultScale.y, defaultScale.z);
        }
        else if (Mathf.Abs(angle) > 90)
        {
            GFXobject.transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z);
        }
    }
}
