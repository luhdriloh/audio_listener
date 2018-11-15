using System;
using UnityEngine;

public class CreateBands : MonoBehaviour
{
    public GameObject _cubePrototype;

    private GameObject[] _bandCubes;

    private void Start()
    {
        _bandCubes = new GameObject[8];

        for (int i = 0; i < 8; i++)
        {
            GameObject newCube = Instantiate(_cubePrototype);
            newCube.transform.position = transform.position;

        }
    }

    private void Update()
    {

    }
}
