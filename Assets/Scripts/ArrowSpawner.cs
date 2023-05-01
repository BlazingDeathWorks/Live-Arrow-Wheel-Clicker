using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private Arrow arrow;
    [SerializeField] private ShootPoint[] shootPoints;
    private Arrow currentArrow;
    private ShootPoint currentShootPoint;

    private void Awake()
    {
        //Initialize to down arrow spawner
        currentShootPoint = shootPoints[1];
        currentArrow = Instantiate(arrow, currentShootPoint.SpawnPos.position, Quaternion.Euler(0, 0, currentShootPoint.Rotation));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentArrow.Release();
            currentArrow = Instantiate(arrow, currentShootPoint.SpawnPos.position, Quaternion.Euler(0, 0, currentShootPoint.Rotation));
        }

        for (int i = 0; i < shootPoints.Length; i++)
        {
            if (Input.GetKeyDown(shootPoints[i].Input))
            {
                if (currentShootPoint.SpawnPos == shootPoints[i].SpawnPos) return;
                currentShootPoint = shootPoints[i];
                currentArrow.transform.position = currentShootPoint.SpawnPos.position;
                currentArrow.transform.localEulerAngles = new Vector3(0, 0, currentShootPoint.Rotation);
            }
        }
    }
}

[System.Serializable]
internal struct ShootPoint
{
    public Transform SpawnPos => spawnPos;
    public float Rotation => rotation;
    public KeyCode Input => input;

    [SerializeField] private Transform spawnPos;
    [SerializeField] private float rotation;
    [SerializeField] private KeyCode input;
}