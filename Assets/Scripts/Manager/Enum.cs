
public enum ListenType
{
    OnGameStart,
    OnGameOver,
    OnPlayerHeal,
    OnPlayerCollectItem,
    OnPauseGame,
    OnResumeGame,
    OnSendPlayerHeal,
    OnSendDirectionTrap,
    OnSendSpikeShoot,
    OnSendRectItem,
    OnSendItemValue,
    // Add more event types as needed
}
public enum UIType
{
    Unknow = 0,
    Screen = 1,
    Popup = 2,
    Notify = 3,
    Overlap = 4,
}
public enum ItemType
{
    Unknow = 0,
    Coin = 1,
    Heart = 2,
    Key = 3,
    Gem = 4,
    Map = 5,
    GreenDiamond,
    RedDiamond,
    BlueDiamond,
    // Add more item types as needed
}