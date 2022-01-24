using System;
using System.Collections.Generic;
// Funcion de primer orden 
// Funcion de orden superior, es una funcion que puede recibir
// como parametro otras funciones, estas funciones que son
// recibidas son funciones de primer orden (pe: Sum, Mul, etc.)
// osea, que una variable que contiene a una funcion tambien
// puede ser enviado como parametro a una funcion

// Estamos guardando en una variable una funcion
Operation mySum = Functions.Sum;

//System.Console.WriteLine(mySum(2, 3));
mySum = Functions.Mul;
//System.Console.WriteLine(mySum(2, 3));

Show cw = Console.WriteLine;
cw += Functions.ConsoleShow;
//cw("Hola mundo");
//Functions.Some("Giordan", "Arredondo", cw);

// El delegado generico nos ayuda a poder ahorra codigo a la
// hora de definir los delegados cuando se definen los parametros

// Usaremos las regiones (que no es codigo) para poder visualizar mejor

#region Action
string hi = "Hola";
// Es una funcion que recibe parametros, pero no regresa nada
// Si se escribe solo Action es porque no recibe parametros
Action<string> showMessage = Console.WriteLine;
// Funciones Lambda (en JS son arrow function), son formas de
// escribir funciones anonimas de manera rapida y practica, sin crear
// un nombre.
Action<string, string> showMessage2 = (a, b) => {
    Console.WriteLine($"{hi} {a} {b}");
};
Action<string, string, string> showMessage3 = (a, b, c) => Console.WriteLine($"{a} {b} {c}");
//showMessage2("Giodan", "Arredondo");
//showMessage3("Giodan", "Arredondo", "Dev");
//Functions.SomeAction("Gabriel", "Arredondo", (a) =>
//{
//    Console.WriteLine("Soy una expresion lambda " + a);
//});
//Functions.SomeAction("Gabriel", "Arredondo", showMessage);
#endregion

#region Func
// La diferencia entre Func y Action es que Action te sirve para
// genericos, pero no devuelve nada, lo que pasa con las funciones
// es que sí retornan algo. Tambien puede retornar algo, siendo el
// ultimo tipo de dato el tipo de dato de lo que se retornara
Func<int> numberRandom = () => new Random().Next(0, 100);
Func<int, string> numberRandomLimit = (limit) => new Random().Next(0, limit).ToString();

//Console.WriteLine(numberRandom());
//Console.WriteLine(numberRandomLimit(10000));
#endregion

#region Predicate
// Estos delegados reciben parametros y devuelven un true o false
Predicate<string> hasSpaceOrA = (word) => word.Contains(" ") || word.ToUpper().Contains("A");
Console.WriteLine(hasSpaceOrA("beear"));
Console.WriteLine(hasSpaceOrA("p ati to"));

var words = new List<string>()
{
    "beer",
    "patita",
    "sandia",
    "hola mundo",
    "c#"
};
var wordsNew = words.FindAll((w) => !hasSpaceOrA(w));
foreach (var w in wordsNew) Console.WriteLine(w);
#endregion

#region Delegados
// El delegado definira la estructura de la funcion
delegate int Operation(int a, int b);
// Para poder utilizar el delegado en el ambito de Functions
// debemos volverlo publico
public delegate void Show(string message);
#endregion

public class Functions
{
    public static int Sum(int x, int y) => x + y;
    public static int Mul(int num1, int num2) => num1 * num2;
    public static void ConsoleShow(string m) => Console.WriteLine(m.ToUpper());
    public static void Some(string name, string lastName, Show fn)
    {
        Console.WriteLine("Hago algo al inicio");
        fn($"Hola {name} {lastName}");
        Console.WriteLine("Hago algo al final");
    }
    public static void SomeAction(string name, string lastName, Action<string> fn)
    {
        Console.WriteLine("Hago algo al inicio");
        fn($"Hola {name} {lastName}");
        Console.WriteLine("Hago algo al final");
    }
}