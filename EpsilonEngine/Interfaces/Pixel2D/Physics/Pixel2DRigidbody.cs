namespace EpsilonEngine.Modules.Pixel2D
{
    public sealed class Pixel2DRigidbody : Pixel2DComponent
    {
        private Vector2 subPixel = Vector2.Zero;
        public Vector2 velocity = Vector2.Zero;

        private Pixel2DCollider thisCollider = null;
        public Pixel2DRigidbody(Pixel2DGameObject pixel2DGameObject) : base(pixel2DGameObject)
        {

        }
        public override void Initialize()
        {
            thisCollider = pixel2DGameObject.GetComponent<Pixel2DCollider>();
        }
        public override void Update()
        {
            subPixel += velocity / 60 * 16;
            Vector2Int targetMove = new Vector2Int((int)subPixel.x, (int)subPixel.y);
            subPixel -= new Vector2((int)subPixel.x, (int)subPixel.y);

            Move(targetMove);
            LogCollisionsAndOverlaps();
        }
        private void Move(Vector2Int targetMove)
        {
            if (thisCollider != null && !thisCollider.trigger)
            {
                RectangleInt thisColliderShape = thisCollider.GetWorldShape();
                if (targetMove.x > 0)
                {
                    for (int i = 0; i < Pixel2DCollider.loadedColliders.Count; i++)
                    {
                        if (Pixel2DCollider.loadedColliders[i] != thisCollider)
                        {
                            RectangleInt otherColliderShape = Pixel2DCollider.loadedColliders[i].GetWorldShape();
                            if (thisColliderShape.min.y < otherColliderShape.max.y && thisColliderShape.max.y > otherColliderShape.min.y)
                            {
                                if (thisColliderShape.min.x < otherColliderShape.max.x)
                                {
                                    int maxMove = MathHelper.Min(targetMove.x, otherColliderShape.min.x - thisColliderShape.max.x);
                                    if (maxMove != targetMove.x)
                                    {
                                        velocity.x = 0;
                                    }
                                    targetMove.x = MathHelper.Clamp(maxMove, 0, int.MaxValue);
                                }
                            }
                        }
                    }
                }
                else if (targetMove.x < 0)
                {
                    for (int i = 0; i < Pixel2DCollider.loadedColliders.Count; i++)
                    {
                        if (Pixel2DCollider.loadedColliders[i] != thisCollider)
                        {
                            RectangleInt otherColliderShape = Pixel2DCollider.loadedColliders[i].GetWorldShape();
                            if (thisColliderShape.min.y < otherColliderShape.max.y && thisColliderShape.max.y > otherColliderShape.min.y)
                            {
                                if (thisColliderShape.max.x > otherColliderShape.min.x)
                                {
                                    int maxMove = MathHelper.Max(targetMove.x, otherColliderShape.max.x - thisColliderShape.min.x);
                                    if (maxMove != targetMove.x)
                                    {
                                        velocity.x = 0;
                                    }
                                    targetMove.x = MathHelper.Clamp(maxMove, int.MinValue, 0);
                                }
                            }
                        }
                    }
                }
                if (targetMove.y > 0)
                {
                    for (int i = 0; i < Pixel2DCollider.loadedColliders.Count; i++)
                    {
                        if (Pixel2DCollider.loadedColliders[i] != thisCollider)
                        {
                            RectangleInt otherColliderShape = Pixel2DCollider.loadedColliders[i].GetWorldShape();
                            if (thisColliderShape.min.x < otherColliderShape.max.x && thisColliderShape.max.x > otherColliderShape.min.x)
                            {
                                if (thisColliderShape.min.y < otherColliderShape.max.y)
                                {
                                    int maxMove = MathHelper.Min(targetMove.y, otherColliderShape.min.y - thisColliderShape.max.y);
                                    if (maxMove != targetMove.y)
                                    {
                                        velocity.y = 0;
                                    }
                                    targetMove.y = MathHelper.Clamp(maxMove, 0, int.MaxValue);
                                }
                            }
                        }
                    }
                }
                else if (targetMove.y < 0)
                {
                    for (int i = 0; i < Pixel2DCollider.loadedColliders.Count; i++)
                    {
                        if (Pixel2DCollider.loadedColliders[i] != thisCollider)
                        {
                            RectangleInt otherColliderShape = Pixel2DCollider.loadedColliders[i].GetWorldShape();
                            if (thisColliderShape.min.x < otherColliderShape.max.x && thisColliderShape.max.x > otherColliderShape.min.x)
                            {
                                if (thisColliderShape.max.y > otherColliderShape.min.y)
                                {
                                    int maxMove = MathHelper.Max(targetMove.y, otherColliderShape.max.y - thisColliderShape.min.y);
                                    if (maxMove != targetMove.y)
                                    {
                                        velocity.y = 0;
                                    }
                                    targetMove.y = MathHelper.Clamp(maxMove, int.MinValue, 0);
                                }
                            }
                        }
                    }
                }
            }
           pixel2DGameObject.position += targetMove;
        }
        public void LogCollisionsAndOverlaps()
        {
            if (thisCollider != null)
            {
                if (thisCollider.trigger)
                {
                    RectangleInt thisColliderShape = thisCollider.GetWorldShape();
                    for (int i = 0; i < Pixel2DCollider.loadedColliders.Count; i++)
                    {
                        if (Pixel2DCollider.loadedColliders[i] != thisCollider)
                        {
                            RectangleInt otherColliderShape = Pixel2DCollider.loadedColliders[i].GetWorldShape();
                            if (thisColliderShape.min.y < otherColliderShape.max.y && thisColliderShape.max.y > otherColliderShape.min.y && thisColliderShape.min.x < otherColliderShape.max.x && thisColliderShape.max.x > otherColliderShape.min.x)
                            {
                                thisCollider.LogOverlap(Pixel2DCollider.loadedColliders[i]);
                                Pixel2DCollider.loadedColliders[i].LogOverlap(thisCollider);
                            }
                        }
                    }
                }
                else
                {
                    RectangleInt thisColliderShape = thisCollider.GetWorldShape();
                    for (int i = 0; i < Pixel2DCollider.loadedColliders.Count; i++)
                    {
                        if (Pixel2DCollider.loadedColliders[i] != thisCollider)
                        {
                            RectangleInt otherColliderShape = Pixel2DCollider.loadedColliders[i].GetWorldShape();
                            if (Pixel2DCollider.loadedColliders[i].trigger)
                            {
                                if (thisColliderShape.min.y < otherColliderShape.max.y && thisColliderShape.max.y > otherColliderShape.min.y && thisColliderShape.min.x < otherColliderShape.max.x && thisColliderShape.max.x > otherColliderShape.min.x)
                                {
                                    thisCollider.LogOverlap(Pixel2DCollider.loadedColliders[i]);
                                }
                            }
                            else
                            {
                                if (thisColliderShape.min.y < otherColliderShape.max.y && thisColliderShape.max.y > otherColliderShape.min.y && thisColliderShape.max.x == otherColliderShape.min.x)
                                {
                                    thisCollider.LogCollision(Pixel2DCollider.loadedColliders[i], new SideInfo(false, false, false, true));
                                    Pixel2DCollider.loadedColliders[i].LogCollision(thisCollider, new SideInfo(false, false, true, false));
                                }
                                else if (thisColliderShape.min.y < otherColliderShape.max.y && thisColliderShape.max.y > otherColliderShape.min.y && thisColliderShape.min.x == otherColliderShape.max.x)
                                {
                                    thisCollider.LogCollision(Pixel2DCollider.loadedColliders[i], new SideInfo(false, false, true, false));
                                    Pixel2DCollider.loadedColliders[i].LogCollision(thisCollider, new SideInfo(false, false, false, true));
                                }
                                else if (thisColliderShape.min.x < otherColliderShape.max.x && thisColliderShape.max.x > otherColliderShape.min.x && thisColliderShape.max.y == otherColliderShape.min.y)
                                {
                                    thisCollider.LogCollision(Pixel2DCollider.loadedColliders[i], new SideInfo(true, false, false, false));
                                    Pixel2DCollider.loadedColliders[i].LogCollision(thisCollider, new SideInfo(false, true, false, false));
                                }
                                else if (thisColliderShape.min.x < otherColliderShape.max.x && thisColliderShape.max.x > otherColliderShape.min.x && thisColliderShape.min.y == otherColliderShape.max.y)
                                {
                                    thisCollider.LogCollision(Pixel2DCollider.loadedColliders[i], new SideInfo(false, true, false, false));
                                    Pixel2DCollider.loadedColliders[i].LogCollision(thisCollider, new SideInfo(true, false, false, false));
                                }
                                else if (thisColliderShape.min.y < otherColliderShape.max.y && thisColliderShape.max.y > otherColliderShape.min.y && thisColliderShape.min.x < otherColliderShape.max.x && thisColliderShape.max.x > otherColliderShape.min.x)
                                {
                                    thisCollider.LogCollision(Pixel2DCollider.loadedColliders[i], SideInfo.True);
                                    Pixel2DCollider.loadedColliders[i].LogCollision(thisCollider, SideInfo.True);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}