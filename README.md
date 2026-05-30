# Sistema de Reportes FinanTech
Enlace del repositorio: https://github.com/DruGuerrero/report-engine
## Patrones de Diseño Utilizados

### 1. Patrón Strategy (Estrategia)
Se usa en las interfaces `IReportProcessor` (Procesamiento de datos según rol) e `IReportDelivery` (Canales de entrega) y sus distintas implementaciones.

Se usa porque el patrón Strategy permite definir una familia de algoritmos, encapsular cada uno de ellos en su propia clase y hacerlos intercambiables en tiempo de ejecución. 
En esta solución, el motor principal (`ReportGenerator`) no necesita saber cómo se procesan los datos para un Ejecutivo o un Auditor, ni tampoco cómo se envía el reporte final (si es por Correo Electrónico, Carpeta Compartida o API). Simplemente delega el trabajo a la estrategia que se le inyecta. 
Esto facilita cumplir con el principio SOLID de Open/Closed ya que se pueden crear nuevos canales de entrega o nuevos procesadores sin modificar una sola línea del orquestador principal.

### 2. Patrón Decorator (Decorador)
Se usa en la interfaz `IReportTransformer` y sus implementaciones (`BaseReportTransformer`, `EncryptDecorator`, `HeaderDecorator`, `PlainTextTransformer`).

Se usa porque el patrón Decorator permite añadir responsabilidades o comportamientos adicionales a un objeto de forma dinámica, actuando como un envoltorio (wrapper) sin alterar su estructura de clase base. 
En lugar de crear múltiples subclases para representar cada posible combinación de transformaciones (por ejemplo una clase `ReporteConEncabezadoYEncriptado`), se utilizan decoradores. De esta manera, se pueden apilar libremente transformaciones. Si se desea un encabezado, se pasa por el `HeaderDecorator`. Si además se requiere cifrarlo, se envuelve ese resultado en el `EncryptDecorator`.
