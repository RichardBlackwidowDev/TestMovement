using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnMove;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        OnMove?.Invoke(direction);
    }
}
