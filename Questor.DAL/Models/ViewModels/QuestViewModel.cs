namespace Questor.DAL.Models.ViewModels;

public class QuestViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsPublic { get; set; }
    public bool WriteOffControlMode { get; set; }
    public int TimeLimit { get; set;  }
}