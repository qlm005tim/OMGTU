static void Main()
{
Car[] cars = new Car[3];
cars[0] = new Car(2000, "синий","audi","Иванов И. И.", 2001);
cars[1] = new Car(2002,"красный","Волга","Петров П. П.", 2003);
cars[2] = new Car(2004,"серый","Нива","Сидоров С. С.", 2005);

foreach (Car car in cars)
{
car.Printcl();
}

Console.WriteLine("Машины, выпущенные в 2004 году:");
foreach (Car car in cars)
{
car.PrintByYear(2004);
}

Console.WriteLine("Машины марки Волга:");
foreach (Car car in cars)
{
car.PrintByName("Волга");
}

Console.WriteLine("Машины с то в 2005 году:");
foreach (Car car in cars)
{
car.PrintByTo(2005);
}

Console.WriteLine("Машины Иванова. И. И.");
foreach (Car car in cars)
{
car.PrintByHold("Иванов И. И.");
}
}
}