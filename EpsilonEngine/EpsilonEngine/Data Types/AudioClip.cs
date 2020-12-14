using System;
namespace EpsilonEngine
{
    public struct AudioClip
    {
        public int sampleRate;
        public byte[] data;
        public AudioClip(int sampleRate, byte[] data)
        {
            if(sampleRate <= 0)
            {
                throw new ArgumentException();
            }
            if (data is null)
            {
                throw new ArgumentException();
            }
            this.data = data;
            this.sampleRate = sampleRate;
        }
    }
}
