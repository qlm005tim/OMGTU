using System;
class Animal{
  public string Name{get;set;}
  public int YearOfBirth {get;set;} 
  
  public Animal(string name,int yearOfBirth){
      Name=name;
      YearOfBirth=yearOfBirth;
  }
}

class Dog : Animal{
    public string Breed{get; set;}
    public string Color{get; set;}
    
    public Dog(string name, int yearOfBirth,string breed,string color)
        : base(name,yearOfBirth){
        Breed=breed;
        Color=color;
        
    }
}

class Cat: Animal{
    public string Breed{get; private set;}
    public string Color{get;set;}
    
    public Cat(string name,int yearOfBirth, string breed,string color)
        : base(name,yearOfBirth){
        Breed=breed;
        Color=color;
    }
    
    public void Changebr(string newbr)
    {
        Breed=newbr;
    }
}
  class Program{
  static void Main(string[] args) {
    Dog[] dogs=new Dog[3];
    dogs[0]=new Dog("Reks",2020,"Dobermann","Brown");
    dogs[1]=new Dog("Snow",2022,"Labrador","Yellow");
    dogs[2]=new Dog("Dina",2018,"Alabay","Gray");
    
    Cat[] cats=new Cat[3];
    cats[0]=new Cat("Bars",2021,"Siamese","Gray");
    cats[1]=new Cat("Berty",2019,"Russian blue","Gray");
    cats[2]=new Cat("Tom",2017,"Persian","Red");
    
    Console.WriteLine("Собаки породы алабай");
    foreach (Dog dog in dogs){
        if (dog.Breed=="Alabay"){
            Console.WriteLine($"{dog.Name} ({dog.YearOfBirth}), Breed: {dog.Breed}, Color:{dog.Color}");
        }
    }
    
    Console.WriteLine("\nКошки серого цвета ");
    foreach (Cat cat in cats){
        if (cat.Color=="Gray"){
            Console.WriteLine($"{cat.Name} ({cat.YearOfBirth}), Breed: {cat.Breed}, Color:{cat.Color}");
        }
    }
    
    Console.WriteLine("\nМеняем породу кошки Bars to Siberian cat");
    cats[0].Changebr("Siberian cat");
    Console.WriteLine($"Bars ({cats[0].YearOfBirth}),Breed: {cats[0].Breed}, Color:{cats[0].Color}");
  }
}