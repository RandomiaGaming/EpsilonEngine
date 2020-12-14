using EpsilonEngine;
namespace DontMelt
{
    public sealed class Player : Component
    {
        private Texture facingRight = null;
        private Texture facingLeft = null;

        public SideInfo touchingGround = SideInfo.False;

        private const double moveForce = 20;
        private const double jumpForce = 8.5f;
        private const double maxMoveSpeed = 6.5f;
        private static readonly Vector2 wallJumpForce = new Vector2(8.5, 6);
        private const double dragForce = 8;
        private const double gravityForce = 9.80665;

        private Rigidbody rigidbody = null;
        private Collider collider = null;

        public Player(GameObject pixel2DGameObject) : base(pixel2DGameObject)
        {

        }

        public override void Initialize()
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();
            collider = gameObject.GetComponent<Collider>();
            TextureAsset playerSpriteSheet = (TextureAsset)game.assetManager.GetAssetByName("Player");
            facingLeft = TextureHelper.SubTexture(playerSpriteSheet.data, new RectangleInt(new Vector2Int(0, 0), new Vector2Int(16, 16)));
            facingRight = TextureHelper.SubTexture(playerSpriteSheet.data, new RectangleInt(new Vector2Int(16, 0), new Vector2Int(32, 16)));
            gameObject.texture = facingRight;
        }
        public override void Update()
        {
            rigidbody.velocity.y -= gravityForce / 60;
            Collision();
            Move();
            Jump();
            Drag();
            scene.cameraPosition = gameObject.position - new Vector2Int(256 / 2, 144 / 2) + new Vector2Int(8, 8);
        }
        private void Jump()
        {
            if (gameInterface.GetPrimaryKeyboardState().GetKeyboardButtonState(KeyboardButton.Space))
            {
                if (touchingGround.bottom)
                {
                    rigidbody.velocity.y = jumpForce;
                }
                else if (touchingGround.left)
                {
                    rigidbody.velocity = wallJumpForce;
                }
                else if (touchingGround.right)
                {
                    rigidbody.velocity = wallJumpForce * new Vector2(-1, 1);
                }
            }
        }

        private void Move()
        {
            int moveAxis = 0;
            bool dDown = gameInterface.GetPrimaryKeyboardState().GetKeyboardButtonState(KeyboardButton.D);
            bool adown = gameInterface.GetPrimaryKeyboardState().GetKeyboardButtonState(KeyboardButton.A);
            if (dDown && !adown)
            {
                moveAxis = 1;
                gameObject.texture = facingRight;
            }
            else if (!dDown && adown)
            {
                moveAxis = -1;
                gameObject.texture = facingLeft;
            }

            if (rigidbody.velocity.x < maxMoveSpeed && moveAxis == 1)
            {
                rigidbody.velocity.x += moveForce / 60;
            }
            else if (rigidbody.velocity.x > -maxMoveSpeed && moveAxis == -1)
            {
                rigidbody.velocity.x += -moveForce / 60;
            }
        }

        private void Drag()
        {
            if (rigidbody.velocity.x > 0)
            {
                rigidbody.velocity.x -= dragForce / 60;
                rigidbody.velocity.x = MathHelper.Clamp(rigidbody.velocity.x, 0, double.MaxValue);
            }
            else if (rigidbody.velocity.x < 0)
            {
                rigidbody.velocity.x -= -dragForce / 60;
                rigidbody.velocity.x = MathHelper.Clamp(rigidbody.velocity.x, double.MinValue, 0);
            }
        }

        private void Collision()
        {
            bool touchingGroundOnBottom = false;
            bool touchingGroundOnTop = false;
            bool touchingGroundOnLeft = false;
            bool touchingGroundOnRight = false;
            foreach (Collision c in collider.collisions)
            {
                if (c.sideInfo.bottom)
                {
                    touchingGroundOnBottom = true;
                }
                if (c.sideInfo.top)
                {
                    touchingGroundOnTop = true;
                }
                if (c.sideInfo.left)
                {
                    touchingGroundOnLeft = true;
                }
                if (c.sideInfo.right)
                {
                    touchingGroundOnRight = true;
                }
            }
            touchingGround = new SideInfo(touchingGroundOnTop, touchingGroundOnBottom, touchingGroundOnLeft, touchingGroundOnRight);
        }
    }
}