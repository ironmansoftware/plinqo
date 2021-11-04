using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

public class Plinq : IEnumerable<object>
{
    private readonly IEnumerable<object> _psobjects;
    public Plinq(IEnumerable<object> psobject)
    {
        _psobjects = psobject;
    }

    public IEnumerator<object> GetEnumerator()
    {
        return _psobjects.GetEnumerator();
    }

    public bool All(ScriptBlock scriptBlock)
    {
        return _psobjects.All(x => (bool)scriptBlock.Invoke(x).First().BaseObject == true);
    }

    public bool Any(ScriptBlock scriptBlock)
    {
        return _psobjects.Any(x => (bool)scriptBlock.Invoke(x).First().BaseObject == true);
    }

    public decimal Average(ScriptBlock scriptBlock)
    {
        return _psobjects.Average(x => (decimal)scriptBlock.Invoke(x).First().BaseObject);
    }

    public Plinq Concat(IEnumerable<object> psobjects)
    {
        return new Plinq(_psobjects.Concat(psobjects));
    }

    public bool Contains(object obj)
    {
        return _psobjects.Contains(obj);
    }

    public int Count()
    {
        return _psobjects.Count();
    }

    public Plinq Distinct()
    {
        return new Plinq(_psobjects.Distinct());
    }

    public object ElementAt(int index)
    {
        return _psobjects.ElementAt(index);
    }

    public Plinq Except(IEnumerable<object> psobjects)
    {
        return new Plinq(_psobjects.Except(psobjects));
    }

    public object First()
    {
        return _psobjects.First();
    }

    public object FirstOrDefault()
    {
        return _psobjects.FirstOrDefault();
    }

    public object Last()
    {
        return _psobjects.Last();
    }

    public object LastOrDefault()
    {
        return _psobjects.LastOrDefault();
    }

    public object Single()
    {
        return _psobjects.Single();
    }

    public object SingleOrDefault()
    {
        return _psobjects.SingleOrDefault();
    }

    public Plinq Skip(int count)
    {
        return new Plinq(_psobjects.Skip(count));
    }

    public decimal Sum(ScriptBlock scriptBlock)
    {
        return _psobjects.Sum(x => Convert.ToDecimal(scriptBlock.Invoke(x).First().BaseObject));
    }


    public Plinq Take(int count)
    {
        return new Plinq(_psobjects.Take(count));
    }

    public Plinq Where(ScriptBlock scriptBlock)
    {
        return new Plinq(_psobjects.Where(x => (bool)scriptBlock.Invoke(x).First().BaseObject == true));
    }

    public Plinq Select(ScriptBlock scriptBlock)
    {
        return new Plinq(_psobjects.Select(x => scriptBlock.Invoke(x).First()));
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _psobjects.GetEnumerator();
    }
}