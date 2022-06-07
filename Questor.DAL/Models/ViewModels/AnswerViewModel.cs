namespace Questor.DAL.Models.ViewModels;

public class AnswerViewModel
{
    public string Value { get; set; }
    public int QuestionId { get; set; }
    public bool IsCorrect { get; set; }
}