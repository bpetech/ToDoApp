# ToDoApp

Bu proje, kullanıcıların yapılacaklar listesi oluşturmasına, güncellemesine ve yönetmesine olanak tanıyan basit bir ToDo uygulamasıdır. Proje, bir RESTful API ile çalışmakta olup frontend olarak HTML, CSS, ve jQuery kullanmaktadır.

## Proje İçeriği

- Kullanılan Teknolojiler
- Kurulum
- Kullanım
- API Endpoints
- Veritabanı Yapısı
- Özellikler
- Yapı

---

## Kullanılan Teknolojiler

Bu projede aşağıdaki teknolojiler ve araçlar kullanılmıştır:

- **.NET 8**: Backend API geliştirmek için.
- **Entity Framework Core**: Veritabanı işlemleri için ORM.
- **MediatR**: CQRS ve Handler yapısını sağlamak için.
- **MSSQL**: Veritabanı yönetim sistemi olarak.
- **HTML, CSS, jQuery**: Frontend arayüzü.
- **Bootstrap**: UI geliştirmek ve toast bildirimleri için.
- **Git ve GitHub**: Sürüm kontrol ve kaynak kodu yönetimi için.

## Kurulum

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyin.

### Projeyi klonlayın
```
git clone https://github.com/kullanici-adi/ToDoApp.git
cd ToDoApp
```
## Kullanım

### ToDo Uygulamasında Görev Eklemek, Güncellemek ve Silmek

- **Görev Ekleme**: Görev başlığı ve açıklaması girilerek "Görev Ekle" butonuna basılır.
- **Görev Güncelleme**: Bir görevi tamamlamak için ilgili checkbox işaretlenir veya kaldırılır.
- **Görev Silme**: Silmek istediğiniz görevin sağında bulunan çöp kutusu ikonuna tıklayın.

### Önemli Notlar

- Uygulama, boş başlık veya açıklama ile görev eklemeyi önlemektedir. Boş veri girilirse bir uyarı bildirimi görüntülenir.
- Görevler checkbox ile işaretlendiğinde tamamlanmış olarak işaretlenir ve gri renge döner.

---

## API Endpoints

Proje içinde yer alan API'ler aşağıdaki gibidir:

- **GET /api/todo/GetAll**: Tüm görevleri getirir.
- **GET /api/todo/GetById/{id}**: Belirtilen ID'ye sahip görevi getirir.
- **POST /api/todo/Create**: Yeni bir görev oluşturur.
- **PUT /api/todo/Update/{id}**: Mevcut görevi günceller.
- **DELETE /api/todo/Delete/{id}**: Belirtilen ID'ye sahip görevi siler.

![image](https://github.com/user-attachments/assets/23c1f4ea-171b-4670-965d-3c8d68e5453d)

