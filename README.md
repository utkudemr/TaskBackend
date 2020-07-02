# TaskBackend

Backend projesi asp.net core web api kullanılarak geliştirilmiştir.

Katmanlar arası iletişim için Autofac ile birlikte dependecy injection kullandıldı.

Validation,security işlemleri için AOP(aspect oriented programming) kullanıldı.
(Business katmanında metot çalışmadan önce önüne geçip gerekli işlemleri yapıyor.)

Veritabanı entity framework code first ile tasarlandı.(fluent api ile birlikte)

Web api güvenliği olarak JWT kullanıldı.(json web token)

/*************************************************/
Kayıt olurken(post)
<br>
https://localhost:44335/api/auth/register

Body
{
   "Email": "utku@hotmail.com",
   "Password": "123456789",
   "Firstname":"utku",
   "Lastname":"demir",
}
<br>
/*************************************************/
<br>
Giriş yaparken(post)

https://localhost:44335/api/auth/login

Body
{
    "email":"utku@hotmail.com",
    "password":"123456789"
}
<br>
/*************************************************/

Görevleri çekerken(get)

https://localhost:44335/api/task/getlist

/*************************************************/
Görev detayları çekerken(get)

https://localhost:44335/api/task/get/{id}

/*************************************************/

Görev detayları güncellerken(put)

https://localhost:44335/api/task/update

Body
{
      "id":1,
      "taskName": "asd",
      "explanation":"açıklama",
      "startDate":"2.07.2020",
      "endDate":"2.07.2020"
}
/*************************************************/
Görev silerken(delete)

https://localhost:44335/api/task/delete/{id}

Body
{
      "id":1,
      "taskName": "asd",
      "explanation":"açıklama",
      "startDate":"2.07.2020",
      "endDate":"2.07.2020"
}
/*************************************************/
