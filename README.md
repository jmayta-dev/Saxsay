# MW.SAXSAY

Gestor de Recetas.

#### Sobre el generador de IDs

Para este proyecto se usa el método de generación de IDs `Time-based and Random Components` (basado en tiempo y componentes aleatorios).

|✅|Método|Ventajas|Desventajas|
|:----:|----|----|----|
|   |UUID/GUID|Muy baja probabilidad de duplicación|Largo y menos legible|
|   |ULID|Ordenable y único|Requiere biblioteca adicional|
|✔️|Time+Random|Único y parcialmente ordenable|Complejidad en la implementación|
|   |Snowflake|Distribuido y único|Requiere configuración de servidores|
|   |Nano ID|Compacto y eficiente|Requiere biblioteca adicional|
|   |Database Squences|Simple de implementar y gestionar|Dependencia de la base de datos|


## Links:
### Repositorio
https://github.com/jmayta-dev/saxsay

### Gestión
https://tree.taiga.io/project/jmayta-weekeatpedia/timeline