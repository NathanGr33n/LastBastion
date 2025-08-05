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
            //Initialize Graphics Manager
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //Set window size
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
        }

        //Called once at the start of the game
        protected override void Initialize()
        {
            //TODO: Perform setup logic here

            base.Initialize();
        }

        //Called once to load all game content
        protected override void LoadContent()
        {
            //Create a new SpriteBatch for drawing
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load font
            _font = Content.Load<SpriteFont>("defaultFont");
        }

        //Called Every Frame to update game logic
        protected override void Update(GameTime gameTime)
        {
            //Exit if Escape is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Save previous input states
            _previousMouse = _currentMouse;
            _previousKeyboard = _currentKeyboard;

            //Get current input states
            _currentMouse = Mouse.GetState();
            _currentKeyboard = Keyboard.GetState();

            //Handle Input
            HandleInput();

            //TODO: Handle Turn System

            base.Update(gameTime);
        }

        //Handles input logic
        private void HandleInput()
        {
            if (_currentKeyboard.IsKeyDown(Keys.Enter) && _previousKeyboard.IsKeyUp(Keys.Enter))
                AdvanceTurn();
        }

        //Game state and turn processing logic
        private void UpdateGameLogic()
        {
            //placeholder logic for morale decay over turns
            if(currentPhase == "Resolve")
            {
                morale = MathHelper.Clamp(morale - 1, 0, 100);
                currentPhase = "Idle"; //Return to idle phase after resolving
            }
        }

        private void AdvanceTurn()
        {
            currentTurn++;
            currentPhase = "Resolve"; //move to the resolve phase
        }
        
        //Called every frame to draw the screen
        protected override void Draw(GameTime gameTime)
        {
            //Clear screen with dark grey background
            GraphicsDevice.Clear(new Color(30, 30, 30));
            _spriteBatch.Begin();

            //Draw UI text
            _spriteBatch.DrawString(_font, $"Turn: {currentTurn}", new Vector2(20, 20), Color.White);
            _spriteBatch.DrawString(_font, $"Phase: {currentPhase}", new Vector2(20, 60), Color.White);

            _spriteBatch.DrawString(_font, $"Resources:", new Vector2(20, 120), Color.LightGray);
            _spriteBatch.DrawString(_font, $"- Food: {food}", new Vector2(40, 160), Color.LightGreen);
            _spriteBatch.DrawString(_font, $"- Stone: {stone}", new Vector2(40, 200), Color.Silver);
            _spriteBatch.DrawString(_font, $"- Morale: {morale}", new Vector2(40, 240), Color.LightBlue);

            _spriteBatch.DrawString(_font, $"[Enter] to advance turn", new Vector2(20, screenHeight - 60), Color.Yellow);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}