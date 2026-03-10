using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerCamera : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 10, -10);

    void LateUpdate()
    {
        PlayerInput[] players = FindObjectsByType<PlayerInput>(FindObjectsSortMode.None);
        if (players.Length == 0) return;

        Vector3 centerPoint = Vector3.zero;
        foreach(PlayerInput player in players)
        {
            centerPoint += player.transform.position;
        }
        centerPoint /= players.Length;

        Vector3 desiredPosition = centerPoint + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(centerPoint);
    }
}
