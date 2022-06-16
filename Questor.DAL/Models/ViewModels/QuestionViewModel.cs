using Microsoft.AspNetCore.Mvc.ModelBinding;
using Questor.DAL.Models.Enums;

namespace Questor.DAL.Models.ViewModels;

public class QuestionViewModel
{
    public string Title { get; set; }
    public string LinkToPhoto { get; set; }
    public int PointPerQuestion { get; set; }
    public QuestionType QeustionType { get; set; }
    public int QuestId { get; set; }
}