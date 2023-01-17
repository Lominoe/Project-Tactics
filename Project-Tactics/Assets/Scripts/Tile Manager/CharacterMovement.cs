using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private Camera cam;
    [SerializeField] private float moveSpeed;
    private Vector3 destination;
    private void Awake()
    {
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
       destination = transform.position;
    }

    private void MouseClick()
    {
        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition.z = cam.nearClipPlane;
        //Vector3 worldpos = cam.ScreenToWorldPoint(mousePosition);

        //if (map.HasTile(gridPosition)) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1000) && hitData.transform.tag == "World")
        {
            Vector3Int gridPosition = map.WorldToCell(hitData.point);
            destination = gridPosition;
            //destination.y += 1f;
        }
        //destination = worldpos;
            print(destination);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            MouseClick();
        }
        if (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        }
    }
}
