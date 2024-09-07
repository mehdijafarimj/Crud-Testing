namespace Logic.ViewModels;

public class GetAdminWithUserVm
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public List<GetUserVm> UserVm { get; set; } 
}
public class GetUserVm
{
    public string Name { get; set; }
    public string LastName { get; set; }
}