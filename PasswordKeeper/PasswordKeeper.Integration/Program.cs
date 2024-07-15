using PasswordKeeper.Core.Data;
using PasswordKeeper.Core.Entity;
using PasswordKeeper.Core.Service;

//Console.WriteLine("Hello, World!");

//Password keeper = new Password();
//keeper.NameOfSmth = "Test_app";
//keeper.Login = "user";
//keeper.PasswordSecure = "123123";
//Password keeper2 = new Password();
//keeper2.NameOfSmth = "Test_app2";
//keeper2.Login = "user2";
//keeper2.PasswordSecure = "1231232";

//DataPassword dataSource = new DataPassword();
//dataSource.Write(new List<Password> {keeper, keeper2});

//Console.WriteLine(string.Join(" ", dataSource.Get()));

//Console.WriteLine(keeper);


//Добавление новой записи. Изменение её параметров, удаление записи
NoteService noteService = new NoteService(new DataNote());

noteService.Create(new Note("Test1", "This is test line"));
Console.WriteLine(string.Join("\n", noteService.GetAll()));

noteService.Create(new Note("Test2", "Test another line"));
Console.WriteLine(string.Join("\n", noteService.GetAll()));


