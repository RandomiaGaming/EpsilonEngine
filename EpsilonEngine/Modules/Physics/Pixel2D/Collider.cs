using System.Collections.Generic;
namespace EpsilonEngine.Modules.Physics.Pixel2D
{
    public class Collider : Component
    {
        public List<Collision> collisions = new List<Collision>();
        public List<Overlap> overlaps = new List<Overlap>();

        public Rectangle shape = new Rectangle(Vector2Int.Zero, new Vector2Int(16, 16));
        public Vector2Int offset = Vector2Int.Zero;
        public SideInfo sideCollision = SideInfo.True;
        public bool trigger = false;

        public static List<Collider> loadedColliders = new List<Collider>();

        public Collider(GameObject gameObject) : base(gameObject)
        {

        }
        public void Flush()
        {
            collisions = new List<Collision>();
            overlaps = new List<Overlap>();
        }
        public Rectangle GetWorldShape()
        {
            Rectangle output = new Rectangle(shape.min + gameObject.position + offset, shape.max + gameObject.position + offset);
            return output;
        }
        public override void Update()
        {
            Flush();
        }
        public override void Initialize()
        {
            loadedColliders.Add(this);
        }

        public virtual void LogOverlap(Collider otherCollider)
        {
            Overlap newOverlap = new Overlap
            {
                thisCollider = this,
                thisGameObject = gameObject,
                otherCollider = otherCollider,
                otherGameObject = otherCollider.gameObject
            };
            overlaps.Add(newOverlap);
        }

        public void LogCollision(Collider otherCollider, SideInfo sideInfo)
        {
            Collision newCollision = new Collision
            {
                thisCollider = this,
                thisGameObject = gameObject,
                otherCollider = otherCollider,
                otherGameObject = otherCollider.gameObject,
                sideInfo = sideInfo
            };
            collisions.Add(newCollision);
        }
    }
}