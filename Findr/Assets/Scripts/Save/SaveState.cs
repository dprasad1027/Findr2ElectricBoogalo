public class SaveState
{
    public int Money = 50;
    public int LobbyLevel = 0;
    public bool TutorialPassed = true;

    public SaveState()
    {
        this.Money = 0;
        this.LobbyLevel = 0;
        this.TutorialPassed = false;
    }

    public SaveState(int Money, int LobbyLevel, bool TutorialPassed)
    {
        this.Money = Money;
        this.LobbyLevel = LobbyLevel;
        this.TutorialPassed = TutorialPassed;
    }
}