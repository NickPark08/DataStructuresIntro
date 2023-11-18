using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DataStructures;
using System.Runtime.InteropServices;

namespace PathfindingVisualizer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        WeightedDirectedGraph<int> graph = new WeightedDirectedGraph<int>();
        WDVertex<int>[,] vertices = new WDVertex<int>[10, 10];
        Rectangle[,] hitboxes = new Rectangle[10, 10];

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();


            for (int i = 0; i < vertices.Length; i++)
            {
                for (int j = 0; j < vertices.Length; j++)
                {
                    vertices[i, j] = new WDVertex<int>(j);
                    vertices[i, j].x = j;
                    vertices[i, j].y = i;
                    graph.AddVertex(vertices[i, j]);
                    hitboxes[i, j] = new Rectangle(j * 100, i * 100, 100, 100);
                }
            }
            // [r, c]
            float temp = 0f;
            for (int i = 0; i < vertices.Length; i++)
            {
                for (int j = 0; j < vertices.Length; j++)
                {
                    if ((i != 0 && j != 0) && (i != vertices.Length - 1 && j != vertices.Length))
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
                        if (j > 0 && j < vertices.Length - 1)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j + 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j - 1], temp));
                            if (i == 0)
                            {
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j - 1], temp));
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j + 1], temp));
                            }
                            else if (i == vertices.Length - 1)
                            {
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j + 1], temp));
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j - 1], temp));
                            }
                        }
                        if (i > 0 && i < vertices.Length - 1)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j], temp));
                            if (j == 0)
                            {
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j + 1], temp));
                                vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j + 1], temp));
                            }
                            else if (j == vertices.Length - 1)
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
                        else if (i == 0 && j == vertices.Length - 1)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j - 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j - 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i + 1, j], temp));
                        }
                        else if (i == vertices.Length && j == 0)
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j + 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j + 1], temp));
                        }
                        else
                        {
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j - 1], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i - 1, j], temp));
                            vertices[i, j].Neighbors.Add(new WDEdge<int>(vertices[i, j], vertices[i, j - 1], temp));
                        }
                    }
                }
            }

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

            MouseState ms = Mouse.GetState();

            _spriteBatch.Begin();

            foreach (var rect in hitboxes)
            {
                _spriteBatch.Draw();
            }

                _spriteBatch.End();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}