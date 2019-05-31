# Students Web Api
Projeto destinado a APS da disciplina de Métodos Avançados de Programação.
## Getting Started
Abra o projeto no [Visual Studio Code](https://azure.microsoft.com/pt-br/products/visual-studio-code/)

### Pré-requisitos

* [.Net Core 2.2](https://dotnet.microsoft.com/download)

* [Postman](https://www.getpostman.com/)

OBS:::: NÃO ABRA O PROJETO USANDO A IDE VISUAL STUDIO. TODO O PROJETO FOI FEITO NO VSCODE E ISSO PODE ACARRETAR ALGUN ERRO NA HORA DA EXECULÇÃO

Inicie a aplicação usando o comando

```
dotnet run
```

### ENDPOINT'S

OBS:::: TODOS OS ENDPOINTS POSSUEM OS MÉTODOS CRUD (CREATE, READ, UPDATE E DELETE) 

http://localhost:5000/api/student/

Busca por ID

http://localhost:5000/api/student/ + id

EX:

http://localhost:5000/api/student/1

```
    EXEMPLO DE MÉTODO POST

{
    "registration": "1-2009229232",
    "name": "FULANO",
    "term": 4,
    "class": "SEF4N",
    "disciplines": [
        {	
            "Id": 1,
            "name": "Metodos Avancado de programação",
            "TeacherId": 13,
            "Teacher": null
        }
    ]
}
```

http://localhost:5000/api/discipline/

Busca por ID

http://localhost:5000/api/discipline/ + id

EX:

http://localhost:5000/api/discipline/1

```
    EXEMPLO DE MÉTODO POST

{
	"Name": "Metodos Avancados de Programacao",
	"TeacherId": 13
}
```
http://localhost:5000/api/teacher/

Busca por ID

http://localhost:5000/api/teacher/ + id

EX:

http://localhost:5000/api/teacher/13

```
    EXEMPLO DE MÉTODO POST

{
    "Registration": "1-23432112",
    "Name": "Metodos Avancados de Programacao",
}
```

## Built With

* [.Net Core](https://docs.microsoft.com/pt-br/dotnet/core/)
* [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
* [Entity Framework Core - Npgsql](http://www.npgsql.org/efcore/)

