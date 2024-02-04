# EPICAS
## Gestión de Recetas
Se requiere tener un repositorio de recetas para registrar los secretos culinarios de la familia e ir mejorándolas y transfiriéndolas de generación en generación.


# HISTORIAS DE USUARIO

## 📄 Registrar Recetas

### 🔹 Registro Normal
> _COMO_ usuario
> _QUIERO_ registrar recetas
> _PARA_ salvaguardar la información de cada una de ellas

#### Especificación de Reglas:
Esta funcionalidad de trata de grabar Recetas con la información necesaria correspondiente.  La funcionalidad se sitúa en el formulario "Registro de Recetas".

#### Información Necesaria:
+ Tiempo de Preparación
    + _El tiempo de preparación cuenta con un formato específico con un límite de `99 horas` y `59 minutos`. Siendo el valor máximo `99:59` el cual representa a NOVENTA Y NUEVE HORAS CON CINCUENTA Y NUEVE MINUTOS. Pasado el límite debe mostrarse un error._
+ Porciones
    + _El campo de porciones tiene un funcionamiento doble._
        + _Si la Receta está grabada (modo lectura), al cambiar el valor del campo, se calcularán las cantidades de los ingredientes en función a la cantidad de porciones/comensales._
        + _Si la Receta está grabada (modo escritura), al cambiar el valor del campo se actualizará la cantidad de porciones/comensales para la receta sin afectar la lista de Ingredientes._
+ Ingredientes
    + _Los ingredientes serán agregados directamente desde el formulario de Registro de Receta. Si no existe el ingrediente en la base de datos, se deberá registrar de manera interna y automáticamente._
+ Preparación

#### Criterios de Aceptación:
##### FEATURE: Registrar Receta
+ **Escenario 1:** Usuario abre formulario de Registro de Recetas
    + **GIVEN** El usuario se sitúa en el menú Recetas/Registrar
    + **WHEN**  Hace clic sobre la opción REGISTRAR
    + **THEN**  Se le muestra un formulario de REGISTRO DE RECETAS vacío
+ **Escenario 2:**  Usuario registra información de Receta
    + **GIVEN** El usuario ingresa toda la información relevante (obligatoria) de la receta
    + **WHEN**  Hace clic sobre el botón GRABAR
    + **THEN**  Se le muestra mensaje CONFIRMAR GUARDADO
+ **Escenario 3:**  Guardado de Receta (HAPPY PATH)
    + **GIVEN** El USUARIO no aprobó el guardado aún
    + **WHEN**  Hace clic sobre el botón CONTINUAR
    + **THEN**  El sistema realizar la persistencia de la información
    + **AND**   Muestra un mensaje de GRABADO EXITOSO

### 🔹 Registro Masivo
> _COMO_ usuario
> _QUIERO_ registrar recetas desde fuente masiva
> _PARA_ ingresarlas rápidamente y no registrarlas de una en una

---

## 📄 Actualizar Recetas

> _COMO_ usuario
> _QUIERO_ actualizar recetas
> _PARA_ registrar modificaciones/actualizaciones y/o mejoras

#### Especificación de Reglas:
Esta funcionalidad de trata de modificar/actualizar Recetas. La funcionalidad se sitúa en el formulario "Actualizar Receta".

#### Información Necesaria:
+ Tiempo de Preparación
+ Porciones
    + _El campo de porciones tiene un funcionamiento doble. CuANDo la receta NO está grabada (modo escritura), al cambiar el valor del campo éste reflejará la cantidad de porciones/comensales con la que se registrará la Receta._
    + _Si la Receta está grabada (modo lectura), al cambiar el valor del campo, se calcularán las cantidades de los ingredientes en función a la cantidad de porciones/comensales._
    + _Si la Receta está grabada (modo escritura), al cambiar el valor del campo se actualizará la cantidad de porciones/comensales para la receta sin afectar la lista de Ingredientes._
+ Ingredientes
    + _Los ingredientes serán agregados directamente desde el formulario de Registro de Receta. Si no existe el ingrediente en la base de datos, se deberá registrar de manera interna y automáticamente._
+ Preparación
    + _El tiempo de preparación cuenta con un formato específico con un límite de 99 horas y 59 minutos. Siendo el valor máximo 99:59 el cual representa a NOVENTA Y NUEVE HORAS CON CINCUENTA Y NUEVE MINUTOS._

---

## 📄 Buscar Recetas

### 🔹 Búsqueda simple
> _COMO_ usuario
> _QUIERO_ buscar en el repositorio de recetas
> _PARA_ consultar la que quiera

#### Especificación de Reglas:


#### Información Necesaria:

#### Criterios de Aceptación:
##### FEATURE: Registrar Receta
+ **Escenario 1:** <scenario>
    + **GIVEN** <given>
    + **WHEN** <when>
    + **THEN** <then>

---

## 📄 Ocultar Recetas

> _COMO_ usuario
> _QUIERO_ ocultar recetas
> _PARA_ que otras personas no las puedan encontrar facilmente

### Especificación de Reglas:

### Información Necesaria:

### Criterios de Aceptación:
---

---

## 📄 Eliminar Recetas

> _COMO_ usuario
> _QUIERO_ eliminar recetas
> _PARA_ deshacerme de las que no resultaron bien o de algún experimento fallido

### Especificación de Reglas:

### Información Necesaria:

### Criterios de Aceptación:
---