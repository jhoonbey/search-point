# Search Point

Search Point application provides an API which you can send point(x,y) list and it returns a rectangles that point list lie in

## Tech

- [C#]
- [NET 7]
- [Entity Framework Core]
- [LINQ]
- [LinqKit]
- [Automapper]
- [SQL]
- [xUnit]


## Run

Change the Database connection to your server in the appsettings.json file before starting the project:
```sh
  "DefaultConnection": "Data Source=localhost;Initial Catalog=SearchPointDB;User ID=sa; Password=Demo#333;TrustServerCertificate=true;"
  }
```  

Run following commands:

For DB init
```sh
dotnet ef migrations add InitialCreate --project SearchPoint.Data -s SearchPoint.Web -c ApplicationDBContext
```

For DB update
```sh
  dotnet ef database update  --project SearchPoint.Data -s SearchPoint.Web -c ApplicationDBContext
```


## Example from Postman:

URL:
```sh
https://localhost:7226/Rectangle
```

Request body:
```sh
{
  "points": [
    {
      "x": 70,
      "y": 80
    },
    {
      "x": 115,
      "y": 100
    }
  ]
}
```

Response:
```sh
[
    {
        "bottomLeftX": 112,
        "bottomLeftY": 96,
        "topRightX": 120,
        "topRightY": 119
    },
    {
        "bottomLeftX": 67,
        "bottomLeftY": 76,
        "topRightX": 74,
        "topRightY": 103
    },
    {
        "bottomLeftX": 49,
        "bottomLeftY": 71,
        "topRightX": 74,
        "topRightY": 92
    },
    {
        "bottomLeftX": 100,
        "bottomLeftY": 95,
        "topRightX": 127,
        "topRightY": 111
    }
]
```