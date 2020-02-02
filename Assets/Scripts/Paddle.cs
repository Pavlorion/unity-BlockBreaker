using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenUnitsWidth = 16f;
    [SerializeField] float leftBorder = 1.5f;
    [SerializeField] float rightBorder = 14.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseInputInUnits = Input.mousePosition.x / Screen.width * screenUnitsWidth;
        Vector2 paddlePos = new Vector2 (Mathf.Clamp(mouseInputInUnits,leftBorder,rightBorder), transform.position.y);
        //paddlePos.x = Mathf.Clamp(mouseInputInUnits, 1.5f, 14.5f);
        transform.position = paddlePos;
    }
}
