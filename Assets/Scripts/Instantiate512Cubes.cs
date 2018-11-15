using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{
    public GameObject _cubePrefab;
    public float _maxScale;
    public float _baseScale;
    private GameObject[] _cubes;

	private void Start ()
    {
        _cubes = new GameObject[512];

        for (int i = 0; i < 512; i++)
        {
            GameObject newCube = Instantiate(_cubePrefab);
            newCube.transform.position = transform.position;
            newCube.transform.parent = transform;

            newCube.name = "cube" + i;

            transform.eulerAngles = new Vector3(0f, .703125f * i, 0f);
            newCube.transform.position = Vector3.forward * 100;
            _cubes[i] = newCube;
        }
	}
	
	private void Update ()
    {
        for (int i = 0; i < 512; i++)
        {
            _cubes[i].transform.localScale = new Vector3(_baseScale, (AudioPeer._samples[i] * _maxScale) + (_baseScale / 5), _baseScale);
        }
	}
}
