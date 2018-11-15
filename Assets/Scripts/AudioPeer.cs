using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    public static float[] _samples = new float[512];
    public static float[] _bands = new float[8];
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
    }

    private void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    private void MakeFrequencyBands()
    {
        /*
         * 20 - 60 hertz
         * 60 - 250 hertz
         * 250 - 500 hertz
         * 500 - 2000 hertz
         * 2000 - 4000 hertz
         * 4000 - 6000 hertz
         * 6000 - 20000 hertz
         */

        // use powers of 2 to go up

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            int samplesToRead = (int)Mathf.Pow(2, i + 1);
            float average = 0;

            for (int j = 0; j < samplesToRead; j++)
            {
                average += _samples[count];
                count++;
            }

            average /= samplesToRead;
            _bands[i] = average;
        }
    }
}
