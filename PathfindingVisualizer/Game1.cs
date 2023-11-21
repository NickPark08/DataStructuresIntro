using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DataStructures;
using System.Runtime.InteropServices;
using System.Threading;

namespace PathfindingVisualizer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        WeightedDirectedGraph<int> graph = new WeightedDirectedGraph<int>();
        WDVertex<int>[,] vertices = new WDVertex<int>[10, 15];
        Square[,] hitboxes = new Square[10, 15];
        Square start;
        Square end;
        Texture2D square;
        MouseState previousMS;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1500;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();

            int length = 10;
            previousMS = Mouse.GetState();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    vertices[i, j] = new WDVertex<int>(j);
                    vertices[i, j].x = j;
                    vertices[i, j].y = i;
                    graph.AddVertex(vertices[i, j]);
                    hitboxes[i, j] = new Square(new Rectangle(j * 100, i * 100, 100, 100), Color.White);
                }
            }
            // [r, c]
            float temp = 0f;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if ((i != 0 && j != 0) && (i != length - 1 && j != 15 - 1))
                    {
                        vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j], temp));
                        vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j], temp));
                        vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j + 1], temp));
                        vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j - 1], temp));
                        vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j + 1], temp));
                        vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j - 1], temp));
                        vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j + 1], temp));
                        vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j - 1], temp));
                    }
                    else
                    {
                        if (j > 0 && j < 15 - 1)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j + 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j - 1], temp));
                            if (i == 0)
                            {
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j - 1], temp));
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j + 1], temp));
                            }
                            else if (i == length - 1)
                            {
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j + 1], temp));
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j - 1], temp));
                            }
                        }
                        if (i > 0 && i < length - 1)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j], temp));
                            if (j == 0)
                            {
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j + 1], temp));
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j + 1], temp));
                            }
                            else if (j == 15 - 1)
                            {
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j - 1], temp));
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j - 1], temp));
                            }
                        }


                        if (i == 0 && j == 0)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j + 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j + 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j], temp));
                        }
                        else if (i == 0 && j == 15 - 1)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j - 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j - 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j], temp));
                        }
                        else if (i == length - 1 && j == 0)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j + 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j + 1], temp));
                        }
                        else if (i == length - 1 && j == 15 - 1)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j - 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j - 1], temp));
                        }
                    }
                }
            }


            start = hitboxes[5, 1];
            start.Color = Color.Green;
            end = hitboxes[5, 13];
            end.Color = Color.Red;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            square = Content.Load<Texture2D>("square");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState ms = Mouse.GetState();
            KeyboardState ks = Keyboard.GetState();
            bool movingStart = false;
            bool movingEnd = false;

            foreach (var rect in hitboxes)
            {
                if (rect.Hitbox.Contains(ms.X, ms.Y) && ms.LeftButton == ButtonState.Pressed && previousMS.LeftButton == ButtonState.Released)
                {
                    if (rect == start)
                    {
                        movingStart = true;
                        break;
                    }
                    else if (rect == end)
                    {
                        movingEnd = true;
                    }
                    else
                    {

                        if (!rect.isClicked)
                        {
                            rect.Color = Color.Gray;
                            rect.isClicked = true;
                        }
                        else
                        {
                            rect.Color = Color.White;
                            rect.isClicked = false;
                        }
                    }
                }
            }
            if(movingStart)
            {

            }
            previousMS = ms;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (var rect in hitboxes)
            {
                _spriteBatch.Draw(square, rect.Hitbox, rect.Color);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}