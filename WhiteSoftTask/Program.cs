using Utils.Json;
using Utils.Web;
using WhiteSoftTask.Controller;
using WhiteSoftTask.View;


MainController controller = new MainController(new NewtonSerializer(), 
                                               new HttpClientRequest());

var view = new WriteToConsole();

view.ViewResult(controller.SolveProblem());