using System;
namespace EpsilonEngine
{
    public class AudioClip
    {
        public uint sampleRate;
        public byte[] data;
        public AudioClip(byte[] data, uint sampleRate)
        {
            if (data == null)
            {
                throw new ArgumentException();
            }
            this.data = (byte[])data.Clone();
            this.sampleRate = sampleRate;
        }
        public void SetData(byte[] newData)
        {
            data = (byte[])newData.Clone();
        }
        public byte[] GetData()
        {
            return (byte[])data.Clone();
        }
    }
}
