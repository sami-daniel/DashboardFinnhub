# Dashboard de Ações com ASP.NET Core

Este é um projeto ASP.NET Core que implementa um dashboard para pesquisa de ações usando a API do Finnhub. A aplicação exibe uma barra de pesquisa que permite aos usuários buscar informações sobre ações e exibe os resultados em tempo real.

![image](https://github.com/user-attachments/assets/545d2bb2-819c-468e-9739-4b5c1c3ad38a)


## Funcionalidades

- Barra de pesquisa para buscar informações sobre ações.
- Integração com a API do Finnhub para obter dados de ações.
- Exibição de resultados de pesquisa de forma intuitiva e acessível.

## Tecnologias Utilizadas

- ASP.NET Core
- HTML, CSS, JavaScript
- API do Finnhub

## Pré-requisitos

Certifique-se de ter os seguintes itens instalados no seu sistema:

- [.NET SDK 8.0 ou superior](https://dotnet.microsoft.com/download) 
- [FinnhubAPIToken](https://finnhub.io/dashboard)

## Como utilizar

Clone o repositório para o seu ambiente local:

```bash
git clone https://github.com/sami-daniel/DashboardFinnhub.git
cd DashboardFinnhub
```

Inicializar User Secrets

```bash
dotnet user-secrets init
```

Setar token da API

```bash
dotnet user-secrets set "FinnhubToken" "sua-chave-api-aqui"
```

Restaurar Dependências
```bash
dotnet restore
```

Compilar o Projeto
```bash
dotnet build
```

Executar
```bash
dotnet run
```
