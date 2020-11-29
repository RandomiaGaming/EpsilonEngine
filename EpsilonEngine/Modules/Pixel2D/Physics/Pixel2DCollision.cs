using System;
namespace EpsilonEngine.Modules.Pixel2D
{
    public sealed class Pixel2DCollision
    {
        public readonly Pixel2DCollider otherCollider = null;
        public readonly GameObject otherGameObject = null;
        public readonly Pixel2DCollider thisCollider = null;
        public readonly GameObject thisGameObject = null;
        public readonly SideInfo sideInfo = SideInfo.False;
        public Pixel2DCollision(Pixel2DCollider thisCollider, Pixel2DCollider otherCollider, SideInfo sideInfo)
        {
            if(thisCollider is null)
            {
                throw new NullReferenceException();
            }
            this.otherCollider = otherCollider;
            if(thisCollider.gameObject is null)
            {
                throw new NullReferenceException();
            }
            thisGameObject = thisCollider.gameObject;
            if(otherCollider is null)
            {
                throw new NullReferenceException();
            }
            this.otherCollider = otherCollider;
            if(otherCollider.gameObject is null)
            {
                throw new NullReferenceException();
            }
            if(thisCollider.game != otherCollider.game)
            {
                throw new ArgumentException();
            }
            if(thisCollider.gameInterface != otherCollider.gameInterface)
            {
                throw new ArgumentException();
            }
            otherGameObject = otherCollider.gameObject;
            this.sideInfo = sideInfo;
        }
    }
}
