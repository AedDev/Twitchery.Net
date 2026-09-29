using TwitcheryNet.Services.Implementations;
using TwitcheryNet.Net.EventSub.EventArgs.Extensions.Channel;

// Registering new applications can be done here -> https://dev.twitch.tv/console/

const string myClientId = "2m4zbwa1zo9bhik7daqv1u8stpfxfa"; // Get this from your Twitch application
const string myRedirectUri = "http://localhost:8181"; // Must match the one in your Twitch application
var myScopes = new[]
{
    // -- Required for this example
    "user:read:chat", // Required to read messages from the chat
    "user:write:chat", // Required to send messages in chat

    // -- Always required
    "chat:read", // Required for EventSub registration
    "channel:read:subscriptions" // Required for EventSub registration
};

// Create a new Twitchery instance
var twitchery = new Twitchery();

// Authenticate with the user's default browser (Windows, Linux and OSX supported)
// If none is available, a URL will be printed to the console
await twitchery.UserBrowserAuthAsync(myClientId, myRedirectUri, myScopes);

if (twitchery.Me == null)
{
    Console.WriteLine("Uh-Oh! Something went wrong, we could not retrieve your user data!");
    Environment.Exit(1);
}

// Print the user's display name
Console.WriteLine($"Logged in as: {twitchery.Me.DisplayName}");

// Get the authenticated user's channel
var myChannel = twitchery.Me.Channel;

if (myChannel == null)
{
    Console.WriteLine("Uh-Oh! Something went wrong, we could not retrieve your channel data!");
    Environment.Exit(1);
}

// Add a listener to retrieve chat messages and be able to reply to them
myChannel.ChatMessage += async (sender, e) =>
{
    if (e.Message.Text.Equals("!ping", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"Received ping from {e.ChatterUserName}");
        await e.ReplyAsync("Pong!");
    }
};

Console.WriteLine("Press any key to exit...");

// This is required to keep the bot running until the user presses a key
// To keep the bot running indefinitely, you can use `await Task.Delay(-1);`
await Task.Run(Console.ReadKey);