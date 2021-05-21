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
    private PersonBase[] _data;

    /// <summary>
    /// Записи в списке персон
    /// </summary>
    public PersonBase[] Data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
        }
    }

    /// <summary>
    /// Максимальное число списков персон (только для чтения)
    /// </summary>
    public static readonly int maxListQuantity = 200000000;
    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор списка персон по умолчанию
    /// </summary>
    /// <param name="numberOfPerson">Число персон</param>
    public PersonList(int numberOfPerson)
	{
        if (numberOfPerson < 0)
        {
            throw new ArgumentOutOfRangeException("Число персон в списке не может быть отрицательным!");
        }
        else
        {
            _data = new PersonBase[numberOfPerson];
        }
	}

    #endregion

    #region Методы
    /// <summary>
    /// Процедура для добавления персоны в список
    /// </summary>
    /// <param name="person">Персона</param>
    public void Add(PersonBase person)
    {
        Array.Resize(ref _data, _data.Length + 1);
        _data[_data.Length-1] = person;
    }


    /// <summary>
    /// Процедура очистки списка
    /// </summary>
    public void Clear()
    {
        _data = Array.Empty<PersonBase>();
    }

    /// <summary>
    /// Функция для подсчёта числа персон в списке
    /// </summary>
    /// <returns>
    /// Число персон в списке
    /// </returns>
    public int PersonCount()
    {
        return _data.Length;
    }

    /// <summary>
    /// Функция для поиска персоны в списке по индексу
    /// </summary>
    /// <param name="index">Номер персоны в списке персон</param>
    /// <returns>
    /// Персона в списке с индексом index
    /// </returns>
    public PersonBase FindPerson(int index)
    {
        return _data[index];
    }

    /// <summary>
    /// Функция для поиска индекса по указанной персоне
    /// </summary>
    /// <param name="person">Персона</param>
    /// <returns>
    /// Индекс персоны person в списке
    /// </returns>
    public int FindIndex(PersonBase person)
    {
        return Array.IndexOf(_data,person);
    }

    /// <summary>
    /// Процедура удаления персоны из списка
    /// </summary>
    /// <param name="removingPerson">Удаляемая персона</param>
    public void Remove(PersonBase removingPerson)
    {
        _data = _data.Where(value => value != removingPerson).ToArray();
    }

    /// <summary>
    /// Процедура удаления персоны из списка по индексу
    /// </summary>
    /// <param name="removingIndex">Индекс удаляемой персоны</param>
    public void RemoveByIndex(int removingIndex)
    {
        _data = _data.Where((value, index) => index != removingIndex).ToArray();
    }
    
    #endregion
}
