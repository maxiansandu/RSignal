using Microsoft.AspNetCore.SignalR;
namespace Chat.Aplication.Hubs;

public class BallHub: Hub
{
    private static int X = 100;
    private static int Y = 100;
    private static int X2 = 200;
    private static int Y2 = 200;

    public async Task Move(string key)
    {
        switch (key)
        {
            case "ArrowUp": Y -= 5; break;
            case "ArrowDown": Y += 5; break;
            case "ArrowLeft": X -= 5; break;
            case "ArrowRight": X += 5; break;
            case "w": Y2 -= 5; break;
            case "s": Y2 += 5; break;
            case "a": X2 -= 5; break;
            case "d": X2 += 5; break;
        }

        await Clients.All.SendAsync("UpdateBall", X, Y, X2, Y2);
    }
}