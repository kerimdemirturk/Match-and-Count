using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables for player touch.
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pushingForce;
    [SerializeField] private float cubeMaxPosX;

    [SerializeField] private TouchSlider touchSlider;
    private Cube mainCube;

    private bool isPointerDown;
    private Vector3 cubePos;

    void Start()
    {
        SpawnCube();

        //slider events
        touchSlider.OnPointerDownEvent += OnPointerDown;
        touchSlider.OnPointerDragEvent += OnPointerDrag;
        touchSlider.OnPointerUpEvent += OnPointerUp;
    }

    private void Update()
    {
        if (isPointerDown)
            mainCube.transform.position = Vector3.Lerp(
               mainCube.transform.position,
               cubePos,
               moveSpeed * Time.deltaTime
            );
    }

    private void OnPointerDown()
    {
        isPointerDown = true;
    }

    private void OnPointerDrag(float xMovement)
    {
        if (isPointerDown)
        {
            cubePos = mainCube.transform.position;
            cubePos.x = xMovement * cubeMaxPosX;
        }
    }

    private void OnPointerUp()
    {
        if (isPointerDown)
        {
            isPointerDown = false;
           

            // Push the cube:
            mainCube.cubeRb.AddForce(Vector3.forward * pushingForce, ForceMode.Impulse);

            Invoke("SpawnNewCube", 0.3f);
        }
    }

    private void SpawnNewCube()
    {
        mainCube.is›tMainCube = false;
        SpawnCube();
    }

    private void SpawnCube()
    {
        mainCube = CubeSpawner.Instance.SpawnRandom();
        mainCube.is›tMainCube = true;

        // reset cubePos variable
        cubePos = mainCube.transform.position;
    }



    private void OnDestroy()
    {
        //remove listeners:
        touchSlider.OnPointerDownEvent -= OnPointerDown;
        touchSlider.OnPointerDragEvent -= OnPointerDrag;
        touchSlider.OnPointerUpEvent -= OnPointerUp;
    }


}
