namespace TwitcheryNet.Models.Helix.Enumerations;

[Flags]
public enum TokenType
{
    UserAccess = 1 << 1,
    AppAccess = 1 << 2,
    Both = UserAccess | AppAccess
}