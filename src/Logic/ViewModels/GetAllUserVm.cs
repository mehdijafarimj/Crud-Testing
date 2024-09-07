namespace Logic.ViewModels;
public class GetAllUserVm
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public GetAdminWithUserVm AdminVm { get; set; }
    public int AdminId { get; set; }
}
