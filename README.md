# Contact

### Migrations

Uygulamak için `Services/Contact/Contact.Data` dizininde

```
dotnet ef database update --startup-project "../Contact.API/Contact.API.csproj"
```

calıştırılmalıdır.



Bir kişi rapor istediğinde kuyruğa eklerken verinin kaybolması engellenmek amaçlı outbox pattern kullanıldı



Contact.API -> Contact api
ContactReport.Outbox.Service -> Publisher
ContactReport.Console.App -> Subscriber 



Projede 

RabbitMQ, Masstransit, Quartz.Net kullanıldı. 



1. ContactReport.Outbox.Service konsol uygulaması çalıştırılmalıdır.

2. ContactReport.Console.App konsol uygulaması çalıştırılmalıdır.

3. Contact.API uygulaması swagger uzerinden bir user eklenip RequestReport endpointine user id si yolladıgında calısacaktır.