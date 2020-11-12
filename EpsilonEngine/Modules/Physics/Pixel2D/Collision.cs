namespace EpsilonEngine.Modules.Physics.Pixel2D
{
    public struct Collision
    {
        public Collider otherCollider;
        public GameObject otherGameObject;
        public Collider thisCollider;
        public GameObject thisGameObject;
        public SideInfo sideInfo;
        public Collision(Collider thisCollider, GameObject thisGameObject, Collider otherCollider, GameObject otherGameObject, SideInfo sideInfo)
        {
            this.otherCollider = otherCollider;
            this.otherGameObject = otherGameObject;
            this.thisCollider = thisCollider;
            this.thisGameObject = thisGameObject;
            this.sideInfo = sideInfo;
        }
    }
}
