using System;
using UnityEngine;

public class CreateBands : MonoBehaviour
{
    public GameObject _cubePrototype;
    public float _baseScale;
    public float _maxScale;
    public bool _useBuffer;

    private GameObject[] _bandCubes;
    private GameObject[] _frequencyJumpCubes;

    private void Start()
    {
        // set up the frequency band cubes
        _bandCubes = new GameObject[8];

        for (int i = 0; i < 8; i++)
        {
            GameObject newCube = Instantiate(_cubePrototype);
            newCube.transform.position = transform.position;
            newCube.transform.parent = transform;

            newCube.transform.position = Vector3.right * (float)((i - 3.5) * 2);
            _bandCubes[i] = newCube;
        }

        // set up the frequency jump cubes
        // need to find a threshold to create the frequency jumps at
        _frequencyJumpCubes = new GameObject[8];
        
        for (int i = 0; i < 8; i++)
        {
            GameObject newCube = Instantiate(_cubePrototype);
            newCube.transform.position = transform.position;
            newCube.transform.parent = transform;

            newCube.transform.position = Vector3.right * (float)((i - 3.5) * 2) + Vector3.forward * -20;
            _frequencyJumpCubes[i] = newCube;
        }
    }

    private void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            float bandValue;
            if (_useBuffer)
            {
                bandValue = AudioPeer._frequencyBandBuffer[i];
            }
            else
            {
                bandValue = AudioPeer._frequencyBands[i];
            }

            _bandCubes[i].transform.localScale = new Vector3(_baseScale, (bandValue * _maxScale) + 1, _baseScale);
            //_frequencyJumpCubes[i].transform.localScale = new Vector3(_baseScale, (AudioPeer._jumps[i] * _maxScale) + 1, _baseScale);
        }
    }
}
