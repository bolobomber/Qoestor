namespace Questor.DAL.Models.ViewModels;
public class EditUserViewModel
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
}
public class ChangePasswordViewModel
{
    public string Id { get; set; }
    public string NewPassword { get; set; }
}