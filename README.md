# plinqo

LINQ-Style PowerShell Methods

## About

This is a very simple library that wraps some LINQ methods for integrating with PowerShell. It exposes a single `plinqo` class that you can use to query arrays. You can chain together methods just like with LINQ in C#.

```powershell
$Array = 1..1000000
[plinqo]::new($Array).Where({$args[0] -gt 10000}).Skip(10).Take(100)
```

## Installation

```powershell
Install-Module plinqo
Import-Module plinqo
```

## Performance 

plinqo is pretty fast. It's about as fast as the `where()` method in PowerShell and much faster than `Where-Object`.

```powershell
$Array = 1..1000000
Measure-Command {
    [plinqo]::new($Array).Where({$args[0] -gt 10000})
}

Days              : 0
Hours             : 0
Minutes           : 0
Seconds           : 1
Milliseconds      : 766
Ticks             : 17665031
TotalDays         : 2.04456377314815E-05
TotalHours        : 0.000490695305555556
TotalMinutes      : 0.0294417183333333
TotalSeconds      : 1.7665031
TotalMilliseconds : 1766.5031


Measure-Command {
    $Array.Where({$_ -gt 10000})
}

Days              : 0
Hours             : 0
Minutes           : 0
Seconds           : 1
Milliseconds      : 632
Ticks             : 16328007
TotalDays         : 1.889815625E-05
TotalHours        : 0.00045355575
TotalMinutes      : 0.027213345
TotalSeconds      : 1.6328007
TotalMilliseconds : 1632.8007

Measure-Command {
    $Array | Where-Object {$_ -gt 10000}
}

Days              : 0
Hours             : 0
Minutes           : 0
Seconds           : 5
Milliseconds      : 303
Ticks             : 53037798
TotalDays         : 6.13863402777778E-05
TotalHours        : 0.00147327216666667
TotalMinutes      : 0.08839633
TotalSeconds      : 5.3037798
TotalMilliseconds : 5303.7798
```

## Methods

plinqo provides methods for numerous LINQ extension methods. 

- All
- Any
- Average
- Concat
- Contains
- Count
- Distinct
- ElementAt
- Except
- First
- FirstOrDefault
- Last
- LastOrDefault
- Select
- Single
- SingleOrDefault
- Skip
- Sum
- Take
- Where

