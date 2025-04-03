# App de Registro de Asistencia con QR

## Descripción
Esta es una aplicación basada en **.NET MAUI 8** que permite gestionar la asistencia a un evento mediante el escaneo de códigos QR. La app consume una API en **.NET Core 8**, obteniendo los datos de los asistentes y registrando su asistencia mediante un sistema de validación.

## Tecnologías Utilizadas
- **.NET MAUI 8**
- **ZXing.Net.MAUI** (Para escaneo de códigos QR)
- **API en .NET Core 8**
- **MySQL** (Base de datos gestionada por la API)

## Requisitos Previos
Antes de ejecutar la aplicación, asegúrate de contar con lo siguiente:
- **.NET SDK 8** instalado.
- **Android Emulator** o un dispositivo Android.
- **API en ejecución** para conectarse a la base de datos.

## Instalación y Configuración

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tuusuario/nombre-del-repositorio.git
   cd nombre-del-repositorio
   ```

2. **Configurar la URL de la API**
   En el código de la aplicación, cambia la dirección de la API en la variable donde se realizan las peticiones `GET` y `PUT`:
   ```csharp
   private const string ApiUrl = "http://TU_IP:5000/api/usuarios";
   ```

3. **Compilar y ejecutar en Android**
   ```bash
   dotnet build
   dotnet run
   ```

   También puedes ejecutar directamente desde Visual Studio seleccionando un emulador o un dispositivo físico.

## Funcionamiento
1. El usuario **escanea un código QR** con la cámara.
2. La app **extrae el ID** contenido en el QR.
3. Realiza una petición **GET a la API** para obtener los datos del asistente.
4. Se muestran los datos del asistente, incluyendo:
   - **Nombre**
   - **Matrícula**
   - **Días de asistencia (Miércoles y Jueves)**
5. Si el asistente está presente, el usuario marca el checkbox correspondiente y la app realiza un **PUT a la API** para registrar la asistencia.
6. Un código QR **no puede ser reutilizado** el mismo día.

## Pruebas y Debugging
- Se puede probar directamente desde el **emulador de Android** incluido en .NET MAUI, sin necesidad de compilar e instalar la app repetidamente.
- Verifica que la **API esté en ejecución** antes de realizar pruebas.

## Posibles Mejoras
- Implementar autenticación con **JWT** para restringir el acceso.
- Mejorar la interfaz gráfica y experiencia de usuario.
- Agregar soporte y pruebas para iOS.

## Contribuciones
Si deseas contribuir, siéntete libre de hacer un *fork* del proyecto y enviar un *pull request*.

---
📱 *Desarrollado para facilitar el registro de asistencia mediante tecnología QR.* 🚀

