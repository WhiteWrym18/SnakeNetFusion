using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeNet;

public partial class MainForm : Form
{
    private readonly List<Point> snake = new();
    private Point food;
    private readonly int gridSize = 20;
    private readonly int cellSize = 20;
    private string direction = "Right";
    private bool gameOver;
    private readonly Timer timer1 = new();

    public MainForm()
    {
        InitializeComponent();
        DoubleBuffered = true;
        StartPosition = FormStartPosition.CenterScreen;
        Size = new(gridSize * cellSize + 16, gridSize * cellSize + 39);
        Text = "Snake Game";

        KeyDown += MainForm_KeyDown;
        StartGame();
        timer1.Tick += GameLoop;
        timer1.Start();
    }

    private void MainForm_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Up && direction != "Down") direction = "Up";
        if (e.KeyCode == Keys.Down && direction != "Up") direction = "Down";
        if (e.KeyCode == Keys.Left && direction != "Right") direction = "Left";
        if (e.KeyCode == Keys.Right && direction != "Left") direction = "Right";
    }

    private void StartGame()
    {
        snake.Clear();
        snake.Add(new(5, 5));
        direction = "Right";
        gameOver = false;
        GenerateFood();
    }

    private void GenerateFood()
    {
        var rand = new Random();
        do
        {
            food = new(rand.Next(0, gridSize), rand.Next(0, gridSize));
        } while (snake.Contains(food));
    }

    private void GameLoop(object? sender, EventArgs e)
    {
        if (gameOver)
        {
            timer1.Stop();
            MessageBox.Show("Game Over! Press Enter to Restart.");
            if (MessageBox.Show("Restart?", "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StartGame();
                timer1.Start();
            }
            else
            {
                Application.Exit();
            }
            return;
        }

        MoveSnake();
        CheckCollision();
        Invalidate(); // Redraw the game board
    }

    private void MoveSnake()
    {
        var head = snake[0];
        var newHead = direction switch
        {
            "Right" => new(head.X + 1, head.Y),
            "Left" => new(head.X - 1, head.Y),
            "Up" => new(head.X, head.Y - 1),
            "Down" => new(head.X, head.Y + 1),
            _ => head
        };

        if (newHead == food)
        {
            snake.Insert(0, newHead); // Eat food and grow
            GenerateFood();
        }
        else
        {
            snake.Insert(0, newHead);
            snake.RemoveAt(snake.Count - 1); // Move without growing
        }
    }

    private void CheckCollision()
    {
        var head = snake[0];

        // Check collision with walls
        if (head.X < 0 || head.X >= gridSize || head.Y < 0 || head.Y >= gridSize)
        {
            gameOver = true;
        }

        // Check collision with itself
        if (snake.Count > 1 && snake.GetRange(1, snake.Count - 1).Contains(head))
        {
            gameOver = true;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;

        // Draw snake
        foreach (var part in snake)
        {
            g.FillRectangle(Brushes.Green, part.X * cellSize, part.Y * cellSize, cellSize, cellSize);
        }

        // Draw food
        g.FillRectangle(Brushes.Red, food.X * cellSize, food.Y * cellSize, cellSize, cellSize);

        // Draw grid
        for (int i = 0; i <= gridSize; i++)
        {
            g.DrawLine(Pens.Gray, i * cellSize, 0, i * cellSize, gridSize * cellSize);
            g.DrawLine(Pens.Gray, 0, i * cellSize, gridSize * cellSize, i * cellSize);
        }
    }

    private void InitializeComponent() { /* No designer, so this is empty */ }
}
