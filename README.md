### Для запуска

#### Клонировать

```
git clone https://github.com/acsili/AirportInformationSystemWPF.git
```

#### Установить следующие сомпоненты

* .NET 7 SDK
* Npgsql.EntityFrameworkCore.PostgreSQL 7.0.11
* PostgreSQL

#### В файле ApplicationContext.cs заменить значения Username и Password на те, которые установленны у вас в PostgreSQL
```
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AirportDB;Username=postgres;Password=54321");
    }
```
