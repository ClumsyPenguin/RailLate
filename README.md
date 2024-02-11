# RailLate

## EF migration add

```bash
dotnet ef migrations add InitialCreate --startup-project RailLate.REST --project RailLate.Infrastructure
```

## EF migration apply

```bash
dotnet ef database update --project RailLate.REST
```
