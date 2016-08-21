# geronimus

Geronimus is a software that solves systems of linear equations. 

:warning: These resolutions were developed by me and they're surely not the best method in terms of performance.

## How it works?

I used 3 methods to solve systems os linear equations, which are:

* [Jacobi method](https://en.wikipedia.org/wiki/Jacobi_method)
* [Gauss-Seidel method](https://en.wikipedia.org/wiki/Gauss%E2%80%93Seidel_method)
* [Gauss-Jordan method (Gaussian elimination)](https://en.wikipedia.org/wiki/Gaussian_elimination)

## Main properties

Method name | Description
--- | ---
AddDimension | Add system dimension. Corresponds to the number of variables in the equations.
AddEquation | Add an equation to the system. The construction of a `LinearEquation` always demands the number of variables in your system (dimension) plus one parameters. Example: x + 2y - 3z = 42 -> This equation has 3 variables, thus it shall be part of a system with 3 equations. The construction should be `new LinearEquation(1, 2, -3, 42)`.
AddErrorRate | Add error rate. The smaller, the more accurate the result.
IsRound | Whether the result should be rounded [in a specified number of decimal places] or not.

## Examples

The examples below expects the following result:

    x =  1 
    y = -1
    z =  1

### Jacobi

```csharp
LinearSystemResult result = new JacobiMethod()
    .AddDimension(3) // Make sure of defining this before set any equation
    .AddEquation(new LinearEquation(10, 2, -1, 7))
    .AddEquation(new LinearEquation(1, 8, 3, -4))
    .AddEquation(new LinearEquation(-2, -1, 10, 9))
    .AddErrorRate(0.000000000001)
    .IsRound(10)
    .SolveIt();
    
// It'll format the result :-)
Console.WriteLine(result.ToString());
```

### Gauss-Siedel

```csharp
LinearSystemResult result = new GaussSeidelMethod()
    .AddDimension(3) // Make sure of defining this before set any equation
    .AddEquation(new LinearEquation(10, 2, -1, 7))
    .AddEquation(new LinearEquation(1, 8, 3, -4))
    .AddEquation(new LinearEquation(-2, -1, 10, 9))
    .AddErrorRate(0.000000000001)
    .IsRound(10)
    .SolveIt();
    
// It'll format the result :-)
Console.WriteLine(result.ToString());
```

### Gouss-Jordan

```csharp
LinearSystemResult result = new GaussJordanMethod()
    .AddDimension(3) // Make sure of defining this before set any equation
    .AddEquation(new LinearEquation(10, 2, -1, 7))
    .AddEquation(new LinearEquation(1, 8, 3, -4))
    .AddEquation(new LinearEquation(-2, -1, 10, 9))
    .AddErrorRate(0.000000000001)
    .IsRound(10)
    .SolveIt();
    
// It'll format the result :-)
Console.WriteLine(result.ToString());
```

### [:octopus: mail me](mailto:ceres.rohana@gmail.com)
