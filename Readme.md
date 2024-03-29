# Bankly Weekly Training - MassTransit Basics

## Objetivo

Apresentação da biblioteca Service Bus ![MassTransit](https://masstransit-project.com/)
Demonstração deconfigurações básicas, publicação e consumo de mensagens, casos de uso.

## Como rodar o projeto
### Pré-requisitos
1 - Docker
2 - Docker Compose
3 - Dotnet

### Passo a passo
1 - Navegue até a pasta-raiz do projeto 

```shell
    docker-compose up -d
```

2 - A partir daí é possível iniciar cada um dos projetos utilizando o comando:

```shell
dotnet run -p Bankly.MassTransitBasics.<Nome do projeto>
```

### Observações:
 - RabbitMQ :  
   - URI: http://Localhost:15672 
   - Password: admin 
   - Username: admin

 - Redis: 
   - Connection String: localhost,port: 6379,password=Redis2019! (exatamente desta maneira)

 - API:
   - endereço HTTPS: https://localhost:5001
   - endereço HTTP: http://localhost:5000
   - endereço do swagger: /swagger/index.html
