using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Disk : MonoBehaviour
{
    internal static Disk Instance { get; private set; } 
    [SerializeField] private float degreesPerSecond;
    private List<Arrow> arrows = new List<Arrow>();

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, degreesPerSecond * Time.deltaTime);
    }

    internal void AddArrow(Arrow arrow)
    {
        arrows.Add(arrow);
        arrow.transform.parent = transform;
    }

    internal void WipeArrows()
    {
        for (int i = 0; i < arrows.Count; i++)
        {
            Destroy(arrows[i].gameObject);
        }
        arrows.Clear();
    }
}
