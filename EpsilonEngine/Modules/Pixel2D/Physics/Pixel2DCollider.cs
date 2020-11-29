using System.Collections.Generic;
namespace EpsilonEngine.Modules.Pixel2D
{
    public class Collider : Component
    {
        public List<Collision> collisions = new List<Collision>();
        public List<Overlap> overlaps = new List<Overlap>();

        public RectangleInt shape = new RectangleInt(Vector2Int.Zero, new Vector2Int(16, 16));
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
        public RectangleInt GetWorldShape()
        {
            RectangleInt output = new RectangleInt(shape.min + gameObject.GetComponent<Pixel2DTransform>().position + offset, shape.max + gameObject.GetComponent<Pixel2DTransform>().position + offset);
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
            overlaps.Add(new Overlap(this, otherCollider));
        }

        public void LogCollision(Collider otherCollider, SideInfo sideInfo)
        {
            collisions.Add(new Collision(this, otherCollider, sideInfo));
        }
    }
}