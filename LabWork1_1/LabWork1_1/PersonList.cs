using System;
using System.Collections.Generic;
using System.Linq;
public class PersonList
{
    public List<Person> data;

    public static Person ExceptionPerson;

	public PersonList()
	{
        data = new List<Person>();
	}

    public static bool IsNotPerson(Person Person)
    {
        return (Person!=ExceptionPerson);
    }

    public List<Person> Add(Person person)
    {
        data.Add(person);
        return data;
    }

    public List<Person> ClearList()
    {
        data.Clear();
        return data;
    }

    public int PersonCount()
    {
        return data.Count;
    }

    public Person FindPerson(int index)
    {
        return data[index];
    }

    public int FindIndex(Person person)
    {
        return data.IndexOf(person);
    }

    public List<Person> Remove(Person ExceptionPerson)
    {
        data.RemoveAll(IsNotPerson);
        return data;
    }

    public List<Person> RemoveByIndex(int ExceptionIndex)
    {
        data.RemoveAt(ExceptionIndex);
        return data;
    }
}
