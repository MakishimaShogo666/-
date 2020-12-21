using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Класс PersonList
/// </summary>
public class PersonList
{
    // Создание полей класса Person
    //
    public List<Person> data; // список из персон
    public static Person ExceptionPerson; // персона, которую нужно удалять из списка

    // Конструктор класса PersonList по умолчанию
    //
    public PersonList()
	{
        data = new List<Person>();
	}

    /// <summary>
    /// Функция-предикат IsNotPerson, позволяющая выделить все персоны, не являющиеся персоной для удаления
    /// </summary>
    /// <param name="Person"></param>
    /// <returns>
    /// Значение true, если персона не совпадает с удаляемой, false - если совадает
    /// </returns>
    public static bool IsNotPerson(Person Person)
    {
        return (Person!=ExceptionPerson);
    }

    /// <summary>
    /// Функция Add для добавления персоны в список
    /// </summary>
    /// <param name="person"></param>
    /// <returns>
    /// Список с добавленной персоной 
    /// </returns>
    public List<Person> Add(Person person)
    {
        data.Add(person);
        return data;
    }

    /// <summary>
    /// Функция ClearList для очистки списка
    /// </summary>
    /// <returns>
    /// Возвращает пустой список
    /// </returns>
    public List<Person> ClearList()
    {
        data.Clear();
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
        return data.Count;
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
        return data.IndexOf(person);
    }

    /// <summary>
    /// Функция Remove для удаления персоны из списка
    /// </summary>
    /// <param name="removingPerson"></param>
    /// <returns>
    /// Возвращает список с удалённой персоной
    /// </returns>
    public List<Person> Remove(Person removingPerson)
    {
        data.RemoveAll((value) => value == removingPerson);
        return data;
    }

    /// <summary>
    /// Функция RemoveByIndex для удаления персоны из списка по индексу
    /// </summary>
    /// <param name="ExceptionPerson"></param>
    /// <returns>
    /// Возвращает список с удалённой персоной
    /// </returns>
    public List<Person> RemoveByIndex(int ExceptionIndex)
    {
        data.RemoveAt(ExceptionIndex);
        return data;
    }
}
