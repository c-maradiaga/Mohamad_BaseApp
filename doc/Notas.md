

[10] En el proyecto Entities se creo la carpeta DbSet y las siguientes clases
BaseEntity, Achivement y Driver, y la relacion entre Driver y Achivements (1 a muchos)

[11] Se creo la clase DbContext:
- En la terminal  nos pasamos al proyecto DataService para instalar lo siguiente:
- dotnet add package Microsoft.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet add package Microsoft.EntityFrameworkCore.Sqlite

[12] Se creo la clase DbContext:
- Al proyecto DataServices se le agrego la referncia al proyecto Entities
- En el pryecto DataService se creo una carpeta llamada Data y dentro una clase llamada AppDbContext
- Se creaon los dbset y las relaciones entre las tablas
- Estando el proyecto DataService:
  - dotnet add package Microsoft.EntityFrameworkCore.Design
- En el appsettings.json:
  - "ConnectionStrings": {
     "DefaultConnection": "DataSource=FormulaOne.db;"
[13]- En program.cs
- El proyecto .Api agregar la referencia al proyeto .DataServices porque este contiene la clase AppDbContext.

[14] Haciendo la migracion. Deontro de la carpeta .DataServices: (porque este proyecto contiene la clase del Context AppDbContext )
dotnet ef migrations add  "Inicial" --startup-project ../FormulaOne.Api
Se generò este error:

Your startup project 'FormulaOne.Api' doesn't reference Microsoft.EntityFrameworkCore.Design. This package is required for the Entity Framework Core Tools to work. Ensure your startup project is correct, install the package, and try again.

Por lo que instale Microsoft.EntityFrameworkCore.Design en el proyecto .API y probè nuevamente:
dotnet ef migrations add "Inicial" --startup-project ../FormulaOne.Api
y se creo la migracion en el proyecto .DataServices

-- Actualizando la BD:
dotnet ef database update --startup-project ../FormulaOne.Api

[15] Creando los Repositories:
- En el proyecto .DataServices, se creo la carpeta Repositories y dentro se creo la carpeta Interfaces.
- Dentro de Interfaces se creo la interface IGenericRepository
- Se definicrion los metodos para la interface IGenericRepository
- Se creo la interface IDriverRepository y la interface IAchivementeRepository

##### propiedades protected:
* La palabra clave protected se utiliza para especificar que una propiedad o método es accesible dentro de la misma clase y también por cualquier clase derivada (subclase).
*En el contexto de tu repositorio genérico, la propiedad protected AppDbContext context; significa que esta propiedad es visible dentro de la clase GenericRepository<T> y también en cualquier clase que herede de ella.
*En otras palabras, las clases derivadas (por ejemplo, si creas una clase específica que hereda de GenericRepository<T>) pueden acceder a esta propiedad para realizar operaciones relacionadas con la base de datos o el contexto.

##### propiedades internal:
* La palabra clave internal se utiliza para especificar que una propiedad o método es accesible dentro del mismo ensamblado (proyecto) pero no fuera de él.
* En tu código, la propiedad internal DbSet<T>? _dbSet; significa que solo las clases dentro del mismo proyecto (ensamblado) pueden acceder a esta propiedad.
* Esto proporciona una encapsulación adicional, ya que evita que otras clases o proyectos externos manipulen directamente _dbSet.
Es común utilizar internal para componentes internos que no deben ser expuestos públicamente, pero que aún necesitan ser utilizados dentro del mismo proyecto.

* En resumen:
protected: Visible dentro de la clase y sus clases derivadas.
internal: Visible solo dentro del mismo proyecto (ensamblado).

##### el uso de virtual en los mètodos:
* The virtual keyword in C# is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class.
* Overriding Behavior: If a subclass needs to change the way the Add method works (for example, to add some validation or logging), it can override the method and provide the new behavior while still having the option to call the base class implementation
* Polymorphism: It supports polymorphism, where a method can have different behaviors based on the runtime type of the object that invokes it. This is a core concept in object-oriented programming that allows for more flexible and reusable code.
* So, in summary, the virtual keyword provides flexibility and extensibility in your code, allowing derived classes to customize the behavior of the method as needed.
* 





























