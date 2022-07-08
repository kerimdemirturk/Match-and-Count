using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameOver : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //if any cube touch start zone game over.
        Cube cube = other.GetComponent<Cube>();
        if (cube != null)
        {
            if (!cube.is›tMainCube && cube.cubeRb.velocity.magnitude < .1f)
            {
                Debug.Log("Gameover");
            }
        }
    }

}
