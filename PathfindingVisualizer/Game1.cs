using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DataStructures;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System;

namespace PathfindingVisualizer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        WeightedDirectedGraph<int> graph = new WeightedDirectedGraph<int>();
        WDVertex<int>[,] vertices = new WDVertex<int>[10, 15];
        Square<int>[,] hitboxes = new Square<int>[10, 15];
        Square<int> start;
        Square<int> end;
        Texture2D square;
        MouseState previousMS;
        bool pathfinding = false;
        (List<WDVertex<int>> path, List<WDVertex<int>> journey) visual;

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
            int val = 0;
            previousMS = Mouse.GetState();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    val++;
                    vertices[i, j] = new WDVertex<int>(val);
                    vertices[i, j].x = j;
                    vertices[i, j].y = i;
                    graph.AddVertex(vertices[i, j]);
                    hitboxes[i, j] = new Square<int>(new Rectangle(j * 100, i * 100, 100, 100), Color.White, vertices[i, j]);
                }
            }
            // [r, c]
            float temp = 1f;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if ((i != 0 && j != 0) && (i != length - 1 && j != 15 - 1))
                    {
                        graph.AddEdge(vertices[i, j], vertices[i - 1, j], temp);
                        graph.AddEdge(vertices[i, j], vertices[i + 1, j], temp);
                        graph.AddEdge(vertices[i, j], vertices[i, j + 1], temp);
                        graph.AddEdge(vertices[i, j], vertices[i, j - 1], temp);
                        graph.AddEdge(vertices[i, j], vertices[i + 1, j + 1], (float)Math.Sqrt(2));
                        graph.AddEdge(vertices[i, j], vertices[i + 1, j - 1], (float)Math.Sqrt(2));
                        graph.AddEdge(vertices[i, j], vertices[i - 1, j + 1], (float)Math.Sqrt(2));
                        graph.AddEdge(vertices[i, j], vertices[i - 1, j - 1], (float)Math.Sqrt(2));
                    }
                    else
                    {
                        if (j > 0 && j < 15 - 1)
                        {
                            graph.AddEdge(vertices[i, j], vertices[i, j + 1], temp);
                            graph.AddEdge(vertices[i, j], vertices[i, j - 1], temp);
                            if (i == 0)
                            {
                                graph.AddEdge(vertices[i, j], vertices[i + 1, j - 1], (float)Math.Sqrt(2));
                                graph.AddEdge(vertices[i, j], vertices[i + 1, j + 1], (float)Math.Sqrt(2));
                            }
                            else if (i == length - 1)
                            {
                                graph.AddEdge(vertices[i, j], vertices[i - 1, j + 1], (float)Math.Sqrt(2));
                                graph.AddEdge(vertices[i, j], vertices[i - 1, j - 1], (float)Math.Sqrt(2));
                            }
                        }
                        if (i > 0 && i < length - 1)
                        {
                            graph.AddEdge(vertices[i, j], vertices[i + 1, j], temp);
                            graph.AddEdge(vertices[i, j], vertices[i - 1, j], temp);
                            if (j == 0)
                            {
                                graph.AddEdge(vertices[i, j], vertices[i + 1, j + 1], (float)Math.Sqrt(2));
                                graph.AddEdge(vertices[i, j], vertices[i - 1, j + 1], (float)Math.Sqrt(2));
                            }
                            else if (j == 15 - 1)
                            {
                                graph.AddEdge(vertices[i, j], vertices[i + 1, j - 1], (float)Math.Sqrt(2));
                                graph.AddEdge(vertices[i, j], vertices[i - 1, j - 1], (float)Math.Sqrt(2));
                            }
                        }


                        if (i == 0 && j == 0)
                        {
                            graph.AddEdge(vertices[i, j], vertices[i + 1, j + 1], (float)Math.Sqrt(2));
                            graph.AddEdge(vertices[i, j], vertices[i, j + 1], temp);
                            graph.AddEdge(vertices[i, j], vertices[i + 1, j], temp);
                        }
                        else if (i == 0 && j == 15 - 1)
                        {
                            graph.AddEdge(vertices[i, j], vertices[i + 1, j - 1], (float)Math.Sqrt(2));
                            graph.AddEdge(vertices[i, j], vertices[i, j - 1], temp);
                            graph.AddEdge(vertices[i, j], vertices[i + 1, j], temp);
                        }
                        else if (i == length - 1 && j == 0)
                        {
                            graph.AddEdge(vertices[i, j], vertices[i - 1, j + 1], (float)Math.Sqrt(2));
                            graph.AddEdge(vertices[i, j], vertices[i - 1, j], temp);
                            graph.AddEdge(vertices[i, j], vertices[i, j + 1], temp);
                        }
                        else if (i == length - 1 && j == 15 - 1)
                        {
                            graph.AddEdge(vertices[i, j], vertices[i - 1, j - 1], (float)Math.Sqrt(2));
                            graph.AddEdge(vertices[i, j], vertices[i - 1, j], temp);
                            graph.AddEdge(vertices[i, j], vertices[i, j - 1], temp);
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

        bool movingStart = false;
        bool movingEnd = false;
        private TimeSpan delayBetweenSteps = TimeSpan.FromMilliseconds(50);
        private TimeSpan elapsedTimeSinceLastStep = TimeSpan.Zero;
        private int currentStep = 0;
        private bool isPathVisualizationComplete = false;
        private TimeSpan delayBetweenJourneySteps = TimeSpan.FromMilliseconds(25);
        private TimeSpan elapsedTimeSinceLastJourneyStep = TimeSpan.Zero;
        private int currentJourneyStep = 0;
        private bool isJourneyVisualizationComplete = false;

        protected override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            KeyboardState ks = Keyboard.GetState();

            foreach (var rect in hitboxes)
            {
                bool click = rect.Hitbox.Contains(ms.X, ms.Y) && ms.LeftButton == ButtonState.Pressed && previousMS.LeftButton == ButtonState.Released;
                if (click)
                {
                    if (movingStart)
                    {
                        start.Color = Color.White;
                        start = rect;
                        start.Color = Color.Green;
                        rect.isClicked = false;
                        movingStart = false;
                    }
                    else if (rect == start)
                    {
                        movingStart = true;
                        start.Color = Color.LightBlue;
                    }
                    else if (movingEnd)
                    {
                        end.Color = Color.White;
                        end = rect;
                        end.Color = Color.Red;
                        rect.isClicked = false;
                        movingEnd = false;
                    }
                    else if (rect == end)
                    {
                        movingEnd = true;
                        end.Color = Color.LightBlue;
                    }
                    else
                    {
                        if (!rect.isClicked)
                        {
                            rect.Color = Color.Gray;
                            rect.isClicked = true;
                            for (int i = 0; i < rect.Vertex.NeighborCount; i++)
                            {
                                if (rect.Vertex.Neighbors[i].EndPoint == rect.Vertex)
                                {
                                    rect.Vertex.Neighbors[i].Blocked = true;
                                }
                            }
                        }
                        else
                        {
                            rect.Color = Color.White;
                            rect.isClicked = false;
                            for (int i = 0; i < rect.Vertex.NeighborCount; i++)
                            {
                                if (rect.Vertex.Neighbors[i].EndPoint == rect.Vertex)
                                {
                                    rect.Vertex.Neighbors[i].Blocked = false;
                                }
                            }
                        }
                    }

                }
            }

            if (ks.IsKeyDown(Keys.Space) && !pathfinding)
            {
                visual = graph.AStar(start.Vertex, end.Vertex);
                pathfinding = true;

                currentStep = 0;
                currentJourneyStep = 0;
                elapsedTimeSinceLastStep = TimeSpan.Zero;
                elapsedTimeSinceLastJourneyStep = TimeSpan.Zero;
                isPathVisualizationComplete = false;
                isJourneyVisualizationComplete = false;
            }

            if (ks.IsKeyDown(Keys.Back))
            {
                pathfinding = false;
                isPathVisualizationComplete = true;
                isJourneyVisualizationComplete = true;
                foreach (var rect in hitboxes)
                {
                    if (rect != start && rect != end)
                    {
                        rect.Color = Color.White;
                    }
                    rect.isClicked = false;
                }
            }
            if (pathfinding && !isJourneyVisualizationComplete)
            {
                elapsedTimeSinceLastJourneyStep += gameTime.ElapsedGameTime;

                if (elapsedTimeSinceLastJourneyStep >= delayBetweenJourneySteps)
                {
                    elapsedTimeSinceLastJourneyStep = TimeSpan.Zero;

                    if (currentJourneyStep < visual.journey.Count)
                    {
                        var currentVertex = visual.journey[currentJourneyStep];
                        var currentRect = hitboxes[currentVertex.y, currentVertex.x];
                        currentRect.Color = Color.Orange;

                        currentJourneyStep++;
                    }
                    else
                    {
                        isJourneyVisualizationComplete = true;
                    }
                }

            }
            if (pathfinding && !isPathVisualizationComplete && isJourneyVisualizationComplete)
            {
                elapsedTimeSinceLastStep += gameTime.ElapsedGameTime;

                if (elapsedTimeSinceLastStep >= delayBetweenSteps)
                {
                    elapsedTimeSinceLastStep = TimeSpan.Zero;

                    if (currentStep < visual.path.Count)
                    {
                        var currentVertex = visual.path[currentStep];
                        var currentRect = hitboxes[currentVertex.y, currentVertex.x];
                        currentRect.Color = Color.Yellow;
                        currentStep++;
                    }
                    else
                    {
                        isPathVisualizationComplete = true;
                    }
                }


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