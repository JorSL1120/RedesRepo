using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    private int currentSpawnIndex = 0;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if(spawnPoints.Length > 0)
        {
            playerInput.transform.position = spawnPoints[currentSpawnIndex].position;
            playerInput.transform.rotation = spawnPoints[currentSpawnIndex].rotation;

            currentSpawnIndex = (currentSpawnIndex + 1) % spawnPoints.Length;
        }
    }
}
