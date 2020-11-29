using System.Collections.Generic;
namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DCollider : Pixel2DComponent
    {
        public List<Pixel2DCollision> collisions = new List<Pixel2DCollision>();
        public List<Pixel2DOverlap> overlaps = new List<Pixel2DOverlap>();

        public RectangleInt shape = new RectangleInt(Vector2Int.Zero, new Vector2Int(16, 16));
        public Vector2Int offset = Vector2Int.Zero;
        public SideInfo sideCollision = SideInfo.True;
        public bool trigger = false;

        public static List<Pixel2DCollider> loadedColliders = new List<Pixel2DCollider>();

        public Pixel2DCollider(Pixel2DGameObject pixel2DGameObject) : base(pixel2DGameObject)
        {

        }
        public void Flush()
        {
            collisions = new List<Pixel2DCollision>();
            overlaps = new List<Pixel2DOverlap>();
        }
        public RectangleInt GetWorldShape()
        {
            RectangleInt output = new RectangleInt(shape.min + pixel2DGameObject.position + offset, shape.max + pixel2DGameObject.position + offset);
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

        public virtual void LogOverlap(Pixel2DCollider otherCollider)
        {
            overlaps.Add(new Pixel2DOverlap(this, otherCollider));
        }

        public void LogCollision(Pixel2DCollider otherCollider, SideInfo sideInfo)
        {
            collisions.Add(new Pixel2DCollision(this, otherCollider, sideInfo));
        }
    }
}