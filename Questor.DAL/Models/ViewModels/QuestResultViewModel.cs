namespace Questor.DAL.Models.ViewModels;

public class QuestResultViewModel
{
    public string UserId { get; set; }
    public int QuestId { get; set; }
    public bool IsCompleted { get; set; }
    public string TimeInQuest { get; set; }
    public int Result { get; set; }
    public bool SentResultToEmail { get; set; }
}