using APIProj.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIProj.Services;

public static class PizzaServices
{
    static List<Pizza> Pizzas {get;}
    static int nextId = 3;
    static PizzaServices()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza {Id = 1, Name = "Italian", IsGluttenFree = false},
            new Pizza {Id = 2, Name = "Veggie", IsGluttenFree = true}
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        Pizza pizza = Get(id);

        if (pizza is null) return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        int index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1) return;

        Pizzas[index] = pizza;
    }
}