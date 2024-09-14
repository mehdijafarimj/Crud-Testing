namespace Logic.ViewModels;

public class GetAdminWithUserVm
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public List<GetUserVm> UserVm { get; set; } 
}
public class GetUserVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
}