using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Dispatching;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SnakeNetMaui;

public class MainPageViewModel : INotifyPropertyChanged
{
    private readonly List<Point> snake = new();
    private Point food;
    private readonly int gridSize = 20;
    private readonly int cellSize = 20;
    private string direction = "Right";
    private bool gameOver;
    private static readonly Random rand = new();
    public GameDrawable GameDrawable { get; }
    public event PropertyChangedEventHandler PropertyChanged;

    public bool GameOver
    {
        get => gameOver;
        set { gameOver = value; OnPropertyChanged(); }
    }

    public MainPageViewModel()
    {
        GameDrawable = new GameDrawable(snake, () => food, cellSize, gridSize);
        StartGame();
    }

    public void StartGame()
    {
        snake.Clear();
        snake.Add(new Point(5, 5));
        direction = "Right";
        GameOver = false;
        GenerateFood();
        OnPropertyChanged(nameof(GameDrawable));
    }

    private void GenerateFood()
    {
        do
        {
            food = new Point(rand.Next(0, gridSize), rand.Next(0, gridSize));
        } while (snake.Contains(food));
    }

    public void GameLoop()
    {
        if (GameOver) return;
        MoveSnake();
        CheckCollision();
        OnPropertyChanged(nameof(GameDrawable));
    }

    private void MoveSnake()
    {
        var head = snake[0];
        Point newHead = direction switch
        {
            "Right" => new(head.X + 1, head.Y),
            "Left" => new(head.X - 1, head.Y),
            "Up" => new(head.X, head.Y - 1),
            "Down" => new(head.X, head.Y + 1),
            _ => head
        };
        if (newHead == food)
        {
            snake.Insert(0, newHead);
            GenerateFood();
#if MACCATALYST
            // Esempio: sblocca un obiettivo ogni volta che il giocatore mangia il cibo
            if (Application.Current is App app)
            {
                app.ReportAchievement("YOUR_ACHIEVEMENT_ID"); // Sostituisci con il tuo ID reale
            }
#endif
        }
        else
        {
            snake.Insert(0, newHead);
            snake.RemoveAt(snake.Count - 1);
        }
    }

    private void CheckCollision()
    {
        var head = snake[0];
        if (head.X < 0 || head.X >= gridSize || head.Y < 0 || head.Y >= gridSize)
        {
            GameOver = true;
        }
        if (snake.Count > 1 && snake.GetRange(1, snake.Count - 1).Contains(head))
        {
            GameOver = true;
        }
    }

    public void ChangeDirection(string newDirection)
    {
        if (newDirection == "Up" && direction != "Down") direction = "Up";
        if (newDirection == "Down" && direction != "Up") direction = "Down";
        if (newDirection == "Left" && direction != "Right") direction = "Left";
        if (newDirection == "Right" && direction != "Left") direction = "Right";
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public partial class MainPage : ContentPage
{
    private readonly IDispatcherTimer timer;
    private readonly MainPageViewModel viewModel;

    public MainPage()
    {
        InitializeComponent();
        viewModel = new MainPageViewModel();
        BindingContext = viewModel;
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(120);
        timer.Tick += (s, e) =>
        {
            viewModel.GameLoop();
            GameView.Invalidate();
            if (viewModel.GameOver) timer.Stop();
        };
        timer.Start();
    }

    private void OnRestartClicked(object sender, EventArgs e)
    {
#if MACCATALYST
        // Mostra la leaderboard quando il giocatore preme Restart dopo un game over
        if (viewModel.GameOver)
        {
            if (Application.Current is App app)
            {
                app.ShowLeaderboard("YOUR_LEADERBOARD_ID"); // Sostituisci con il tuo ID
                app.ReportAchievement("YOUR_ACHIEVEMENT_ID"); // Sostituisci con il tuo ID
            }
        }
#endif
        viewModel.StartGame();
        GameView.Invalidate();
        timer.Start();
    }

    private void OnLeaderboardClicked(object sender, EventArgs e)
    {
#if MACCATALYST
        if (Application.Current is App app)
        {
            app.ShowLeaderboard("YOUR_LEADERBOARD_ID"); // Sostituisci con il tuo ID reale
        }
#endif
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.Focus();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        timer.Stop();
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        this.AddHandler(Keyboard.KeyDownEvent, new EventHandler<KeyEventArgs>(OnKeyDown), true);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        viewModel.ChangeDirection(e.Key);
    }
}

public class GameDrawable : IDrawable
{
    private readonly List<Point> snake;
    private readonly Func<Point> getFood;
    private readonly int cellSize;
    private readonly int gridSize;

    public GameDrawable(List<Point> snake, Func<Point> getFood, int cellSize, int gridSize)
    {
        this.snake = snake;
        this.getFood = getFood;
        this.cellSize = cellSize;
        this.gridSize = gridSize;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Draw snake
        foreach (var part in snake)
        {
            canvas.FillColor = Colors.Green;
            canvas.FillRectangle((float)part.X * cellSize, (float)part.Y * cellSize, cellSize, cellSize);
        }
        // Draw food
        var food = getFood();
        canvas.FillColor = Colors.Red;
        canvas.FillRectangle((float)food.X * cellSize, (float)food.Y * cellSize, cellSize, cellSize);
        // Draw grid
        canvas.StrokeColor = Colors.Gray;
        for (int i = 0; i <= gridSize; i++)
        {
            canvas.DrawLine(i * cellSize, 0, i * cellSize, gridSize * cellSize);
            canvas.DrawLine(0, i * cellSize, gridSize * cellSize, i * cellSize);
        }
    }
}
