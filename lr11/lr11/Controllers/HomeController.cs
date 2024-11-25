using Microsoft.AspNetCore.Mvc;
using System.IO;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        string actionLog = System.IO.File.Exists("action_log.txt")
            ? System.IO.File.ReadAllText("action_log.txt")
            : "���� action_log.txt �������.";

        string uniqueUserLog = System.IO.File.Exists("unique_user_log.txt")
            ? System.IO.File.ReadAllText("unique_user_log.txt")
            : "���� unique_user_log.txt �������.";

        ViewBag.ActionLog = actionLog;
        ViewBag.UniqueUserLog = uniqueUserLog;

        return View();
    }

    public IActionResult About()
    {
        return Content("������� '��� ���'.");
    }

    public IActionResult Contact()
    {
        return Content("������� '��������'.");
    }
}
