# Sesión 9: Introducción a JavaScript y Testing

## Fecha: 03/04/2025

## Objetivos de la Sesión

- Introducción y Fundamentos de HTML
- Práctica utilizando las etiquetas más comunes de HTML para agregar Estilos a nuestra página web. 
- Importación y exportación de modulos. 

## Temas Cubiertos

1. **Fundamentos de HTML**
   - JSON y almacenamiento local
   - Ejemplos de buenas prácticas y depuración 
   - Fundamentos del Testing
   - Importación y exportación de Módulos

## Ejercicios Realizados

### Ejercicio 9: Importación y Exportación de Módulos.

```html
<!-- Actividad -->
<!DOCTYPE html>
<html lang="es">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Clase 9 Módulos</title>
    </head>
    <body>
        <h1>Módulos</h1>
        <script type="module" src="main.js"></script>
    </body>
</html>
```

```js - main.js
//Saludo
import {saludar, despedir} from "./saludo.js"
const nombre = "Lizeth";

//Actividad
import {sumar, restar, multiplicar, dividir} from "./actividad.js"

//Fecha
import { obtenerFechaActual, obtenerHoraActual } from "./fecha.js";


//Saludo
console.log(saludar(nombre));
console.log(despedir(nombre));

//Actividad
console.log("Suma: ", sumar(10, 5));
console.log("Resta: ", restar(10, 5));
console.log("Multiplicación: ", multiplicar(10, 5));
console.log("División: ", dividir(10, 5));
console.log("División: ", dividir(10, 0));

//Fecha
console.log("Fecha Actual:", obtenerFechaActual());
console.log("Hora Actual:", obtenerHoraActual());
```

```js - saludo.js
export function saludar(nombre){
    return `Hola, ${nombre}! Bienvenido a la clase de módulo de JavaScript`
}
export function despedir(nombre){
    return `Adios, ${nombre}! Vuelve pronto a la clase de módulo de JavaScript`
}
```

```js - actividad.js
export function sumar(a, b){
    return a + b;
}
export function restar(a, b){
    return a - b;
}
export function multiplicar(a, b){
    return a * b;
}
export function dividir(a, b){
    if(b === 0){
        return "No se puede dividir por cero."
    }
    return a / b;
}
```

```js - fecha.js
export function obtenerFechaActual(){
    const fecha = new Date();
    return fecha.toLocaleDateString();
}
export function obtenerHoraActual(){
    const fecha = new Date();
    return fecha.toLocaleTimeString();
}
```

## Desafíos Encontrados

- **Pequeño Error**: Para esta actividad tuve un pequeño problema ya que no tenía instalada la extensión de Live Server por lo que me marcaba error al querer correr la página web. Sin embargo, revisando un poco me encontre fácilemnte con la solución.  

## Recursos Adicionales

- [JavaScript Testing Best Practices](https://github.com/goldbergyoni/javascript-testing-best-practices)
- [ES6 Features Overview](https://github.com/lukehoban/es6features)

## Próximos Pasos

- Continuar los avances en cursos de prerrequisitos. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre HTML, CSS y JS, y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 3 del Módulo 1: JavaScript Testing*