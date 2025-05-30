using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SnakeNetMaui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new MainPage();
#if MACCATALYST
        AuthenticateGameCenter();
#endif
    }
#if MACCATALYST
    partial void AuthenticateGameCenter()
    {
        GKLocalPlayer.LocalPlayer.AuthenticateHandler = (viewController, error) =>
        {
            if (error != null)
            {
                System.Diagnostics.Debug.WriteLine($"Game Center authentication error: {error.LocalizedDescription}");
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Application.Current?.MainPage?.DisplayAlert("Game Center Error", error.LocalizedDescription, "OK");
                });
            }
            if (viewController != null)
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                window?.RootViewController?.PresentViewController(viewController, true, null);
            }
        };
    }

    public void ShowLeaderboard(string leaderboardId)
    {
        var viewController = new GKGameCenterViewController
        {
            ViewState = GKGameCenterViewControllerState.Leaderboards,
            LeaderboardIdentifier = leaderboardId
        };
        viewController.Finished += (s, e) =>
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            window?.RootViewController?.DismissViewController(true, null);
        };
        var windowToShow = UIApplication.SharedApplication.KeyWindow;
        if (viewController == null || windowToShow?.RootViewController == null)
        {
            System.Diagnostics.Debug.WriteLine("Game Center: Unable to show leaderboard (viewController or window is null)");
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Application.Current?.MainPage?.DisplayAlert("Game Center Error", "Unable to show leaderboard.", "OK");
            });
            return;
        }
        windowToShow.RootViewController.PresentViewController(viewController, true, null);
    }

    public void ReportAchievement(string achievementId, double percentComplete = 100.0)
    {
        var achievement = new GKAchievement(achievementId)
        {
            PercentComplete = percentComplete,
            ShowsCompletionBanner = true
        };
        GKAchievement.ReportAchievements(new[] { achievement }, (error) =>
        {
            if (error != null)
            {
                System.Diagnostics.Debug.WriteLine($"Game Center achievement error: {error.LocalizedDescription}");
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Application.Current?.MainPage?.DisplayAlert("Game Center Error", error.LocalizedDescription, "OK");
                });
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Achievement {achievementId} reported successfully.");
            }
        });
    }
#endif
}
