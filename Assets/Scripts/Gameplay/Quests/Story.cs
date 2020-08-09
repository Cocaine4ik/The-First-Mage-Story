
public class Story : IJournalItem {

    public StoryName Name;

    public string NameKey => "Story." + Name.ToString();
    public string DescriptionKey => "Story.Description." + Name.ToString();
}
