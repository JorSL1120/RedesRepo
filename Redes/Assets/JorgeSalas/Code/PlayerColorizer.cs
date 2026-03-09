using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerColorizer : MonoBehaviour
{
    public Color[] playerColors = { Color.red, Color.blue, Color.green, Color.yellow };
    
    void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        int playerIndex = playerInput.playerIndex;
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && playerIndex < playerColors.Length) renderer.material.color = playerColors[playerIndex];
    }
}
