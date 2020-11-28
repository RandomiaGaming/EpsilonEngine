using EpsilonEngine.Modules.Physics.Pixel2D;
using EpsilonEngine.Modules.Renderers.Pixel2D;
using EpsilonEngine.Modules.AssetCodecs.PNG;
namespace EpsilonEngine.Projects.TestProject
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
            PNGAsset playerSpriteSheet = (PNGAsset)game.assetManager.GetAsset("Player.png");
            playerTextureSheet = new TextureSheet(playerSpriteSheet.data, 16, 32);
            graphic.graphic = playerTextureSheet.GetTexture(0, 1);
        }
        public override void Update()
        {
            if (gameInterface.inputDriver.GetPrimaryMouseState().leftButtonPressed)
            {
                gameObject.position = (gameInterface.inputDriver.GetPrimaryMouseState().position / (Vector2)gameInterface.graphicsDriver.viewPortRect) * new Vector2Int(256, 144);
            }
            rigidbody.velocity.y -= gravityForce / 60;
            Collision();
            Move();
            Jump();
            Drag();
            ((Pixel2DSceneRenderer)gameObject.scene.renderer).cameraPosition = gameObject.position - new Vector2Int(256 / 2, 144 / 2);
        }
        private void Jump()
        {
            if (gameInterface.inputDriver.GetPrimaryKeyboardState().GetKeyboardButtonState(KeyboardButton.Space))
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
            bool dDown = gameInterface.inputDriver.GetPrimaryKeyboardState().GetKeyboardButtonState(KeyboardButton.D);
            bool adown = gameInterface.inputDriver.GetPrimaryKeyboardState().GetKeyboardButtonState(KeyboardButton.A);
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