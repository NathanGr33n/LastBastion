//Game1.cs
//By: Nathan Green
//August 2025
//Handles initialization, update logic, and drawing the screen


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LastBastion
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics; //Manages graphics device and rendering window
        private SpriteBatch _spriteBatch; //Used to draw textures
        //Window dimensions
        private int screenWidth = 1280;
        private int screenHeight = 720;
        //Font used for drawing UI text (loaded from content)
        private SpriteFont _font;
        //Input tracking
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        private KeyboardState _currentKeyboard;
        private KeyboardState _previousKeyboard;
        //Turn counter and game phase placeholder
        private int currentTurn = 1;
        private string currentPhase = "Idle"; //phase: Idle, Event, Assign, Resolve
        //Example resource Counters
        private int food = 100;
        private int stone = 50;
        private int morale = 80;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}