# ASP.NET CORE 	Web API ile MongoDB Crud İşlemleri

Mongo DB'ye insert update ve delete yapan bir kayıt yönetim sistemidir.

# Teknolojiler

 - .Net Core 2.1
 - Mongo DB 4.0
 - Postman 7.0.6

## Kurulum

 1. [https://www.getpostman.com/downloads/] sitesinden **Postman** indirilir ve gerekli makinaya kurulur.
 2. İndirilen proje istenilen bir lokasyona çıkarılır.
 3. [https://www.mongodb.com/download-center/community] sitesinden uygun olan sürüm indirilir. Mongo DB kurulumu yapılır.
 4. Command Prompt açılarak `cd \d C:\Program Files\MongoDB\Server\4.0\bin` klasörüne locate olunur.
 5. Ardından Mongo DB serverını başlatmak için `mongod` komutu yazılarak server başlatılır.
 6. Mongo DB kurulumu ile gelen **Mongo Db Compass Community** açılır. Hostname : **localhost** ve Post  : **27017** olacak şekilde bağlantı kurulur.
 7. Mongo Db Compass Community'de Assessment adında bir database oluşturulur ve Collection adına Record verilir.
 
## Test
 1. İndirilen proje çalıştırılır.
 2. Postman'de aşağıdaki gibi bir post işlemi yapılarak ilk kayıt database atılır.
 ![alt text](https://github.com/Dilek0/WebApiMongoDB/blob/master/Screenshot.PNG)
 3. Projedeki api/record adresine gidilerek eklenen kayıt ile ilgili değişiklik görülür.
