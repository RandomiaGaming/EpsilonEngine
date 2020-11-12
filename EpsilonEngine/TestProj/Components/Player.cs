using EpsilonEngine.Modules.Physics.Pixel2D;
using EpsilonEngine.Modules.Renderers.Pixel2D;
namespace EpsilonEngine.Projects.TestProj
{
    public class Player : Component
    {
        public TextureSheet playerTextureSheet;
        public SideInfo touchingGround = SideInfo.False;

        public double moveForce = 20;
        public double jumpForce = 8.5f;
        public double maxMoveSpeed = 6.5f;
        public Vector2 wallJumpForce = new Vector2(8.5, 6);
        public double dragForce = 8;
        public double gravityForce = 9.80665;

        public Rigidbody rigidbody;
        private Collider collider;
        private PixelGraphic2D graphic;

        public Player(GameObject gameObject) : base(gameObject)
        {

        }

        public override void Initialize()
        {
            rigidbody = (Rigidbody)gameObject.GetComponentsOfType(typeof(Rigidbody))[0];
            collider = (Collider)gameObject.GetComponentsOfType(typeof(Collider))[0];
            graphic = (PixelGraphic2D)gameObject.GetComponentsOfType(typeof(PixelGraphic2D))[0];
            TextureAsset playerSpriteSheet = (TextureAsset)game.assetManager.GetAsset("player");
            playerTextureSheet = new TextureSheet(playerSpriteSheet.data, 16, 32);
            graphic.graphic = playerTextureSheet.GetTexture(0, 1);
        }
        public override void Update()
        {
            ((PixelRenderer2D)game.renderer).cameraPosition = gameObject.position - new Vector2Int(256 / 2, 144 / 2);
            rigidbody.velocity.y -= gravityForce / 60;
            Collision();
            Move();
            Jump();
            Drag();
        }
        private void Jump()
        {
            if (game.inputDriver.IsKeyPressed(KeyCode.Space))
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
            bool dDown = game.inputDriver.IsKeyPressed(KeyCode.D);
            bool adown = game.inputDriver.IsKeyPressed(KeyCode.A);
            if (dDown && !adown)
            {
                moveAxis = 1;
                graphic.graphic = playerTextureSheet.GetTexture(0, 1);
            }
            else if (!dDown && adown)
            {
                moveAxis = -1;
                graphic.graphic = playerTextureSheet.GetTexture(15, 0);
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
            touchingGround = SideInfo.False;
            foreach (Collision c in collider.collisions)
            {
                if (c.sideInfo.bottom)
                {
                    touchingGround.bottom = true;
                }
                if (c.sideInfo.top)
                {
                    touchingGround.top = true;
                }
                if (c.sideInfo.left)
                {
                    touchingGround.left = true;
                }
                if (c.sideInfo.right)
                {
                    touchingGround.right = true;
                }
            }
        }
    }
}