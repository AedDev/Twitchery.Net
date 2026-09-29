namespace TwitcheryNet.Models.Helix;

[Flags]
public enum BroadcasterType
{
    Normal = 0x00,
    Affiliate = 0x10,
    Partner = 0x20,
    AffiliateOrPartner = Affiliate | Partner
}