using _420DA3_Demo_Iterative.Business.Services;
using _420DA3_Demo_Iterative.DataAccess;
using _420DA3_Demo_Iterative.Presentation;

namespace _420DA3_Demo_Iterative.Business;
public class App {
    public EtudiantService EtudiantService { get; set; }
    public CoursService CoursService { get; set; }
    private readonly MainMenu mainMenu;

    public App() {
        ApplicationConfiguration.Initialize();
        this.EtudiantService = new EtudiantService();
        this.CoursService = new CoursService();
        this.mainMenu = new MainMenu(this);
    }

    public void Start() {
        Application.Run(this.mainMenu);
    }

    public void Stop() {
        SqlServerConnectionProvider.CloseConnection();
        Application.Exit();
    }
}
