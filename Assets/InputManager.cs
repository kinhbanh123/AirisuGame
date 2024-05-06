using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField] public Vector3 mouseWorldPos;
    private void Awake()
    {
        if (InputManager.instance != null) { Debug.LogError("Only1 can allow"); }
        InputManager.instance = this;
    }
    void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
