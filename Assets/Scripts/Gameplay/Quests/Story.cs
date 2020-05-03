
public class Story : IJournalItem {

    public StoryName Name;

    private string nameKey;
    private string descriptionKey;

    public string NameKey {
        get { return "Story." + Name.ToString(); }
    }

    public string DescriptionKey {
        get { return "Story.Description." + Name.ToString(); }
    }
}
