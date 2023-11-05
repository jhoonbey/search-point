# Search Point

Search Point application provides an API which you can send point(x,y) and it returns a rectangles that point lies in

## Tech

- [C#]
- [NET 7]
- [Entity Framework Core]
- [Automapper]
- [SQL]
- [xUnit]

Change the Database connection to your server in the appsettings.json file before starting the project:
```sh
  "DefaultConnection": "Data Source=localhost;Initial Catalog=SearchPointDB;User ID=sa; Password=Demo#333;TrustServerCertificate=true;"
  }
```

## Run

Run following commands:

For DB init
```sh
dotnet ef migrations add InitialCreate --project SearchPoint.Data -s SearchPoint.Web -c ApplicationDBContext
```

For DB update
```sh
  dotnet ef database update  --project SearchPoint.Data -s SearchPoint.Web -c ApplicationDBContext
```


## Rest API sample:

Request:
```sh
https://localhost:7226/Rectangle?X=70&Y=77
```

Response:
```sh
[
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
  }
]
```