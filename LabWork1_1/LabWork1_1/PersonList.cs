using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Класс PersonList
/// </summary>
public class PersonList
{
    #region Поля
    /// <summary>
    /// Записи в списке персон
    /// </summary>
    public Person[] data;
    /// <summary>
    /// Максимальное число списков персон (только для чтения)
    /// </summary>
    public static readonly int maxListQuantity = 200000000;
    #endregion

    #region Конструктор
    public PersonList(int numberOfPerson)
	{
        data = new Person[numberOfPerson];
	}
    #endregion

    #region Методы
    /// <summary>
    /// Процедура для добавления персоны в список
    /// </summary>
    /// <param name="person">Персона</param>
    /// <returns>
    /// Список с добавленной персоной 
    /// </returns>
    public void Add(Person person)
    {
        Array.Resize(ref data, data.Length + 1);
        data[data.Length-1] = person;
    }

    /// <summary>
    /// Функция для очистки списка
    /// </summary>
    /// <returns>
    /// Пустой список
    /// </returns>
    public Person[] ClearList()
    {
        data = Array.Empty<Person>();
        return data;
    }

    /// <summary>
    /// Функция для подсчёта числа персон в списке
    /// </summary>
    /// <returns>
    /// Число персон в списке
    /// </returns>
    public int PersonCount()
    {
        return data.Length;
    }

    /// <summary>
    /// Функция для поиска персоны в списке по индексу
    /// </summary>
    /// <param name="index">Номер персоны в списке персон</param>
    /// <returns>
    /// Персона в списке с индексом index
    /// </returns>
    public Person FindPerson(int index)
    {
        return data[index];
    }

    /// <summary>
    /// Функция для поиска индекса по указанной персоне
    /// </summary>
    /// <param name="person">Персона</param>
    /// <returns>
    /// Индекс персоны person в списке
    /// </returns>
    public int FindIndex(Person person)
    {
        return Array.IndexOf(data,person);
    }

    /// <summary>
    /// Функция для удаления персоны из списка
    /// </summary>
    /// <param name="removingPerson">Удаляемая персона</param>
    /// <returns>
    /// Список с удалённой персоной
    /// </returns>
    ///
    public Person[] Remove(Person removingPerson)
    {
        data = data.Where((value) => value != removingPerson).ToArray();
        return data;
    }

    /// <summary>
    /// Функция RemoveByIndex для удаления персоны из списка по индексу
    /// </summary>
    /// <param name="removingIndex">Индекс удаляемой персоны</param>
    /// <returns>
    /// Список с удалённой персоной
    /// </returns>
    public Person[] RemoveByIndex(int removingIndex)
    {
        data = data.Where((value, index) => index != removingIndex).ToArray();
        return data;
    }
    #endregion
}
