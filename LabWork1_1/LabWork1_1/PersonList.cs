using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Класс PersonList
/// </summary>
public class PersonList
{
    public Person[] data;
    public static readonly int maxListQuantity = 1000;

    public PersonList(int numberOfPerson)
	{
        data = new Person[numberOfPerson];
	}

    /// <summary>
    /// Функция Add для добавления персоны в список
    /// </summary>
    /// <param name="person"></param>
    /// <returns>
    /// Список с добавленной персоной 
    /// </returns>
    public Person[] Add(Person person)
    {
        Array.Resize(ref data, data.Length + 1);
        data[data.Length-1]=person;
        return data;
    }

    /// <summary>
    /// Функция ClearList для очистки списка
    /// </summary>
    /// <returns>
    /// Возвращает пустой список
    /// </returns>
    public Person[] ClearList()
    {
        data = Array.Empty<Person>();
        return data;
    }

    /// <summary>
    /// Функция PersonCount для подсчёта числа персон в списке
    /// </summary>
    /// <returns>
    /// Возвращает число персон в списке
    /// </returns>
    public int PersonCount()
    {
        return data.Length;
    }

    /// <summary>
    /// Функция FindPerson для поиска персоны в списке по индексу
    /// </summary>
    /// <param name="index"></param>
    /// <returns>
    /// Возвращает персону в списке с индексом index
    /// </returns>
    public Person FindPerson(int index)
    {
        return data[index];
    }

    /// <summary>
    /// Функция FindIndex для поиска индекса по указанной персоне
    /// </summary>
    /// <param name="person"></param>
    /// <returns>
    /// Индекс персоны person в списке
    /// </returns>
    public int FindIndex(Person person)
    {
        return Array.IndexOf(data,person);
    }

    /// <summary>
    /// Функция Remove для удаления персоны из списка
    /// </summary>
    /// <param name="removingPerson"></param>
    /// <returns>
    /// Возвращает список с удалённой персоной
    /// </returns>
    ///
    public Person[] Remove(Person removingPerson)
    {
        data = data.Where((value) => value != removingPerson).ToArray(); //если персона не равна удаляемой персоне, то она остаётся в массиве
        return data;
    }

    /// <summary>
    /// Функция RemoveByIndex для удаления персоны из списка по индексу
    /// </summary>
    /// <param name="ExceptionPerson"></param>
    /// <returns>
    /// Cписок с удалённой персоной
    /// </returns>
    public Person[] RemoveByIndex(int ExceptionIndex)
    {
        Person removingPerson = data[ExceptionIndex];
        return data = Remove(removingPerson);
    }
}
